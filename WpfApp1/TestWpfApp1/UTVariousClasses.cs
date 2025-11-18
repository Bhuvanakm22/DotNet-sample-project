using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;
using WpfApp1;
using NetConceptWithWpfApp;
using NUnit.Framework.Internal;
namespace TestWpfApp1
{
   
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2,3,"2")]
        [TestCase(2,3,"5")]
        public void Passcheck_BothScenarios(int number1,int number2,string expected)
        {
            //Assert.Pass();
            DerivedA objDerivedA = new DerivedA() ;

            //Assert.AreEqual(expected, objDerivedA.Passcheck(number1, number2).ToString());
            Assert.That(objDerivedA.Passcheck(number1, number2).ToString()== expected);


        }
        [Test]
        [TestCase("2", "3", "2")]
        public void Loginvalid_WithStringInput_InCorrectOutput(int number1, int number2, string expected)
        {
            /***We cannot use mock for Non-override members of DerivedA class which means directly on class
            instead use the "interface" option here IclassInterface 
            When are trying to use a Mock we definitely need respective Interface of that class.

            */
            //Mock<BaseA> MockobjBaseA = new Mock<BaseA>();
            //MockobjBaseA.Setup(x => x.Loginvalid(number1, number2)).Returns(Convert.ToInt32(expected));
            //Assert.AreEqual(expected, objBaseA.Loginvalid(number1, number2).ToString());

            Mock<IclassInterface> mockSQLIntraction = new Mock<IclassInterface>();
            mockSQLIntraction.Setup(m => m.Loginvalid(number1, number2)).Returns(Convert.ToInt32(expected));
        }
        [TestCase(2, 3, "5")]
        public void Loginvalid_WithIntInput_CorrectOutput(int number1, int number2, string expected)
        {
            BaseA objBaseA = new BaseA() ;
            //Assert.AreEqual(expected, objBaseA.Loginvalid(number1, number2).ToString());
        }
        //[Test]
        public void DivideByZeroException_StatMethod()
        {
            DerivedA objDerivedA = new DerivedA();
            //string str = "exception";
            var ex= Assert.Throws<DivideByZeroException>(() => objDerivedA.StatMethod(2,0));
            //Assert.AreEqual(str, ex.Message);
        }
        [Test]
        [TestCase(5,0, "Attempted to divide by zero.")]
        public void DivideByZeroException_DivideMethod(int a,int b,string expected)
        {
            SimpleCalculator sSimpleCalculator = new SimpleCalculator();
            var ex=Assert.Throws<DivideByZeroException>(()=> sSimpleCalculator.Divide(a, b));
            //Assert.AreEqual(ex.Message, expected);
        }
    }
}