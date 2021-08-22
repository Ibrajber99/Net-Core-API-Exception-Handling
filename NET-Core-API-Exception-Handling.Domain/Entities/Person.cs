using NET_Core_API_Exception_Handling.Domain.HelperEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Domain.Entities
{
    public class Person
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public MartialStatus? MartialStatus { get; set; }
    }
}
