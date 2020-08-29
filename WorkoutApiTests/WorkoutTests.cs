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
        public List<WorkoutModel> _dataSource;

        [SetUp]
        public void Setup()
        {
            //Mocking workout data service behaviour , testing workout service

            _dataService = Substitute.For<IDataService>();

            _dataSource = new List<WorkoutModel>
            {
                new WorkoutModel {Id = 1, Date = new DateTime(2019, 1, 20), Title = "HIIT Workout"},
                new WorkoutModel {Id = 2, Date = new DateTime(2020, 1, 20), Title = "Resistance Workout"},
                new WorkoutModel {Id = 3, Date = new DateTime(2020, 2, 20), Title = "Jump Rope Workout"}
            };

            //Get all workouts for a user in data service

            _dataService.GetWorkoutsAsync().Returns(_dataSource);

            //Get single workout for data service
            _dataService.GetUserWorkoutAsync(1).Returns(_dataSource.FirstOrDefault(x => x.Id == 1));

            //Add for data service 
            _dataService.When(x => x.AddUserWorkoutAsync("Cardio"))
                .Do(x => _dataSource.Add(new WorkoutModel
                {
                    Id = 4,
                    Date = DateTime.Now,
                    Title = "Cardio"
                }));

            //Delete for data service 
            //TODO : SUB DATA SERVICE 
            _dataService.When(x => x.DeleteUserWorkoutAsync(1))
                .Do(x => _dataSource.RemoveAll( w => w.Id == 1));


            //Edit for data service 
            //TODO : SUB DATA SERVICE 
            _dataService.When(x => x.UpdateUserWorkoutAsync(1, "EDITED TITLE"))
                .Do(x => 
                        _dataSource.FirstOrDefault(x => x.Id == 1).Title = "EDITED TITLE"
                    );

            //Initialise with substitutes 
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

        [TestCase(0, "2019, 1, 20", "HIIT Workout")]
        [TestCase(1, "2020, 1, 20", "Resistance Workout")]
        [TestCase(2, "2020, 2, 20", "Jump Rope Workout")]
        public void UserRequestsWorkouts_ValidRequestIsMade_ListOfWorkoutsContainsValidData(int index, DateTime date, string title)
        {
            var results = _workoutService.GetWorkoutsAsync().Result.ToArray()[index];

            Assert.That(results.Date, Is.EqualTo(date));
            Assert.That(results.Title, Is.EqualTo(title));
        }

        //CRUD STUFF 

        [TestCase(1, "2019, 1, 20", "HIIT Workout")]
        public void UserGetsWorkout_ValidRequestIsMade_WorkoutSuccessfullyReturned(int id, DateTime date,string title)
        {
            var result = _workoutService.GetUserWorkoutAsync(id).Result;

            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Date, Is.EqualTo(date));
            Assert.That(result.Title, Is.EqualTo(title));
        }

        [Test]
        public void UserAddsWorkout_ValidRequestIsMade_WorkoutSuccessfullyAdded()
        {
            _workoutService.AddUserWorkoutAsync("Cardio");

            var result = _workoutService.GetWorkoutsAsync().Result.ToList();
           
            Assert.That(result.Count , Is.EqualTo(4));
            Assert.That(result.Last().Title , Is.EqualTo("Cardio"));
        }
        
        [TestCase(1)]
        public void UserDeletesWorkout_ValidRequestIsMade_WorkoutSuccessfullyDeleted(int id)
        {
            _workoutService.DeleteUserWorkoutAsync(id);

            var result = _workoutService.GetWorkoutsAsync().Result.Count();

            Assert.That(result, Is.EqualTo(2));
        }

        [TestCase(1 , "EDITED TITLE")]
        public void UserUpdatesWorkout_ValidRequestIsMade_WorkoutSuccessfullyEdited(int id, string editedTitle)
        {
            _workoutService.UpdateUserWorkoutAsync(id, editedTitle);

            var result = _workoutService.GetUserWorkoutAsync(id).Result.Title;

            Assert.That(result, Is.EqualTo(editedTitle));
        }
    }
}