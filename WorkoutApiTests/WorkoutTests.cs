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
            _dataService.GetUserWorkouts().Returns(new List<Workout> {
                new Workout{Date = new DateTime(2019, 1, 20), Title = "HIIT Workout"}, 
                new Workout{Date = new DateTime(2020, 1, 20), Title = "Resistance Workout"},
                new Workout{Date = new DateTime(2020, 2, 20), Title = "Jump Rope Workout"}
            });

            _workoutService = new WorkoutService(_dataService);
        }
     
        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsReturned()   
        {
            var result = _workoutService.GetWorkouts();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsData()
        {
            var result = _workoutService.GetWorkouts();

            Assert.That(result.Count, Is.GreaterThan(1));
        }

        [TestCase(0, "2019, 1, 20", "HIIT Workout")]
        [TestCase(1, "2020, 1, 20", "Resistance Workout")]
        [TestCase(2, "2020, 2, 20", "Jump Rope Workout")]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsValidData(int index, DateTime date, string title)
        {
            var results = _workoutService.GetWorkouts().ToArray()[index];

            Assert.That(results.Date, Is.EqualTo(date));
            Assert.That(results.Title, Is.EqualTo(title));
        }

        [Test]
        public void UserAddsWorkout_ValidRequestIsMade_WorkoutSuccessfullyAdded()
        {
            //TODO : ADD WORKOUT USING SERVICES
            Assert.Fail("NYI");
        }
    }
}