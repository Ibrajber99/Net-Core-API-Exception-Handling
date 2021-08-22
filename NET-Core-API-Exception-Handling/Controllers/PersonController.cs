using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_Core_API_Exception_Handling.Application.DTOs;
using NET_Core_API_Exception_Handling.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NET_Core_API_Exception_Handling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }


        [HttpGet("GetAll", Name = "GetAll")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonDTO>>> GetAll()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}", Name = "Get")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            return await _service.GetPersonById(id);

        }


        [HttpPost(Name = "Create")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PersonDTO>> Create(PersonDTO person)
        {
            return await _service.CreatePerson(person);

        }


        [HttpPut("{id}", Name = "Update")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDTO>> Update(int id, PersonDTO person)
        {
            return await _service.UpdatePerson(id, person);

        }


        [HttpDelete("{id}", Name ="Delete")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
           var res =  await _service.DeletePerson(id);

            return Ok(res);
        }
    }
}
