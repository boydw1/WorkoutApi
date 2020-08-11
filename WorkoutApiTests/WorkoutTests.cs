using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutApi.Models;
using WorkoutApi.Services;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApiTests
{
    public class WorkoutTests
    {
        public WorkoutService _workoutService;        
        public IDataService _dataService;

        [SetUp]
        public void Setup()
        {
            _dataService = Substitute.For<IDataService>();

            _dataService.GetUserWorkoutsAsync().Returns(new List<WorkoutModel> {
                new WorkoutModel{Date = new DateTime(2019, 1, 20), Title = "HIIT WorkoutEntity"},
                new WorkoutModel{Date = new DateTime(2020, 1, 20), Title = "Resistance WorkoutEntity"},
                new WorkoutModel{Date = new DateTime(2020, 2, 20), Title = "Jump Rope WorkoutEntity"}
            });
            
            _workoutService = new WorkoutService(_dataService);
        }
     
        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsReturned()   
        {
            var result = _workoutService.GetWorkoutsAsync().Result;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsData()
        {
            var result = _workoutService.GetWorkoutsAsync().Result;

            Assert.That(result.Count, Is.GreaterThan(1));
        }

        [TestCase(0, "2019, 1, 20", "HIIT WorkoutEntity")]
        [TestCase(1, "2020, 1, 20", "Resistance WorkoutEntity")]
        [TestCase(2, "2020, 2, 20", "Jump Rope WorkoutEntity")]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsValidData(int index, DateTime date, string title)
        {
            var results = _workoutService.GetWorkoutsAsync().Result.ToArray()[index];

            Assert.That(results.Date, Is.EqualTo(date));
            Assert.That(results.Title, Is.EqualTo(title));
        }

        [Test]
        public void UserAddsWorkout_ValidRequestIsMade_WorkoutSuccessfullyAdded()
        {
            //TODO : ADD WORKOUT USING SERVICES
            Assert.Fail("NYI");
        }

        [Test]
        public void UserAddsExerciseToWorkout_ValidRequestIsMade_ExerciseSuccessfullyAddedToWorkout()
        {
            //TODO : ADD EXERCISE TO WORKOUT USING SERVICES
            Assert.Fail("NYI");
        }
    }
}