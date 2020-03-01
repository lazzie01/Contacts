using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBContext : DbContext
    {
        public DBContext() : base("ConnectionString")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }

    public class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            List<Contact> contacts = new List<Contact>()
            {
               new Contact(){
                    FirstName = "Lazarus",
                    LastName = "Munetsi",
                    Emails = new List<Email>() {
                    new Email(){ Address = "munetsilazzie@gmail.com" },
                    new Email(){ Address = "munetsilazzie@yahoo.com" }
                    },
                    PhoneNumbers = new List<Phone>() {
                    new Phone(){ Number = "0027612115022" },
                    new Phone(){ Number = "00263775449422" }
                    }
            },
               new Contact(){
                    FirstName = "Jaco",
                    LastName = "Kotze",
                    Emails = new List<Email>() {
                    new Email(){ Address = "jkotze@gmail.com" },
                    new Email(){ Address = "jacokotze@yahoo.com" }
                    },
                    PhoneNumbers = new List<Phone>() {
                    new Phone(){ Number = "0027612222044" },
                    new Phone(){ Number = "0027612010087" }
                    }
            }
            };
            context.Contacts.AddRange(contacts);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
