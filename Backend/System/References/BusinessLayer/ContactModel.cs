using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace BusinessLayer
{
    public class ContactModel : BaseModel
    {
        public ContactModel():base()
        {

        }

        public ContactModel(BaseModel callingModel) : base(callingModel)
        {

        }

        public List<Contact> List()
        {
            return DB.Contacts.Include(x=>x.Emails).Include(x => x.PhoneNumbers).ToList();
        }

        public void Create(Contact c)
        {
            DB.Contacts.Add(c);
            DB.SaveChanges();
        }

        public Contact Read(int id)
        {
            return DB.Contacts.Find(id);
        }

        public void Update(Contact c)
        {
            Contact contact = DB.Contacts.Find(c.Id);
            if (contact != null)
            {
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;
                contact.Emails = c.Emails;
                contact.PhoneNumbers = c.PhoneNumbers;
                DB.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Contact contact = DB.Contacts.Find(id);
            if (contact != null)
            {
                DB.Contacts.Remove(contact);
                DB.SaveChanges();
            }
        }
    }
}
