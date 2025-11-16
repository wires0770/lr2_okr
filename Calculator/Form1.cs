using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";
        private bool isNewNumber = true;
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (textBoxDisplay.Text == "0" || isNewNumber)
            {
                textBoxDisplay.Text = button.Text;
                isNewNumber = false;
            }
            else
            {
                textBoxDisplay.Text += button.Text;
            }

            isOperationPerformed = false;
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!isOperationPerformed && !isNewNumber)
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    CalculateResult();
                }

                firstNumber = double.Parse(textBoxDisplay.Text);
                operation = button.Text;
                isNewNumber = true;
                isOperationPerformed = true;
            }
            else if (isOperationPerformed)
            {
                operation = button.Text;
            }
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !isNewNumber)
            {
                CalculateResult();
                operation = "";
                isNewNumber = true;
            }
        }

        private void CalculateResult()
        {
            try
            {
                secondNumber = double.Parse(textBoxDisplay.Text);

                switch (operation)
                {
                    case "+":
                        firstNumber += secondNumber;
                        break;
                    case "-":
                        firstNumber -= secondNumber;
                        break;
                    case "*":
                        firstNumber *= secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Cannot divide by zero!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        firstNumber /= secondNumber;
                        break;
                }

                textBoxDisplay.Text = firstNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearCalculator();
            }
        }

        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                textBoxDisplay.Text = "0.";
                isNewNumber = false;
            }
            else if (!textBoxDisplay.Text.Contains("."))
            {
                textBoxDisplay.Text += ".";
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearCalculator();
        }

        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "0";
            isNewNumber = true;
        }

        private void ClearCalculator()
        {
            textBoxDisplay.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            isNewNumber = true;
            isOperationPerformed = false;
        }

        // Обработка нажатия клавиш клавиатуры
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    ButtonNumber_Click(button0, EventArgs.Empty);
                    return true;
                case Keys.D1:
                case Keys.NumPad1:
                    ButtonNumber_Click(button1, EventArgs.Empty);
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    ButtonNumber_Click(button2, EventArgs.Empty);
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    ButtonNumber_Click(button3, EventArgs.Empty);
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    ButtonNumber_Click(button4, EventArgs.Empty);
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    ButtonNumber_Click(button5, EventArgs.Empty);
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    ButtonNumber_Click(button6, EventArgs.Empty);
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    ButtonNumber_Click(button7, EventArgs.Empty);
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    ButtonNumber_Click(button8, EventArgs.Empty);
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    ButtonNumber_Click(button9, EventArgs.Empty);
                    return true;
                case Keys.Add:
                    ButtonOperator_Click(buttonAdd, EventArgs.Empty);
                    return true;
                case Keys.Subtract:
                    ButtonOperator_Click(buttonSubtract, EventArgs.Empty);
                    return true;
                case Keys.Multiply:
                    ButtonOperator_Click(buttonMultiply, EventArgs.Empty);
                    return true;
                case Keys.Divide:
                    ButtonOperator_Click(buttonDivide, EventArgs.Empty);
                    return true;
                case Keys.Enter:
                    ButtonEquals_Click(buttonEquals, EventArgs.Empty);
                    return true;
                case Keys.Decimal:
                case Keys.OemPeriod:
                    ButtonDecimal_Click(buttonDecimal, EventArgs.Empty);
                    return true;
                case Keys.Escape:
                    ButtonClear_Click(buttonClear, EventArgs.Empty);
                    return true;
                case Keys.Delete:
                    ButtonClearEntry_Click(buttonClearEntry, EventArgs.Empty);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}