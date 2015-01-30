using RestWebApi.Models;
using RestWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestWebApi.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        public Contact[] Get()
        {
            return this.contactRepository.GetAllContacts();
        }

        [HttpPost]
        public bool PostContact(Contact contact)
        {
            return this.contactRepository.SaveContact(contact);
        }

    }
}
