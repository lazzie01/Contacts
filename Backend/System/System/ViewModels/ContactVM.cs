using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.ViewModels
{
    public class ContactVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public ICollection<EmailVM> Emails { get; set; }

        public ICollection<PhoneVM> PhoneNumbers { get; set; }

        public ContactVM() { }

        public ContactVM(Contact c)
        {
            Id = c.Id;
            FirstName = c.FirstName;
            LastName = c.LastName;
            Emails = c.Emails.Select(e=> new EmailVM(e)).ToList();
            PhoneNumbers = c.PhoneNumbers.Select(p => new PhoneVM(p)).ToList();
        }

        public Contact ToModel()
        {
            return new Contact()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Emails = Emails.Select(e=>e.ToModel()).ToList(),
                PhoneNumbers = PhoneNumbers.Select(p => p.ToModel()).ToList()
            };
        }

    }

    public class EmailVM
    {

        public int Id { get; set; }

        public string Address { get; set; }

        public EmailVM() { }

        public EmailVM(Email e)
        {
            Id = e.Id;
            Address = e.Address;
        }

        public Email ToModel()
        {
            return new Email()
            {
                Id = Id,
                Address = Address
            };
        }

    }

    public class PhoneVM
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public PhoneVM() { }

        public PhoneVM(Phone p)
        {
            Id = p.Id;
            Number = p.Number;
        }

        public Phone ToModel()
        {
            return new Phone()
            {
                Id = Id,
                Number = Number
            };
        }

    }
}