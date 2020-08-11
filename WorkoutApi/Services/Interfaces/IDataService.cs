using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<WorkoutModel>> GetUserWorkoutsAsync();
    }
}