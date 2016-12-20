using System;
using System.Linq;
using ManageEmployees.Data.Abstract;
using ManageEmployees.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManageEmployees.Controllers
{
    [Route("api/[controller]")]
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ContractController(IContractRepository contractRepository, IEmployeeRepository employeeRepository)
        {
            this._contractRepository = contractRepository;
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<Contract> contracts = _contractRepository.AllIncluding(e=>e.Employee);

            if (contracts != null)
            {
                return Ok(contracts);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contract contract = _contractRepository.GetSingle(p=>p.Id==id ,p=>p.Employee);

            if (contract != null)
            {
                return Ok(contract);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contract contract)
        {
            try
            {
                var _contract = contract;
                if (_contract == null) throw new ArgumentNullException(nameof(_contract));
                if(_employeeRepository.GetSingle(contract.EmployeeId) == null) throw new ArgumentNullException($"Department you want to delete has employees assigned.");

                _contractRepository.Add(_contract);
                _contractRepository.Commit();

                return Created($"/api/contract/{contract.Id}", _contract);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contract contract)
        {
            try
            {
                var _contract = _contractRepository.GetSingle(id);

                if (_contract == null) throw new ArgumentNullException(nameof(_contract));

                _contract.Amount = contract.Amount;
                _contract.EndDate = contract.EndDate;
                _contract.StartDate = contract.StartDate;

                if (_employeeRepository.GetSingle(contract.EmployeeId) == null) throw new ArgumentNullException($"Department you want to delete has employees assigned.");
                _contract.EmployeeId = contract.EmployeeId;
                _contractRepository.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contract contract = _contractRepository.GetSingle(id);

            if (contract == null) return new NotFoundResult();
           
                _contractRepository.Delete(contract);
                _contractRepository.Commit();
                return new NoContentResult();
            }
        }
    }
