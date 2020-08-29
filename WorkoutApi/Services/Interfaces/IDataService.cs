using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync();
        Task<WorkoutModel> GetUserWorkoutAsync(int id);

        Task AddUserWorkoutAsync(string title);
        Task DeleteUserWorkoutAsync(int id);
        Task UpdateUserWorkoutAsync(int id, string editedTitle);
    }
} 