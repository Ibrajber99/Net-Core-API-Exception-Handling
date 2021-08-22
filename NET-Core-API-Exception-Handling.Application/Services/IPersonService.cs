using NET_Core_API_Exception_Handling.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Application.Services
{
    public interface IPersonService
    {
        Task<PersonDTO> CreatePerson(PersonDTO person);

        Task<PersonDTO> UpdatePerson(int personId,PersonDTO person);

        Task<int> DeletePerson(int personId);

        Task<List<PersonDTO>> GetAll();

        Task<PersonDTO> GetPersonById(int personId);
    }
}
