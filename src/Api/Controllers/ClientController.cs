using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.Entries;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var clients = await clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await clientService.GetByIdAsync(id);
            return Ok(client);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] ClientEntry client)
        {
            var newClient = await clientService.CreateAsync(client);
            return StatusCode(201, newClient);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClientEntry client)
        {
            var updatedClient = await clientService.UpdateAsync(id, client);
            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedClient = await clientService.DeleteAsync(id);
            return Ok(deletedClient);
        }
    }
}