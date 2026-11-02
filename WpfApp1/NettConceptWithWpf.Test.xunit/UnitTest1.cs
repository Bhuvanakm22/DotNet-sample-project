using ClassLibraryProject;
using Moq;
using NetConceptWithWpfApp;
using System.Diagnostics;

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
            //Arrange
            var calculator = new SimpleCalculator();
            //Act
            var result = calculator.DiscountCalculator(input1, input2);
            //Assert
            Assert.Equal(result , expected); // Expected 10% discount
        }
        [Theory]
        [InlineData(100, 10, 90)]
        public void Loginvalid_WithStringInput_InCorrectOutput(int number1, int number2, int expected)
        {
            /***We cannot use mock for Non-override members of DerivedA class which means directly on class
            instead use the "interface" option here IclassInterface 
            When are trying to use a Mock we definitely need respective Interface of that class.
            Error : System.NotSupportedException : Unsupported expression: m => m.Add(number1, number2)
            */
            //Mock<BaseA> MockobjBaseA = new Mock<BaseA>();
            //MockobjBaseA.Setup(x => x.Loginvalid(number1, number2)).Returns(Convert.ToInt32(expected));
            //Assert.AreEqual(expected, objBaseA.Loginvalid(number1, number2).ToString());

            Mock<IMyLibrary> mockSQLIntraction = new Mock<IMyLibrary>();
            mockSQLIntraction.Setup(m => m.Add(number1, number2)).Returns(Convert.ToInt32(expected));
        }
        private const int TestReps = 100;//100_000_000;
        [Fact]
        public void Compare_HashSetContainsVersusDictionaryContainsKey()
        {
            for (int j = 0; j < 10; j++)
            {
                var rand = new Random();
                var dict = new Dictionary<int, int>();
                var hash = new HashSet<int>();

                for (int i = 0; i < TestReps; i++)
                {
                    var key = rand.Next();
                    var value = rand.Next();
                    hash.Add(key);
                    dict.TryAdd(key, value);
                }

                var testPoints = Enumerable.Repeat(1, TestReps).Select(_ => rand.Next()).ToArray();
                var timer = new Stopwatch();
                var total = 0;

                timer.Restart();
                for (int i = 0; i < TestReps; i++)
                {
                    var newKey = testPoints[i];
                    if (hash.Contains(newKey))
                    {
                        total++;
                    }
                }
                Console.WriteLine(timer.Elapsed);

                var target = total;
                Assert.True(total == target);


                timer.Restart();
                for (int i = 0; i < TestReps; i++)
                {
                    var newKey = testPoints[i];
                    if (dict.ContainsKey(newKey))
                    {
                        total++;
                    }
                }
                Console.WriteLine(timer.Elapsed);

                Assert.True(total == target * 2);
                Console.WriteLine("Set");
            }
        }
    }
}