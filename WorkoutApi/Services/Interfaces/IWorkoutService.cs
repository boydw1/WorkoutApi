using System.Collections.Generic;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetWorkouts();
    }
}