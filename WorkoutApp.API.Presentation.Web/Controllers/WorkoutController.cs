using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.API.Application.Models.Workout;
using WorkoutApp.API.Application.Queries.Workout.GetWorkout;
using WorkoutApp.API.Application.Queries.Workout.GetWorkoutsForUser;

namespace WorkoutApp.API.Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getworkout/{id}")]
        public Task<WorkoutDTO> GetWorkout(string id)
        {
            return _mediator.Send(new GetWorkoutRequest(id));
        }

        [HttpGet]
        [Route("getworkoutsforuser/{userId}")]
        public Task<IEnumerable<WorkoutDTO>> GetWorkoutsForUser(string userId)
        {
            return _mediator.Send(new GetWorkoutsForUserRequest(userId));
        }
    }
}