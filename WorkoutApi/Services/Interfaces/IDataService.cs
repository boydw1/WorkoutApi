using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutApi.Data.Entities;

namespace WorkoutApi.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<WorkoutEntity>> GetWorkoutsAsync();
        Task<WorkoutEntity> GetUserWorkoutAsync(int id);

        Task AddUserWorkoutAsync(WorkoutEntity workout);
        Task DeleteUserWorkoutAsync(int id);
        Task UpdateUserWorkoutAsync(WorkoutEntity workout);
    }
} 