using GhBulk.Commands;

namespace GhBulk.Test.CommandsTests
{
    public class GlobalCommandsTests
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            var args = new[] {"--help"};
            // Act
            var result = await GlobalCommand.Run(args);
            
            
            // Assert
            Assert.Equal(0, result);
        }
    }
}