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
            var calculator = new SimpleCalculator();
            var result = calculator.DiscountCalculator(input1, input2);
            Assert.Equal(result , expected); // Expected 10% discount
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