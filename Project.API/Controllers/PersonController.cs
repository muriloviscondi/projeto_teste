using Microsoft.AspNetCore.Mvc;
using Project.API.Controllers.Base;
using Project.API.Models;
using Project.Domain.Arguments.Person;
using Project.Domain.Arguments.PersonPhone;
using Project.Domain.Arguments.PhoneNumberType;
using Project.Domain.Interfaces.Service;
using Projeto.Infra.Transactions;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IServicePerson _servicePerson;

        public PersonController(IUnitOfWork unitOfWork, IServicePerson servicePerson)
            : base(unitOfWork)
        {
            _servicePerson = servicePerson;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll(int? pageNumber)
        {
            var persons = await _servicePerson.GetAllByPersonAsync(pageNumber);
            return ResponseAsync(persons, _servicePerson);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Pessoa não encontrada.");
            }

            var person = await _servicePerson.GetByIdAsync(id);

            return ResponseAsync(person, _servicePerson);
        }

        [HttpPost("{create}")]
        public async Task<IActionResult> Create([FromBody] CreatePersonViewModel model)
        {

            if (model == null)
            {
                return BadRequest("Alerta não informado.");
            }

            var request = new CreatePersonRequest()
            {
                Name = model.Name,
                PersonPhone = new CreatePersonPhoneRequest
                {
                    PhoneNumber = model.PersonPhone.PhoneNumber,
                },
                PhoneNumberType = new CreatePhoneNumberTypeRequest 
                { 
                    Name = model.PhoneType.Name,
                },
            };

            var response = await _servicePerson.CreateAsync(request);
            return ResponseAsync(response, _servicePerson);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Alter([FromBody] AlterPersonViewModel model)
        {

            if (model == null)
            {
                return BadRequest("Pessoa não informado.");
            }

            var data = await GetById(model.Id);

            if (data == null)
            {
                return BadRequest("Pessoa não encontrada.");
            }


            var request = new AlterPersonRequest()
            {
                Id = model.Id,
                PersonPhone = new AlterPersonPhoneRequest
                {
                    PhoneNumber = model.PersonPhone.PhoneNumber,
                },
                PhoneNumberType = new AlterPhoneNumberTypeRequest
                {
                    Name = model.PhoneType.Name,
                },
            };


            var response = await _servicePerson.AlterAsync(request);
            return ResponseAsync(response, _servicePerson);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Alerta não informado.");
            }
            var response = await _servicePerson.Remove(id);

            return ResponseAsync(response, _servicePerson);
        }
    }
}

