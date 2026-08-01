using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppPrestamos.Api.DTOs.CreditorDTO;
using AppPrestamos.Api.interfaces;
using AppPrestamos.Api.Services;
using AppPrestamos.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AppPrestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditorController(ICreditorService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCreditorDTO>> GetCreditorById(int id)
        {
            var creditor = await service.GetCreditorById(id);

            var Ncreditor = new ReadCreditorDTO
            {
                Id = creditor.Id,
                Name = creditor.Name,
                LastName = creditor.LastName,
                Age = creditor.Age,
                Address = creditor.Address,
                Email = creditor.Email,
                Phone = creditor.Phone,
                Type = creditor.Type
            };

            return Ok(Ncreditor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCreditorDTO>>> GetAllCreditors()
        {
            var creditors = await service.GetAllCreditor();

            return Ok(creditors.Select(creditor => new ReadCreditorDTO
            {
                Id = creditor.Id,
                Name = creditor.Name,
                LastName = creditor.LastName,
                Age = creditor.Age,
                Address = creditor.Address,
                Email = creditor.Email,
                Phone = creditor.Phone,
                Type = creditor.Type
            }));
        }


        [HttpPost]

        public async Task<ActionResult> AddCreditor(CreateCreditorDTO creditorDTO)
        {
            var creditor = new Creditor
            {
                Name = creditorDTO.Name,
                LastName = creditorDTO.LastName,
                Address = creditorDTO.Address,
                Email = creditorDTO.Email,
                Phone = creditorDTO.Phone,
                Type = creditorDTO.Type,
                Age = creditorDTO.Age
            };

            await service.AddCreditor(creditor);

            return Created();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateCreditor(int id, CreateCreditorDTO creditorDTO)
        {
            var creditor = await service.GetCreditorById(id);

            creditor.Name = creditorDTO.Name;
            creditor.LastName = creditorDTO.LastName;
            creditor.Address = creditorDTO.Address;
            creditor.Email = creditorDTO.Email;
            creditor.Phone = creditorDTO.Phone;
            creditor.Type = creditorDTO.Type;
            creditor.Age = creditorDTO.Age;

            await service.UpdateCreditor(id, creditor);

            return Created();
        }

        [HttpDelete]

        public async Task<ActionResult> RemoveCreditor(int id)
        {
            await service.RemoveCreditor(id);
            return NoContent();
        }
    }
}