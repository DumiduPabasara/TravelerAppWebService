using Microsoft.AspNetCore.Mvc;
using TravelerAppService.Models;
using TravelerAppService.Services;
using TravelerAppWebService.Services.Interfaces;

namespace TravelerAppWebService.Controllers
{
    [Route("api/trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetAllTrains()
        {
            var trains = await _trainService.GetAllAsync();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetTrainById(string id)
        {
            var train = await _trainService.GetByIdAsync(id);
            if (train == null)
            {
                return NotFound();
            }
            return Ok(train);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateTrain(Train train)
        {
            // Implement validation and error handling as needed

            // Call the service to create the train
            await _trainService.CreateAsync(train);

            // Return the created train with a 201 Created status code
            return CreatedAtAction(nameof(GetTrainById), new { id = train.Id }, train);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain(string id, Train train)
        {
            if (id != train.Id)
            {
                return BadRequest();
            }

            await _trainService.UpdateAsync(id, train);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(string id)
        {
            await _trainService.DeleteAsync(id);
            return NoContent();
        }
    }
}
