using Bank.Core.Application.Dto;
using Bank.Core.Application.Interfaces.Services;
using Bank.Core.Application.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bank_Manager_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _svc;
        public BankAccountController(IBankAccountService svc)
        {
            _svc = svc;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "list of BankAccounts",
            Description = "get all the BankAccount records in the database"
            )]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var mList = await _svc.GetAllAsync();
                if (mList.Count == 0 || mList == null)
                {
                    return NotFound();
                }

                return Ok(mList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get BankAccount",
            Description = "Get a BankAccount by its id"
            )]
        public virtual async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var entity = await _svc.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetByAccountNumber/{accountNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get BankAccount",
            Description = "Get a BankAccount by its accountNumber"
            )]
        public virtual async Task<IActionResult> GetByAccountNumber(string accountNumber)
        {
            try
            {
                if (accountNumber == null)
                {
                    return BadRequest();
                }

                var entity = await _svc.GetByAccountNumberAsync(accountNumber);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "BankAccount",
            Description = "Add a BankAccount"
            )]
        public virtual async Task<IActionResult> Add([FromQuery] double amount)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Todos los campos son obligatorios.");
                }

                CreateBankAccountRequest request = new();
                request.Amount = amount;
                var enity = await _svc.AddAsync(request);

                if (enity == null)
                {
                    return BadRequest("Ha ocurrido un problema.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        [HttpPost("Transaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Transacctions",
            Description = "Make a Transaction"
            )]
        public virtual async Task<IActionResult> Transacction([FromBody] CreateTransactionRequest request)
        {
            try
            {
                var enity = await _svc.Transaccion(request);

                if (enity == null)
                {
                    return BadRequest("Ha ocurrido un problema.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Update",
            Description = "To update a BankAccount"
            )]
        public virtual async Task<IActionResult> Update(UpdateBankAccountRequest request, int id)
        {
            try
            {
                if (id == 0 || request == null)
                {
                    return BadRequest();
                }

                var entity = await _svc.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Todos los campos son obligatorios.");
                }

                await _svc.UpdateAsync(request, id);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete/{accountNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Delete",
            Description = "Delete a BankAccount by its accountNumber"
            )]
        public virtual async Task<IActionResult> delete(string accountNumber)
        {
            try
            {
                if (accountNumber == null)
                {
                    return BadRequest();
                }

                var entity = await _svc.GetByAccountNumberAsync(accountNumber);

                if (entity == null)
                {
                    return NotFound();
                }

                await _svc.DeleteAsync(accountNumber);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

