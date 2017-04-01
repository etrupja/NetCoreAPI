using System;
using ManageEmployees.Data.Abstract;
using ManageEmployees.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ManageEmployees.Models.Enums;
using System.Linq;

namespace ManageEmployees.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
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
            var contracts = _contractRepository.AllIncluding(e=>e.Employee).Where(rs => rs.RecordStatus == RecordStatus.Active);

            if (contracts.Any())
                return Ok(contracts);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contract contract = _contractRepository.GetSingle(p=>p.Id==id, p=>p.Employee);
            if (contract != null) return Ok(contract);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] dynamic contract)
        {
            try
            {
                var _contract = new Contract()
                {
                    Name = contract.Name,
                    StartDate = contract.startDate,
                    EndDate = contract.endDate,
                    Amount = contract.amount,
                    EmployeeId = contract.employeeId
                };

                if (_contract == null) throw new ArgumentNullException(nameof(_contract));
                if(_employeeRepository.GetSingle(_contract.EmployeeId) == null) throw new ArgumentNullException($"Department you want to delete has employees assigned.");

                _contractRepository.Add(_contract);
                _contractRepository.Commit();

                return Created($"/api/contract/", _contract);
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
                _contract.Name = contract.Name;
                _contract.Amount = contract.Amount;
                _contract.EndDate = contract.EndDate;
                _contract.StartDate = contract.StartDate;
                _contract.RecordStatus = contract.RecordStatus;

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
            var contract = _contractRepository.GetSingle(id);

            if (contract == null) return new NotFoundResult();
           
            _contractRepository.SetStatusDeleted(contract);
            _contractRepository.Commit();
            return new NoContentResult();
            }
        }
    }
