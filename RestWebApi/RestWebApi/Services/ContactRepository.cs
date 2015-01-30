using RestWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestWebApi.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            HttpContext context = HttpContext.Current;

            if (context != null)
            {
                if (context.Cache[CacheKey] == null)
                {
                    Contact[] contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2, Name = "Dan Roth"
                }
            };

                    context.Cache[CacheKey] = contacts;
                }
            }
        }


        public Contact[] GetAllContacts()
        {

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                return (Contact[])context.Cache[CacheKey];
            }


            return new Contact[]
        {
             new Contact
            {
                Id = 0,
                Name = "Placeholder"
            }
        };
        }

        public bool SaveContact(Contact contact)
        {
            HttpContext context = HttpContext.Current;

            if (context != null)
            {
                try
                {
                    List<Contact> currentData = ((Contact[])context.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    context.Cache[CacheKey] = currentData.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}