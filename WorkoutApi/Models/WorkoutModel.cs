using System;

namespace WorkoutApi.Models
{
    public class WorkoutModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        //TODO: list of exercises for workout
    }
}
