using System.Collections.Generic;
using MediatR;
using WorkoutApp.API.Application.Models.Workout;

namespace WorkoutApp.API.Application.Queries.Workout.GetWorkoutsForUser
{
    public class GetWorkoutsForUserRequest : IRequest<IEnumerable<WorkoutDTO>>
    {
        public string UserId { get; set; }

        public GetWorkoutsForUserRequest(string userId)
        {
            UserId = userId;
        }
    }
}