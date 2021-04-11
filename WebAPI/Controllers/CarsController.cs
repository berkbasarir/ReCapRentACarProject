using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarsdetails")]
        public IActionResult GetAllCarsDetails()
        {
            var result = _carService.GetAllCarsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetCarsDetail()
        {
            var result = _carService.GetCarDetailDtos();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailbybrandid")]
        public IActionResult GetCarsDetailByBrandId(int brandId)
        {
            var result = _carService.GetCarDetailDtos(c => c.BrandId == brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailbycolorid")]
        public IActionResult GetCarsDetailByColorId(int colorId)
        {
            var result = _carService.GetCarDetailDtos(c => c.ColorId == colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getdetailbycarid")]
        public IActionResult GetCarsDetailByCarId(int carId)
        {
            var result = _carService.GetCarDetailDtos(c => c.Id == carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
