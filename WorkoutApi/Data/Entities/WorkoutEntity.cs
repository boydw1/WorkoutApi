using System;

namespace WorkoutApi.Data.Entities
{
    public class WorkoutEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}
