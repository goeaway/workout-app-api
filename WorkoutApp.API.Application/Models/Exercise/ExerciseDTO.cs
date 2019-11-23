using System;
using System.Collections.Generic;
using System.Text;
using WorkoutApp.API.Application.Models.Goal;

namespace WorkoutApp.API.Application.Models.Exercise
{
    public class ExerciseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<GoalDTO> Goals { get; set; }
            = new List<GoalDTO>();
    }
}
