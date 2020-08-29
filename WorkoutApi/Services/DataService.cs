using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;
using WorkoutApi.Data.Entities;
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

        public async Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync()
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

        public async Task<WorkoutModel> GetUserWorkoutAsync(int id)
        {
            var workouts = await _dbContext.Workouts
                .Select(x => new WorkoutModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Title = x.Title
                })
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return workouts;
        }

        //TODO : LOOK AT ASYNC STUFF and needs etc etc 
        public async Task AddUserWorkoutAsync(string title)
        {
            await _dbContext.Workouts.AddAsync(new WorkoutEntity
            {
                Date = DateTime.Now,
                Title = title
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserWorkoutAsync(int id)
        {
            //TODO : need using ?
            
            var workoutEntity = await _dbContext.Workouts.FindAsync(id);

            _dbContext.Workouts.Remove(workoutEntity); // Doesn't contain awaiter ?

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserWorkoutAsync(int id, string editedTitle)
        {
            //TODO : need using ?

            //var workoutEntity = await _dbContext.Workouts.FindAsync(id);

            //workoutEntity.Title = editedTitle;

            var workoutEntity = new WorkoutEntity
            {
                Id = id,
                Title = editedTitle
            }; // TODO @: Loss of information, date ? need to test 

            _dbContext.Workouts.Update(workoutEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}