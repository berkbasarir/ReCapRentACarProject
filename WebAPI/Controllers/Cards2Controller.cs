using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cards2Controller : ControllerBase
    {
        private ICardService _cardService;

        public Cards2Controller(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getcardsbycustomerid")]
        public IActionResult GetCardsByCustomerId(int customerId)
        {
            var result = _cardService.GetCardsByCustomerId(customerId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Card card)
        {
            var result = _cardService.Add(card);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Card card)
        {
            var result = _cardService.Update(card);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Card card)
        {
            var result = _cardService.Delete(card);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
