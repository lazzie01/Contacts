using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ViewModels;
using System.Web.Http;

namespace System.Controllers
{
    public class ContactsController : ApiController
    {
        // GET api/contacts
        [HttpGet]
        public HttpResponseMessage Get()
        {        
            using (ContactModel c = new ContactModel())
            {
                var data = c.List().Select(contact=> new ContactVM(contact)).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }           
        }

        // GET api/contacts/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (ContactModel c = new ContactModel())
            {
                var data = new ContactVM(c.Read(id));
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }

        // POST api/contacts
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ContactVM value)
        {
            using (ContactModel c = new ContactModel())
            {
                c.Create(value.ToModel());
                return Request.CreateResponse(HttpStatusCode.Created, "Contact created");
            }
           
        }

        // PUT api/contacts/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]ContactVM value)
        {
            using (ContactModel c = new ContactModel())
            {
                value.Id = id;
                c.Update(value.ToModel());
                return Request.CreateResponse(HttpStatusCode.OK, "Contact updated");
            }
        }

        // DELETE api/contacts/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            using (ContactModel c = new ContactModel())
            {
                c.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Contact deleted");
            }
        }

    }
}
