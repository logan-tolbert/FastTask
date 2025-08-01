using FastEndpoints;
using FastEndpoints.Testing;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.TaskItemsEndpoints;
using FastTask.TaskItems.Tests.IntegrationTests.Shared;
using FluentAssertions;

namespace FastTask.TaskItems.Tests.IntegrationTests.Endpoints;
[Collection<CollectionFixture>]
public class GetTaskItemByIdTest(TestFixture fixture) : TestBase
{

    [Theory]
    [InlineData("f7cb95b9-b1ed-48b8-82c2-bd2495e97d8e")]
    public async Task GetById_ReturnsExpectedTaskItem(Guid guid)
    {
        var request = new GetTaskItemByIdRequest(guid);
        var rst = await fixture.Client.GETAsync<GetById, GetTaskItemByIdRequest, TaskItemDto>(request);
        rst.Response.EnsureSuccessStatusCode();
        rst.Result.ItemId.Should().Be(guid);
    }
}
