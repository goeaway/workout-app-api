using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkoutApp.API.Application.Models.Exercise;

namespace WorkoutApp.API.Application.Models.Workout
{
    public class WorkoutDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<ExerciseDTO> Exercises { get; set; }
             = new List<ExerciseDTO>();
    }
}
