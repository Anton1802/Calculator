using NUnit.Framework;
using System.Drawing.Text;
using C__MS_Calculator;

namespace C__MS_Calculator.Tests
{   
    [TestFixture]
    public class CalculatorTests
    {
        private CalculatorForm.Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorForm.Calculator();
        }

        [Test]
        public void AdditionTest()
        {
            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Add, 2);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 2);
            Assert.That(calculator.Calculate(), Is.EqualTo("4"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Add, -1);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 1);
            Assert.That(calculator.Calculate(), Is.EqualTo("0"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Add, 0);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 0);
            Assert.That(calculator.Calculate(), Is.EqualTo("0"));
        }

        [Test]
        public void SubstractionTest()
        {
            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Subtract, 5);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 3);
            Assert.That(calculator.Calculate(), Is.EqualTo("2"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Subtract, 0);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 4);
            Assert.That(calculator.Calculate(), Is.EqualTo("-4"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Subtract, -2);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, -2);
            Assert.That(calculator.Calculate(), Is.EqualTo("0"));
        }

        public void MultiplicationTest()
        {
            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Multiply, 3);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 3);
            Assert.That(calculator.Calculate(), Is.EqualTo("9"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Multiply, -2);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 2);
            Assert.That(calculator.Calculate(), Is.EqualTo("4"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Multiply, 0);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 5);
            Assert.That(calculator.Calculate(), Is.EqualTo("0"));
        }

        [Test]
        public void DivisionTest() 
        {
            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 10);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 2);
            Assert.That(calculator.Calculate(), Is.EqualTo("5"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 5);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, -1);
            Assert.That(calculator.Calculate(), Is.EqualTo("-5"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 0);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 3);
            Assert.That(calculator.Calculate(), Is.EqualTo("0"));

            calculator.ClearValues();
            calculator.ClearMemory();
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 0);
            calculator.AddValue(CalculatorForm.Operation_Enum.None, 0);
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate());
        }

        [Test]
        public void TestAdditionWithDecimals()
        {
            calculator.ClearValues();
            calculator.AddValue(CalculatorForm.Operation_Enum.Add, 1.5);
            calculator.AddValue(CalculatorForm.Operation_Enum.Add, 2.3);

            var result = calculator.Calculate();
            Assert.That(result, Is.EqualTo("3,8"));
        }

        [Test]
        public void TestSubtractionWithDecimals()
        {
            calculator.ClearValues();
            calculator.AddValue(CalculatorForm.Operation_Enum.Subtract, 5.5);
            calculator.AddValue(CalculatorForm.Operation_Enum.Subtract, 2.2);

            var result = calculator.Calculate();
            Assert.That(result, Is.EqualTo("3,3"));
        }

        [Test]
        public void TestMultiplicationWithDecimals()
        {
            calculator.ClearValues();
            calculator.AddValue(CalculatorForm.Operation_Enum.Multiply, 3.5);
            calculator.AddValue(CalculatorForm.Operation_Enum.Multiply, 2.0);

            var result = calculator.Calculate();
            Assert.That(result, Is.EqualTo("7"));
        }

        [Test]
        public void TestDivisionWithDecimals()
        {
            calculator.ClearValues();
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 7.5);
            calculator.AddValue(CalculatorForm.Operation_Enum.Divide, 2.5);

            var result = calculator.Calculate();
            Assert.That(result, Is.EqualTo("3"));
        }

        [Test]
        public void TestInvalidInput_ThrowsException()
        {
            Assert.Throws<FormatException>(() => calculator.AddValue(CalculatorForm.Operation_Enum.Add, double.Parse("invalid")));
        }

        [Test]
        public void TestEmptyInput_ThrowsException()
        {
            Assert.Throws<FormatException>(() => calculator.AddValue(CalculatorForm.Operation_Enum.Add, double.Parse("")));
        }

        [Test]
        public void TestNullInput_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => calculator.AddValue(CalculatorForm.Operation_Enum.Add, double.Parse(null)));
        }
    }
}
