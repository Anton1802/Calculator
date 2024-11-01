﻿using System.Globalization;
using System.Numerics;

namespace C__MS_Calculator
{
    public partial class CalculatorForm : Form
    {
        private bool equalsPressed = false;
        private bool specialBtnPressed = false;
        private Calculator calculator;

        public CalculatorForm()
        {
            InitializeComponent();

            calculator = new Calculator();
        }

        private void MC_Button_Click(object sender, EventArgs e)
        {
            calculator.ClearMemory();
        }

        private void MR_Button_Click(object sender, EventArgs e)
        {
            CalcOutputTextBox.Text = calculator.memory.ToString();
        }

        private void MS_Button_Click(object sender, EventArgs e)
        {
            calculator.memory = double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture);
        }

        private void MPlus_Button_Click(object sender, EventArgs e)
        {
            calculator.memory += double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture);
        }

        private void MMinus_Button_Click(object sender, EventArgs e)
        {
            calculator.memory -= double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture);
        }

        private void Backspace_Button_Click(object sender, EventArgs e)
        {
            if (CalcOutputTextBox.Text.Length > 1)
            {
                CalcOutputTextBox.Text = CalcOutputTextBox.Text.Remove(CalcOutputTextBox.Text.Length - 1);
            }
            else
            {
                CalcOutputTextBox.Text = "0";
            }
        }

        private void CE_Button_Click(object sender, EventArgs e)
        {
            CalcOutputTextBox.Text = "0";
        }

        private void C_Button_Click(object sender, EventArgs e)
        {
            calculator.ClearValues();
            calculator.ClearMemory();

            CalcOutputTextBox.Text = "0";
            CalcAnswerTextBox.Text = "";

            equalsPressed = false;
            specialBtnPressed = false;
        }

        private void ChangeSign_Button_Click(object sender, EventArgs e)
        {
            CalcOutputTextBox.Text = (double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture) * -1).ToString();
        }

        private void Sqrt_Button_Click(object sender, EventArgs e)
        {
            specialBtnPressed = true;

            CalcAnswerTextBox.Text += "(√" + CalcOutputTextBox.Text + ")";

            CalcOutputTextBox.Text = Math.Sqrt(double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture)).ToString();
        }

        private void Digits_Buttons_Click(object sender, EventArgs e)
        {
            string digit = ((Button)sender).Text;

            if (CalcOutputTextBox.Text == "0")
            {
                CalcOutputTextBox.Text = digit;
            }
            else
            {
                CalcOutputTextBox.Text += digit;
            }
        }

        private void Divide_Button_Click(object sender, EventArgs e)
        {
            if (equalsPressed)
            {
                CalcAnswerTextBox.Text = "";
                equalsPressed = false;
                calculator.ClearValues();
            }

            calculator.AddValue(Operation_Enum.Divide, double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture));

            if (specialBtnPressed)
            {
                CalcAnswerTextBox.Text += " ÷ ";
                specialBtnPressed = false;
            }
            else
            {
                CalcAnswerTextBox.Text += CalcOutputTextBox.Text += " ÷ ";
            }

            CalcOutputTextBox.Text = "0";
        }

        private void Percentage_Button_Click(object sender, EventArgs e)
        {
            specialBtnPressed = true;

            CalcAnswerTextBox.Text += "(" + CalcOutputTextBox.Text + " / 100)";

            CalcOutputTextBox.Text = (double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture) / 100).ToString();
        }

        private void Multiply_Button_Click(object sender, EventArgs e)
        {
            if (equalsPressed)
            {
                CalcAnswerTextBox.Text = "";
                equalsPressed = false;
                calculator.ClearValues();
            }

            calculator.AddValue(Operation_Enum.Multiply, double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture));

            if (specialBtnPressed)
            {
                CalcAnswerTextBox.Text += " × ";
                specialBtnPressed = false;
            }
            else
            {
                CalcAnswerTextBox.Text += CalcOutputTextBox.Text += " × ";
            }

            CalcOutputTextBox.Text = "0";
        }

        private void Reciprocal_Button_Click(object sender, EventArgs e)
        {
            specialBtnPressed = true;

            CalcAnswerTextBox.Text += "(1 / " + CalcOutputTextBox.Text + ")";

            CalcOutputTextBox.Text = (1 / double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture)).ToString();
        }

        private void Minus_Button_Click(object sender, EventArgs e)
        {
            if (equalsPressed)
            {
                CalcAnswerTextBox.Text = "";
                equalsPressed = false;
                calculator.ClearValues();
            }

            calculator.AddValue(Operation_Enum.Subtract, double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture));

            if (specialBtnPressed)
            {
                CalcAnswerTextBox.Text += " - ";
                specialBtnPressed = false;
            }
            else
            {
                CalcAnswerTextBox.Text += CalcOutputTextBox.Text += " - ";
            }

            CalcOutputTextBox.Text = "0";
        }

        private void Decimal_Button_Click(object sender, EventArgs e)
        {
            if (!CalcOutputTextBox.Text.Contains("."))
            {
                CalcOutputTextBox.Text += ".";
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (equalsPressed)
            {
                CalcAnswerTextBox.Text = "";
                equalsPressed = false;
                calculator.ClearValues();
            }

            calculator.AddValue(Operation_Enum.Add, double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture));

            if (specialBtnPressed)
            {
                CalcAnswerTextBox.Text += " + ";
                specialBtnPressed = false;
            }
            else
            {
                CalcAnswerTextBox.Text += CalcOutputTextBox.Text += " + ";
            }

            CalcOutputTextBox.Text = "0";
        }

        private void Equals_Button_Click(object sender, EventArgs e)
        {
            if (calculator.ValueCount() > 0 && !equalsPressed)
            {
                equalsPressed = true;

                calculator.AddValue(Operation_Enum.None, double.Parse(CalcOutputTextBox.Text, CultureInfo.InvariantCulture));

                if (specialBtnPressed)
                {
                    CalcAnswerTextBox.Text += " = ";
                    specialBtnPressed = false;
                }
                else
                {
                    CalcAnswerTextBox.Text += CalcOutputTextBox.Text + " = ";
                }

                CalcOutputTextBox.Text = calculator.Calculate();
            }
        }

        public enum Operation_Enum
        {
            None = 0,
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4
        }

        public class Calculator
        {
            private double memoryNumber;
            private List<KeyValuePair<Operation_Enum, double>> prevValues;

            public Calculator()
            {
                memoryNumber = 0;
                prevValues = new List<KeyValuePair<Operation_Enum, double>>();
            }

            public void AddValue(Operation_Enum operation, double value)
            {
                prevValues.Add(new KeyValuePair<Operation_Enum, double>(operation, value));
            }

            public int ValueCount()
            {
                return prevValues.Count;
            }

            public string Calculate()
            {
                if (prevValues.Count == 0)
                {
                    throw new InvalidOperationException("No values to calculate");
                }

                double result = prevValues[0].Value;

                for (int i = 1; i < prevValues.Count; ++i)
                {
                    switch (prevValues[i - 1].Key)
                    {
                        case Operation_Enum.Add:
                            result += prevValues[i].Value;
                            break;
                        case Operation_Enum.Subtract:
                            result -= prevValues[i].Value;
                            break;
                        case Operation_Enum.Multiply:
                            result *= prevValues[i].Value;
                            break;
                        case Operation_Enum.Divide:
                            if (prevValues[i].Value == 0)
                            {
                                throw new DivideByZeroException("Division by zero");
                            }
                            result /= prevValues[i].Value;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operation");
                    }
                }

                return result.ToString();
            }

            public double memory
            {
                get
                {
                    return memoryNumber;
                }
                set
                {
                    memoryNumber = value;
                }
            }

            public void ClearValues()
            {
                prevValues.Clear();
            }

            public void ClearMemory()
            {
                memoryNumber = 0;
            }
        }
    }
}