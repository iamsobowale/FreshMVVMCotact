using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ContactUsingFreshMvvm.Interface;
using ContactUsingFreshMvvm.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContactUsingFreshMvvm.Implementation
{
    public class ContactRepo:IContactRepository
    {
        private List<Contact> _contacts;

        public ContactRepo()
        {
            _contacts = GetContactsAsync();
        }

        public void AddContact(Contact contact)
        {
           var count = _contacts.Count;
            if (contact.Id == 0)
            {
                if (contact.Name == null)
                {
                    throw new Exception("Name Not Inputed");
                }
                contact.Id = _contacts.Count + 1;
                _contacts.Add(contact);
            }
            else
            {
                var oldContact = _contacts.Find(c => c.Id == contact.Id);
                oldContact.Name = contact.Name;
                oldContact.PhoneNumber = contact.PhoneNumber;
                oldContact.Email = contact.Email;
            }
        }

        public async Task<bool> DeleteContact(Contact contact)
        {
            var findContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (findContact != null)
            {
                _contacts.Remove(findContact);
                return true;
            }
            return false;
        }

        public List<Contact> GetContactsAsync()
        {

            return new List<Contact> {
                new Contact { Id = 1, Name = "AdeBayo", Email = "iambayo@gmail", Dob = DateTime.Parse("6/05/1995")},
                new Contact { Id = 2, Name = "Michael Ridland", Email = "wale@gmail.com", Dob = DateTime.Parse("4/09/1998")},
                new Contact { Id = 3, Name = "Thunder Apps", Email = "dayo@gmail.com", Dob = DateTime.Parse("8/10/2005")},
            };
        }
    }
}