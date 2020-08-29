using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Models;

namespace WorkoutApi.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync();
        Task<WorkoutModel> GetUserWorkoutAsync(int id);

        void AddUserWorkoutAsync(string title);
        void DeleteUserWorkoutAsync(int id);
        void UpdateUserWorkoutAsync(int id, string editedTitle);
    }
}