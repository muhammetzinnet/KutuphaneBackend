using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindController : ControllerBase
    {
        private IKindService _kindService;

        public KindController(IKindService kindService)
        {
            _kindService = kindService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _kindService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Success);
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int id)
        {
            var result = _kindService.GetAllById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Success);
        }

        [HttpGet("getallbook")]
        public IActionResult GetAllBook(Book book)
        {
            var result = _kindService.GetAllBook();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Success);
        }

        [HttpPost("add")]
        public IActionResult Add(Kind kind)
        {
            var result = _kindService.Add(kind);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Kind kind)
        {
            var result = _kindService.Delete(kind);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Updated(Kind kind)
        {
            var result = _kindService.Update(kind);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
