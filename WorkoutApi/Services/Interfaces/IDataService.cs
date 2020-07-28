using System.Collections.Generic;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Workout> GetUserWorkouts();
    }
}
