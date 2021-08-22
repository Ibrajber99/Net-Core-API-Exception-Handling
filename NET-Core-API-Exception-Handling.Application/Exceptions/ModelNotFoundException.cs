using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application.Exceptions
{
    public class ModelNotFoundException : ApplicationException
    {
        public ModelNotFoundException(string name, string key)
            : base($"{name} ({key}) is not found")
        {

        }


    }
}
