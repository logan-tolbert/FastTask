
using FastEndpoints;
using FastEndpoints.Testing;
using FastTask.TaskItems.TaskItemsEndpoints;
using FastTask.TaskItems.Tests.IntegrationTests.Shared;
using FluentAssertions;

namespace FastTask.TaskItems.Tests.IntegrationTests.Endpoints;
[Collection<CollectionFixture>]
public class DeleteTest(TestFixture fixture) : TestBase
{

    [Theory]
    [InlineData("f7cb95b9-b1ed-48b8-82c2-bd2495e97d8e")]
    public async Task Delete_ReturnsSuccesfulOperation(Guid guid)
    {
        var request = new DeleteTaskItemRequest(guid);
        var result = await fixture.Client.DELETEAsync<Delete, DeleteTaskItemRequest>(request);
        result.EnsureSuccessStatusCode();
    }
}
