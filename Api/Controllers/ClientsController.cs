using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ClientsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            var result = await _context.Clients.ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            var newClient = new Client
            {
                Corporative_name = client.Corporative_name,
                Fantasy_name = client.Fantasy_name,
                Cnpj = client.Cnpj,
                Address_public = client.Address_public,
                Number_home = client.Number_home,
                District = client.District,
                Address_add = client.Address_add,
                City = client.City,
                Cep = client.Cep
            };

            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAll),
                new { id = newClient.ID },
                newClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if (id != client.ID)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newClient = await _context.Clients.FindAsync(id);
            if (newClient == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(newClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExist(int id) =>
            _context.Clients.Any(e => e.ID == id);
    }
}
