using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WorkoutApp.API.Application.Models.Workout;
using WorkoutApp.API.Persistence.Entities;

namespace WorkoutApp.API.Application.Queries.Workout.GetWorkout
{
    public class GetWorkoutHandler : IRequestHandler<GetWorkoutRequest, WorkoutDTO>
    {
        private readonly IMapper _mapper;

        public GetWorkoutHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<WorkoutDTO> Handle(GetWorkoutRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var workout = new WorkoutEntity() {Id = request.Id, Name = "Workout"};
                return _mapper.Map<WorkoutDTO>(workout);
            });
        }
    }
}
