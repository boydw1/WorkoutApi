using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;
using WorkoutApi.Data.Entities;
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

        public async Task<IEnumerable<WorkoutEntity>> GetWorkoutsAsync()
        {
            var workouts = await _dbContext.Workouts
                                          .Select(x => new WorkoutEntity
                                          {
                                              Id = x.Id,
                                              Date = x.Date,
                                              Title = x.Title
                                          })
                                          .ToListAsync();
            return workouts;

        }

        public async Task<WorkoutEntity> GetUserWorkoutAsync(int id)
        {
            var workouts = await _dbContext.Workouts
                .Select(x => new WorkoutEntity
                {
                    Id = x.Id,
                    Date = x.Date,
                    Title = x.Title
                })
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return workouts;
        }

        public async Task AddUserWorkoutAsync(WorkoutEntity workout)
        {
            workout.Date = DateTime.Now;

            _dbContext.Workouts.Add(workout);

            await _dbContext.SaveChangesAsync();             
        }

        public async Task DeleteUserWorkoutAsync(int id)
        {            
            var workoutEntity =  _dbContext.Workouts.FindAsync(id).Result;

            _dbContext.Workouts.Remove(workoutEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserWorkoutAsync(WorkoutEntity workout)
        {      
            _dbContext.Workouts.Update(workout);           

            await _dbContext.SaveChangesAsync(); 
        }
    }
}