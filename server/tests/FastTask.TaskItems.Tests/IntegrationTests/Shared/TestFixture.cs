using FastEndpoints.Testing;

namespace FastTask.TaskItems.Tests.IntegrationTests.Shared
{
    public class TestFixture : AppFixture<Program>
    {
        protected override ValueTask SetupAsync()
        {
            return ValueTask.CompletedTask;
        }

        protected override ValueTask TearDownAsync()
        {
            return ValueTask.CompletedTask;
        }
    }
}
