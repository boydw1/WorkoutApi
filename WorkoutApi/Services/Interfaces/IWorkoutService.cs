using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync();
    }
}