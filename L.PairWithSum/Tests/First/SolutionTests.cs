using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace L.PairWithSum.Tests.First
{
    [TestFixture]
    public class SolutionTests
    {
        private Solution _solution;

        [SetUp]
        public void SetUp()
        {
            _solution = new Solution();
        }

        [Test]
        public void HasPairWithSum_ShouldReturnFalse_WhenGivenNumbersEmpty()
        {
            // Arrange
            int[] numbers = Enumerable.Empty<int>().ToArray();
            int sum = 8;

            // Act
            bool hasPairWithSum = _solution.HasPairWithSum(numbers, sum);

            // Assert
            Assert.That(hasPairWithSum, Is.False);
        }

        [Test]
        public void HasPairWithSum_ShouldReturnFalse_WhenNoPairWithSumExists()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 9 };
            int sum = 8;

            // Act
            bool hasPairWithSum = _solution.HasPairWithSum(numbers, sum);

            // Assert
            Assert.That(hasPairWithSum, Is.False);
        }

        [Test]
        public void HasPairWithSum_ShouldReturnTrue_WhenPairWithSumExists()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 4, 4 };
            int sum = 8;

            // Act
            bool hasPairWithSum = _solution.HasPairWithSum(numbers, sum);

            // Assert
            Assert.That(hasPairWithSum, Is.True);
        }

        [Test]
        public void HasPairWithSum_ShouldReturnFalse_WhenAPairSumOverflows()
        {
            // Arrange
            int[] numbers = new int[] { 1, int.MaxValue, int.MaxValue };
            int sum = 8;

            // Act
            bool hasPairWithSum = _solution.HasPairWithSum(numbers, sum);

            // Assert
            Assert.That(hasPairWithSum, Is.False);
        }

        [Test]
        public void HasPairWithSum_ShouldHaveAcceptableExecutionTime_InWorstCaseScenario()
        {
            // Arrange
            int[] numbers = Enumerable.Range(1, 50000).ToArray();
            int sum = -1;
            Stopwatch watch = new Stopwatch();

            // Act
            watch.Start();
            bool hasPairWithSum = _solution.HasPairWithSum(numbers, sum);
            watch.Stop();

            // Assert
            Assert.That(hasPairWithSum, Is.False);
            Assert.That(watch.ElapsedMilliseconds < 1000);
        }
    }
}
