using EFCrud.Models;
using EFCrud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EFCrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Clients
        [HttpGet]
        public List<Clients> GetClients()
        {
            return context.Clients.OrderByDescending(c => c.Id).ToList();
        }

        // GET: Clients by id
        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        //INSERT: Create Client
        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            // submitted data is valid

            var otherClient = context.Clients.FirstOrDefault(c => c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var client = new Clients
            {
                Name = clientDto.Name,
                Address = clientDto.Address,
                Email = clientDto.Email,
                Contact = clientDto.Contact ?? ""
            };

            context.Clients.Add(client);
            context.SaveChanges();
            return Ok(client);
        }

        //INSERT: Update Client

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, ClientDto clientDto)
        {
            // submitted data is valid

            var otherClient = context.Clients.FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            client.Name = clientDto.Name;
            client.Address = clientDto.Address;
            client.Email = clientDto.Email;
            client.Contact = clientDto.Contact ?? "";
            context.SaveChanges();

            return Ok(client);
        }

        //DELETE: Delete Client
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok();
        }
    }
}
