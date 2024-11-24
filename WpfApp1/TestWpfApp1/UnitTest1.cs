using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;
using WpfApp1;
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

            Assert.AreEqual(expected, objDerivedA.Passcheck(number1, number2).ToString());
            Assert.That(objDerivedA.Passcheck(number1, number2).ToString()== expected);


        }
        [Test]
        [TestCase("2", "3", "2")]
        public void Loginvalid_WithStringInput_InCorrectOutput(int number1, int number2, string expected)
        {
            /***We cannot use mock for Non-overridable members of DerivedA class which means directly on class
            instead use the "interface" option here IclassInterface 
            When are trying to use a Mock we definetly need respective Interface of that class.

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
            Assert.AreEqual(expected, objBaseA.Loginvalid(number1, number2).ToString());
        }
    }
}