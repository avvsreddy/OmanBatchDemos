using Moq;
namespace SimpleCalculatorLibrary.TestProject
{
    [TestClass]
    public class CalculatorUnitTest
    {

        private Calculator target;
        private Mock<IRepository> mock;
        [TestInitialize]
        public void Init()
        {
            mock = new Mock<IRepository>();
            mock.Setup(r => r.SaveToFile("")).Returns(true);

            target = new Calculator(mock.Object);
        }

        [TestCleanup]
        public void Clean()
        {
            target = null;
        }

        [TestMethod]
        public void FindSumTest_WithValidInput_GiveValidResult() // Pasitive test case
        {
            // AAA approach
            // A-Arrange
            int fno = 10;
            int sno = 10;
            int expected = 20;
            //SimpleCalculatorLibrary.Calculator target = new Calculator();
            // A-Act
            int actual = target.FindSum(fno, sno);
            // A-Assert
            // do not write code with if...else, switch case, for, while, try,catch,finally

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FindSumTest_WithValidInput_ShouldCallSaveMethod()
        {
            target.FindSum(10, 10);
            mock.Verify(r => r.SaveToFile("10 + 10 = 20"), Times.AtLeastOnce);
        }


        [TestMethod]
        [ExpectedException(typeof(NonZeroNumbersException))]
        public void FindSumTest_WithZeroInput_ShouldThrowExp()
        {
            //SimpleCalculatorLibrary.Calculator target = new Calculator();
            target.FindSum(0, 0);
        }

        //2. check for +ve ints
        [TestMethod]
        [ExpectedException(typeof(NegativeNumbersException))]
        public void FindSumTest_WithNegativeInput_ShouldThrowsExp()
        {
            //SimpleCalculatorLibrary.Calculator target = new Calculator();
            target.FindSum(-1, -1);
        }

        //3. check for even numbers
        [TestMethod]
        [ExpectedException(typeof(NotEvenNumberException))]
        public void FindSumTest_WithOddNumbers_ShouldThrowsExp()
        {
            //SimpleCalculatorLibrary.Calculator target = new Calculator();
            target.FindSum(1, 1);
        }
    }

    //class MockRepository : IRepository  // manual mocking
    //{
    //    public bool SaveToFile(string filename)
    //    {
    //        return true;
    //    }
    //}
}