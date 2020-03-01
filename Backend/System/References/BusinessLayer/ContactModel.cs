using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            return DB.Contacts.Include(x => x.Emails).Include(x => x.PhoneNumbers).FirstOrDefault(x=>x.Id == id);
        }

        public void Update(Contact c)
        {
            Contact contact = DB.Contacts.Include(x => x.Emails).Include(x => x.PhoneNumbers).FirstOrDefault(x => x.Id == c.Id);
            if (contact != null)
            {
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;
                //remove old emails & phone numbers
                DB.Emails.RemoveRange(contact.Emails);
                DB.Phones.RemoveRange(contact.PhoneNumbers);
                //add new emails & phone numbers
                contact.Emails = c.Emails.Where(e=>!string.IsNullOrEmpty(e.Address)).ToList();
                contact.PhoneNumbers = c.PhoneNumbers.Where(p => !string.IsNullOrEmpty(p.Number)).ToList();
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
