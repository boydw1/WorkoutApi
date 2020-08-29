using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkoutApi.Models;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IWorkoutService _workoutService;

        public WorkoutController(ILogger<WorkoutController> logger, IWorkoutService workoutService)
        {
            _logger = logger;
            _workoutService = workoutService;
        }

        [HttpGet]
        public IEnumerable<WorkoutModel> Get()
        {
            return _workoutService.GetWorkoutsAsync().Result;
        }

        [HttpGet]
        public WorkoutModel Get(int id)
        {
            return _workoutService.GetUserWorkoutAsync(id).Result;
        }

        [HttpPost]
        public IEnumerable<WorkoutModel> Add(string title)
        {
             _workoutService.AddUserWorkoutAsync(title);

             return _workoutService.GetWorkoutsAsync().Result;
        }

        [HttpPost]
        public IEnumerable<WorkoutModel> Delete(int id)
        {
            _workoutService.DeleteUserWorkoutAsync(id);

            return _workoutService.GetWorkoutsAsync().Result;
        }

        [HttpPost]
        public IEnumerable<WorkoutModel> Update(int id, string title)
        {
            _workoutService.UpdateUserWorkoutAsync(id, title);

            return _workoutService.GetWorkoutsAsync().Result;
        }
    }
}