using Microsoft.AspNetCore.Mvc;
using TrainReservationApi.entities;
using TrainReservationApi.Models;
using TrainReservationApi.services;

namespace TrainReservationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RezervasyonController : ControllerBase
    {
        private readonly IRezervasyonService _rezervasyonService;

        public RezervasyonController(IRezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
        }

        [HttpGet]
        public ActionResult<List<Rezervasyon>> GetAll()
        {
            return _rezervasyonService.GetAllRezervasyonlar();
        }

        [HttpPost]
        public ActionResult<RezervasyonResponse> Post([FromBody] RezervasyonRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return BadRequest($"Validation failed: {errors}");
            }
            
            if (request.Tren == null || request.Tren.Vagonlar == null)
            {
                return BadRequest("Tren ve vagon bilgileri gereklidir.");
            }
            
            var result = _rezervasyonService.RezervasyonYap(request);
            return Ok(result);
        }
    }
}
