using System;

namespace Calculator
{
    public class CalculatorEngine
    {
        public double FirstNumber { get; private set; } = 0;
        public double SecondNumber { get; private set; } = 0;
        public string Operation { get; private set; } = "";
        public bool IsNewNumber { get; private set; } = true;

        public string Display { get; private set; } = "0";

        public void InputNumber(string num)
        {
            if (IsNewNumber)
            {
                Display = num;
                IsNewNumber = false;
            }
            else
            {
                Display += num;
            }
        }

        public void InputDecimal()
        {
            if (IsNewNumber)
            {
                Display = "0.";
                IsNewNumber = false;
            }
            else if (!Display.Contains("."))
            {
                Display += ".";
            }
        }

        public void SetOperation(string op)
        {
            FirstNumber = double.Parse(Display);
            Operation = op;
            IsNewNumber = true;
        }

        public void Clear()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = "";
            IsNewNumber = true;
            Display = "0";
        }

        public void ClearEntry()
        {
            Display = "0";
            IsNewNumber = true;
        }

        public void Calculate()
        {
            SecondNumber = double.Parse(Display);

            switch (Operation)
            {
                case "+":
                    FirstNumber += SecondNumber;
                    break;
                case "-":
                    FirstNumber -= SecondNumber;
                    break;
                case "*":
                    FirstNumber *= SecondNumber;
                    break;
                case "/":
                    if (SecondNumber == 0)
                        throw new DivideByZeroException("Cannot divide by zero.");
                    FirstNumber /= SecondNumber;
                    break;
            }

            Display = FirstNumber.ToString();
            Operation = "";
            IsNewNumber = true;
        }
    }
}
