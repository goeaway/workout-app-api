using System.Collections;
using System.Collections.Generic;
using MediatR;
using WorkoutApp.API.Application.Models.Workout;

namespace WorkoutApp.API.Application.Queries.Workout.GetWorkout
{
    public class GetWorkoutRequest : IRequest<WorkoutDTO>
    {
        public string Id { get; set; }

        public GetWorkoutRequest(string id)
        {
            Id = id;
        }
    }
}