using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkoutApi.Data.Entities;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IDataService _dataService;

        public WorkoutController(ILogger<WorkoutController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkoutEntity>> GetAsync()
        {   
            var results = await _dataService.GetWorkoutsAsync();

            return results;
        }

        [HttpGet("{id}")]
        public async Task<WorkoutEntity> GetAsync(int id)
        {
            var results = await _dataService.GetUserWorkoutAsync(id);

            return results;
        }


        [HttpPost]
        public async Task<IEnumerable<WorkoutEntity>> AddAsync(WorkoutEntity workout)
        {
            await _dataService.AddUserWorkoutAsync(workout);

            return _dataService.GetWorkoutsAsync().Result;
        }      

        [HttpDelete]
        public async Task<IEnumerable<WorkoutEntity>> DeleteAsync(int id)
        {
            await _dataService.DeleteUserWorkoutAsync(id);

            return _dataService.GetWorkoutsAsync().Result;
        }

        [HttpPut]
        public async Task<IEnumerable<WorkoutEntity>> UpdateAsync(WorkoutEntity workout)
        {
            await _dataService.UpdateUserWorkoutAsync(workout);

            return _dataService.GetWorkoutsAsync().Result;
        }
    }
}