using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; }
     
    }

    public class Address
    {
        [Key]
        [ForeignKey("Contact")]
        public int Id { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }
        
        public Contact Contact { get; set; }

    }
}
