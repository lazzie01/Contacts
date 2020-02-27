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
        public DBContext():base("ConnectionString")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }

    public class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            Contact c = new Contact()
            {
                FirstName = "Lazarus",
                LastName = "Munetsi",
                Addresses = new List<Address>() { new Address()
                                                   {
                                                     ContactNumber="+27 612 115 022",
                                                     EmailAddress="munetsilazzie@gmail.com"
                                                 } }
            };
            context.Contacts.Add(c);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
