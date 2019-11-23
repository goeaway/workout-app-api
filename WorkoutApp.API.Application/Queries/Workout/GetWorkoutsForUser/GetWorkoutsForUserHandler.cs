using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WorkoutApp.API.Application.Models.Exercise;
using WorkoutApp.API.Application.Models.Workout;
using WorkoutApp.API.Persistence.Entities;

namespace WorkoutApp.API.Application.Queries.Workout.GetWorkoutsForUser
{
    public class GetWorkoutsForUserHandler : IRequestHandler<GetWorkoutsForUserRequest, IEnumerable<WorkoutDTO>>
    {
        private readonly IMapper _mapper;

        public GetWorkoutsForUserHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<IEnumerable<WorkoutDTO>> Handle(GetWorkoutsForUserRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var workouts = new List<WorkoutEntity>
                {
                    new WorkoutEntity { Id = "workout 1", Name = "Workout ONE" },
                    new WorkoutEntity { Id = "workout 2", Name = "Workout TWO" }
                };

                var mapped = _mapper.Map<IEnumerable<WorkoutDTO>>(workouts);

                foreach(var mappedItem in mapped)
                {
                    mappedItem.Exercises = new List<ExerciseDTO>();
                }

                return mapped;
            });
        }
    }
}
