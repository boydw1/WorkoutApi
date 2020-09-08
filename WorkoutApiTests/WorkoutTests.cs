using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutApi.Data.Entities;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApiTests
{
    public class WorkoutTests
    {
        public IDataService _dataService;
        public List<WorkoutEntity> _dataSource;

        [SetUp]
        public void Setup()
        {
            //Some TDD to get API started

            _dataService = Substitute.For<IDataService>();

            _dataSource = new List<WorkoutEntity>
            {
                new WorkoutEntity {Id = 1, Date = new DateTime(2019, 1, 20), Title = "HIIT Workout"},
                new WorkoutEntity {Id = 2, Date = new DateTime(2020, 1, 20), Title = "Resistance Workout"},
                new WorkoutEntity {Id = 3, Date = new DateTime(2020, 2, 20), Title = "Jump Rope Workout"}
            };

            //Get all workouts for a user in data service
            _dataService.GetWorkoutsAsync().Returns(_dataSource);

            //Get single workout for data service
            _dataService.GetUserWorkoutAsync(1).Returns(_dataSource.FirstOrDefault(x => x.Id == 1));               
            
        }

        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsReturned()   
        {
            var result = _dataService.GetWorkoutsAsync().Result;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsData()
        {
            var result = _dataService.GetWorkoutsAsync().Result;

            Assert.That(result.Count, Is.GreaterThan(1));
        }

        [TestCase(0, "2019, 1, 20", "HIIT Workout")]
        [TestCase(1, "2020, 1, 20", "Resistance Workout")]
        [TestCase(2, "2020, 2, 20", "Jump Rope Workout")]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsValidData(int index, DateTime date, string title)
        {
            var results = _dataService.GetWorkoutsAsync().Result.ToArray()[index];

            Assert.That(results.Date, Is.EqualTo(date));
            Assert.That(results.Title, Is.EqualTo(title));
        }


        [TestCase(1, "2019, 1, 20", "HIIT Workout")]
        public void UserGetsWorkout_ValidRequestIsMade_WorkoutSuccessfullyReturned(int id, DateTime date,string title)
        {
            var result = _dataService.GetUserWorkoutAsync(id).Result;

            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Date, Is.EqualTo(date));
            Assert.That(result.Title, Is.EqualTo(title));
        }
    }
}