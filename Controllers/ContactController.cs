using AutoMapper;
using CustomerDb.Models;
using CustomerDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly DataContext _db;
        private readonly ContactRepo _repo;
        private readonly IMapper _mapper;

        public ContactController(DataContext db, IMapper mapper)
        {
            _db = db;
            _repo = new ContactRepo(_db);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Contact> contacts = _repo.Get();
            IEnumerable<ContactResponse> response = _mapper.Map<IEnumerable<ContactResponse>>(contacts);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact? contact = _repo.Get(id);
            ContactResponse response = _mapper.Map<ContactResponse>(contact);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(ContactRequest request)
        {
            Contact contact = _mapper.Map<Contact>(request);

            _repo.Create(contact);
            _repo.Save();

            return Get(contact.id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactRequest request)
        {
            Contact contact = _mapper.Map<Contact>(request);
            contact.id = id;

            _repo.Update(contact);
            _repo.Save();

            return Get(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return Ok();
        }
    }
}