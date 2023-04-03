using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TeamProjectA.Api.Controllers;
using TeamProjectA.Application.Commands.Workouts.DeleteWorkout;
using TeamProjectA.Application.Queries.Workouts.GetWorkoutDetailsById;
using TeamProjectA.Domain.Entities.Workouts;

namespace TeamProjectA.Tests.Api.Tests;

[TestFixture]
public class WorkoutsControllerTests
{
    [Test]
    public async Task DeleteWorkout_delete_workout_success()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<DeleteWorkoutByIdCommand>(), default))
            .ReturnsAsync(true);

        var controller = new WorkoutsController(mediator.Object);

        var result = await controller.DeleteWorkout(new DeleteWorkoutByIdCommand());

        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public async Task DeleteWorkout_fail_while_deleting_workout()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<DeleteWorkoutByIdCommand>(), default))
            .ReturnsAsync(false);

        var controller = new WorkoutsController(mediator.Object);

        var result = await controller.DeleteWorkout(new DeleteWorkoutByIdCommand());

        Assert.IsInstanceOf<BadRequestResult>(result);
    }

    [Test]
    public async Task GetWorkout_success_get_workout()
    {
        var workout = new WorkoutDto
        {
            Id = new Guid("0ac31bfe-b3ac-4287-9856-10a7f1135b7e"),
            WorkoutDate = DateTime.Now,
            WorkoutName = "YYj",
            AuthorId = new Guid("85f2682e-48e5-4aea-a366-76fde28c5787"),
            OwnerId = new Guid("690af2ea-4ea1-4ca3-a8ff-77721f882d62"),
            Exercises = new List<ExerciseDto>()
        };

        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetWorkoutDetailsByIdQuery>(), default))
            .ReturnsAsync(workout);

        var controller = new WorkoutsController(mediator.Object);

        var result = await controller.GetWorkoutDetails(new GetWorkoutDetailsByIdQuery());

        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        Assert.AreEqual(workout, ((OkObjectResult)result.Result!).Value);
    }

    [Test]
    public async Task GetWorkout_fail_to_get_workout()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetWorkoutDetailsByIdQuery>(), default))
            .ReturnsAsync(null as WorkoutDto);

        var controller = new WorkoutsController(mediator.Object);

        var result = await controller.GetWorkoutDetails(new GetWorkoutDetailsByIdQuery());
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }
}