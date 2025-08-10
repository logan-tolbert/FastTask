using FastEndpoints;
using FastEndpoints.Testing;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;
using FastTask.TaskItems.TaskItemsEndpoints;
using FastTask.TaskItems.Tests.IntegrationTests.Shared;
using FluentAssertions;


namespace FastTask.TaskItems.Tests.IntegrationTests.Endpoints;
[Collection<CollectionFixture>]
public class UpdateTaskItemStatusTest(TestFixture fixture) : TestBase
{
    [Fact]
    public async Task UpdateTaskItemStatusAsync_ReturnsItemWithUpdatedStatus()
    {
        var updateRequest = new UpdateTaskItemStatusRequest() { ItemId = new Guid("f7cb95b9-b1ed-48b8-82c2-bd2495e97d8e"), Status = "Completed" };
        var testResult = await fixture.Client.PUTAsync<UpdateTaskItemStatus, UpdateTaskItemStatusRequest, TaskItemDto>(updateRequest);
        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Status.Should().Be(ItemStatus.Completed);
    }
}
