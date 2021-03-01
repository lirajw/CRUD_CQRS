using Domain.Comands.Requests;
using Domain.Exceptions;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_CQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _CustomerService;
        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _CustomerService.GetAll();

                return Ok(customers);
                
            }
            catch (ValidationRuleException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            try
            {
                var customer = await _CustomerService.GetById(id);

                return Ok(customer);

            }
            catch (ValidationRuleException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest command)
        {
            try
            {
                var response = await _CustomerService.Add(command);

                return Ok(response);

            }
            catch (ValidationRuleException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest command)
        {
            try
            {
                var response = await _CustomerService.Update(command);

                return Ok(response);

            }
            catch (ValidationRuleException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, Guid id)
        {
            try
            {
                var response = await _CustomerService.Remove(id);

                return Ok(response);

            }
            catch (ValidationRuleException ex)
            {
                return NotFound(ex.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
