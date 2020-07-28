using System;
using System.Collections.Generic;
using WorkoutApi.Models;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<Workout> GetUserWorkouts()
        {
            throw new NotImplementedException("Decide on data persistence solution");
        }
    }
}