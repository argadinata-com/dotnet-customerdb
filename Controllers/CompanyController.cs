using AutoMapper;
using CustomerDb.Models;
using CustomerDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly CompanyRepo _repo;
        private readonly IMapper _mapper;

        public CompanyController(DataContext db, IMapper mapper)
        {
            _db = db;
            _repo = new CompanyRepo(_db);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Company> companies = _repo.Get();
            IEnumerable<CompanyResponse> response = _mapper.Map<IEnumerable<CompanyResponse>>(companies);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Company? company = _repo.Get(id);
            CompanyResponse response = _mapper.Map<CompanyResponse>(company);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);

            _repo.Create(company);
            _repo.Save();

            CompanyResponse response = _mapper.Map<CompanyResponse>(company);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.id = id;
            
            _repo.Update(company);
            _repo.Save();

            CompanyResponse response = _mapper.Map<CompanyResponse>(company);

            return Ok(response);
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