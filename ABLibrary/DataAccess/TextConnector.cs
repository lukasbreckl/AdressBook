using ABLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABLibrary.DataAccess.TextHelpers;

namespace ABLibrary.DataAccess
{
    public class TextConnector  : IDataConnection
    {
        private const string ContactsFile = "Contacts.csv";
         
        public ContactModel CreateContact(ContactModel NewContact)
        {
            List<ContactModel> Contacts = ContactsFile.FullFilePath().LoadFile().ConvertToContactModel();
            int currentId = 1;
            if (Contacts.Count > 0)
            {
                currentId = Contacts.OrderByDescending(x => x.id).First().id + 1;
            }
            NewContact.id = currentId;
            Contacts.Add(NewContact);
            Contacts.SaveToContacts(ContactsFile);
            return NewContact;
        }
    }
}
