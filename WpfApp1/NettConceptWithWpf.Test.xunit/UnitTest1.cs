using NetConceptWithWpfApp;

namespace NetConceptWithWpf.Test.xunit
{
    public class UnitTest1
    {
        //Fact cannot have a parameters
        [Fact]
        public void TestDiscount1()
        {
            var calculator = new SimpleCalculator();
            var result = calculator.DiscountCalculator(100, 10);
            Assert.True(result == 90); // Expected 10% discount
        }

        //Theory only can have a parameters
        [Theory]
        [InlineData(100,10,90)]
        public void TestDiscount(int input1, int input2, int expected)
        {
            var calculator = new SimpleCalculator();
            var result = calculator.DiscountCalculator(input1, input2);
            Assert.Equal(result , expected); // Expected 10% discount
        }
    }
}