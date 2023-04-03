using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using TeamProjectA.Infrastructure.DAL;
using TeamProjectA.Infrastructure.Entities;
using TeamProjectA.Infrastructure.Repositories;

namespace TeamProjectA.Tests.Infrastructure.Tests.WorkoutRepository;

[TestFixture]
public class DeleteWorkoutTests
{
    [Test]
    public async Task DeleteWorkoutById_fail_deleted_count_equal_zero()
    {
        var mockContext = new Mock<IWorkoutsContext>();
        mockContext.Setup(c =>
            c.GetCollection().DeleteOneAsync(It.IsAny<FilterDefinition<WorkoutEntity>>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteResult.Acknowledged(0));

        var repository = new WorkoutsRepository(mockContext.Object, null!);
        var result = await repository.DeleteWorkoutById(new Guid("d081a23d-c007-4338-8a26-8d8706a9f87f"));
        Assert.IsFalse(result);
    }
    
    [Test]
    public async Task DeleteWorkoutById_success_deleted_count_equal_one()
    {
        var mockContext = new Mock<IWorkoutsContext>();
        mockContext.Setup(c =>
            c.GetCollection().DeleteOneAsync(It.IsAny<FilterDefinition<WorkoutEntity>>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteResult.Acknowledged(1));

        var repository = new WorkoutsRepository(mockContext.Object, null!);
        var result = await repository.DeleteWorkoutById(new Guid("d081a23d-c007-4338-8a26-8d8706a9f87f"));
        Assert.IsTrue(result);
    }
}