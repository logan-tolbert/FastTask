using FastEndpoints.Testing;
using FastEndpoints;
using FluentAssertions;
using FastTask.TaskItems.Tests.IntegrationTests.Shared;
using FastTask.TaskItems.TaskItemsEndpoints;


namespace FastTask.TaskItems.Tests.IntegrationTests.Endpoints;
[Collection<CollectionFixture>]
public class ListTaskItemsTest(TestFixture fixture) : TestBase
{

    [Fact]
    public async Task List_ReturnsAllTaskItems()
    {
        var testResult = await fixture.Client.GETAsync<List, ListTaskItemsResponse>();
        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.TaskList.Count.Should().Be(10);
    }
}
