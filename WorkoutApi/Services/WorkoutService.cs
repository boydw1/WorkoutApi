using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync()
        {
            return _dataService.GetWorkoutsAsync();
        }

        public Task<WorkoutModel> GetUserWorkoutAsync(int id)
        {
            return _dataService.GetUserWorkoutAsync(id);
        }

        public void AddUserWorkoutAsync(string title)
        {
            _dataService.AddUserWorkoutAsync(title);
        }

        public void DeleteUserWorkoutAsync(int id)
        {
            _dataService.DeleteUserWorkoutAsync(id);
        }

        public void UpdateUserWorkoutAsync(int id, string editedTitle)
        {
            _dataService.UpdateUserWorkoutAsync(id, editedTitle);
        }
    }
}