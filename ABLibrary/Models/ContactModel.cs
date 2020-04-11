using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABLibrary.Models
{
   public class ContactModel
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

        public ContactModel(string firstName, string lastName, string phoneNumber )
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;

        }

   

    }
}
