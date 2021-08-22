using NET_Core_API_Exception_Handling.Domain.HelperEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application.DTOs
{
    public class PersonDTO
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public MartialStatus MartialStatus { get; set; }

    }
}
