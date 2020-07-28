using System.Collections.Generic;
using WorkoutApi.Models;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IDataService _dataService;

        public WorkoutService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<Workout> GetWorkouts()
        {
            return _dataService.GetUserWorkouts(); 
        }
    }
}