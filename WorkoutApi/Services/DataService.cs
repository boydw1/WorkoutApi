using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;
using WorkoutApi.Models;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi.Services
{
    public class DataService : IDataService
    {
        private readonly WorkoutApiDbContext _dbContext;

        public DataService(WorkoutApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutModel>> GetUserWorkoutsAsync()
        {
            var workouts = await _dbContext.Workouts
                                          .Select(x => new WorkoutModel
                                          {
                                              Id = x.Id,
                                              Date = x.Date,
                                              Title = x.Title
                                          })
                                          .ToListAsync();
            return workouts;
        }
    }
}