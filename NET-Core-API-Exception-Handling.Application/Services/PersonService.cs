using AutoMapper;
using NET_Core_API_Exception_Handling.Application.DTOs;
using NET_Core_API_Exception_Handling.Application.Exceptions;
using NET_Core_API_Exception_Handling.Application.Repo_Interfaces;
using NET_Core_API_Exception_Handling.Application.ValidationClasses;
using NET_Core_API_Exception_Handling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IAsyncBaseRepository<Person> _baseRepo;

        private readonly CreatePersonValidation _createPersonValidator;

        private readonly UpdatePersonValidator _updatePersonValidator;

        private readonly IMapper _mapper;

        public PersonService(IAsyncBaseRepository<Person> baseRepo,
            CreatePersonValidation createPersonValidator, UpdatePersonValidator updatePersonValidator, IMapper mapper)
        {
            _baseRepo = baseRepo;

            _createPersonValidator = createPersonValidator;
            _updatePersonValidator = updatePersonValidator;

            _mapper = mapper;
        }

        public async Task<PersonDTO> CreatePerson(PersonDTO person)
        {
            var validationRes = await _createPersonValidator.ValidateAsync(person);

            if (!validationRes.IsValid)
            {
                throw new ModelNotValidException(validationRes);
            }

            var personDomain = _mapper.Map<Person>(person);

            await _baseRepo.AddAsync(personDomain);

            return _mapper.Map<PersonDTO>(personDomain);

        }

        public async Task<PersonDTO> UpdatePerson(int personId,PersonDTO person)
        {
            if(personId != person.PersonID)
            {
                throw new ModelNotFoundException(nameof(Person), personId.ToString());
            }


            var validationRes = await _updatePersonValidator.ValidateAsync(person);

            if (!validationRes.IsValid)
            {
                throw new ModelNotValidException(validationRes);
            }

            var personDomain = _mapper.Map<Person>(person);

            await _baseRepo.UpdateAsync(personDomain);

            return _mapper.Map<PersonDTO>(personDomain);
        }

        public async Task<int> DeletePerson(int personId)
        {
            var personFound = await _baseRepo.GetByIdAsync(personId);

            if(personFound == null)
            {
                throw new ModelNotFoundException(nameof(Person), personId.ToString());
            }

           await _baseRepo.DeleteAsync(_mapper.Map<Person>(personFound));

            return 1;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            var personList =  await _baseRepo.ListAllAsync();

            if(personList == null)
            {
                throw new ModelNotFoundException(nameof(Person), "");
            }

            var personDto =  _mapper.Map<List<PersonDTO>>(personList);

            return personDto;
        }

        public async Task<PersonDTO> GetPersonById(int personId)
        {
            var personFound = await _baseRepo.GetByIdAsync(personId);

            if(personFound == null)
            {
                throw new ModelNotFoundException(nameof(Person), personId.ToString());
            }

            return _mapper.Map<PersonDTO>(personFound);
        }

    }
}
