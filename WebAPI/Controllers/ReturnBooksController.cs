using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnBooksController : ControllerBase
    {
        private IReturnBookService _returnBookService;

        public ReturnBooksController(IReturnBookService returnBookService)
        {
            _returnBookService = returnBookService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _returnBookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _returnBookService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
