using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculator
    {
        private decimal _numA;
        private decimal _numB;
        private Dictionary<string, string> _options;
        private string _selectedOption;

        public Calculator() {
            _options = this.createOptions();
            _selectedOption = null;

        }

       

        public void Start() {
            Console.WriteLine("Console Calculator in c#");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");

            // Ask the user to type the first number.
            Console.WriteLine("Type a number, and then press Enter");
            _numA = Convert.ToDecimal(Console.ReadLine());

            // Ask the user to type the second number.
            Console.WriteLine("Type another number, and then press Enter");
            _numB = Convert.ToDecimal(Console.ReadLine());

            displayOptions();
            bool optionSuccess = selectOption();
            if (!optionSuccess) {
                return;
            }

            (decimal, string) result = calculateResult();
            

            Console.Write($"Your result: {_numA} {result.Item2} {_numB} = {result.Item1}");



        }

        private Dictionary<string, string> createOptions() { 
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("a", "Add");
            options.Add("s", "Subtract");
            options.Add("m", "Multiply");
            options.Add("d", "Divide");
            return options;
        }

        private void displayOptions() {
            Console.WriteLine("Choose an option from the following list");
            foreach (var option in _options) { 
                Console.WriteLine($"{option.Key} - {option.Value}");
            }
        }

        private bool selectOption() {
            _selectedOption = null;
            Action<string> getInput = (message) => {
                Console.Write(message);
                _selectedOption = Console.ReadLine();
                
            };

            Action writeSadMessage = () => Console.WriteLine("I guess you don't want to use the calculator after all :(");

            int maxAsk = 5;
            for (int i = 0; i < maxAsk; i++) {
                getInput("Your Option? ");
                if (_selectedOption != null) {
                    break;
                }
            }

            while (_selectedOption == "d" && _numB == 0) {
                Console.Write("Enter a non-zero divisor: ");
                _numB = Convert.ToDecimal(Console.ReadLine());
            }

            if (_selectedOption == null) {
                writeSadMessage();
                return false;
            }

            if (!_options.ContainsKey(_selectedOption)) {
                writeSadMessage();
                return false;
            }

            return true;           

        }

        private (decimal, string) calculateResult() {

            decimal value = 0M;
            string symbol = "";

            switch (_selectedOption) {

                case "a":
                    value = _numA + _numB;
                    symbol = "+";
                    break;

                case "s":
                    value = _numA - _numB;
                    symbol = "-";
                    break;

                case "m":
                    value = _numA * _numB;
                    symbol = "*";
                    break;
                case "d":                    
                    value = _numA / _numB;
                    symbol = "/";
                    break;

            }

            return (value, symbol);

        
        }
    }
}
