using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using WorkoutApi.Models;
using WorkoutApi.Services;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApiTests
{
    //Tests for adding exercises to workouts
    public class ExerciseTests
    {
        public WorkoutService _workoutService;
        public IDataService _dataService;
        public List<WorkoutModel> _dataSource;

        [SetUp]
        public void Setup()
        {
            _dataService = Substitute.For<IDataService>();

            _dataSource = new List<WorkoutModel>
            {
                new WorkoutModel {Date = new DateTime(2019, 1, 20), Title = "HIIT Workout"},
                new WorkoutModel {Date = new DateTime(2020, 1, 20), Title = "Resistance Workout"},
                new WorkoutModel {Date = new DateTime(2020, 2, 20), Title = "Jump Rope Workout"}
            };

            _dataService.GetWorkoutsAsync().Returns(_dataSource);

            _workoutService = new WorkoutService(_dataService);

            _dataService.When(x => x.AddUserWorkoutAsync("Cardio"))
                .Do(x => _dataSource.Add(new WorkoutModel
                {
                    Date = DateTime.Now,
                    Title = "Cardio"
                }));
        }

        [Test]
        public void UserAddsExerciseToWorkout_ValidRequestIsMade_ExerciseSuccessfullyAddedToWorkout()
        {
            //TODO : ADD EXERCISE TO WORKOUT USING SERVICES
            Assert.Fail("NYI");
        }
    }
}
