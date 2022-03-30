using System;
using System.Text.RegularExpressions;

namespace SpreedSheet.Processing
{
    public class Operands
    {
        public abstract class Operand : Command
        {
            public abstract double GetValue();
        }

        public class ReferenceOperand : Operand
        {
            readonly string reference;
            readonly Table table;
            double value;
            public ReferenceOperand(string token, Table table)
            {
                reference = token;
                this.table = table;
            }

            public string GetReference()
            {
                return this.reference;
            }

            public override double GetValue()
            {

                Cell cell = table.GetCell(GetReference());
                if (cell.IsComputed())
                {
                    this.value = Convert.ToDouble(cell.Value);

                }
                return value;
            }
            public static bool IsReference(string token)
            {
                Regex letters = new Regex(@"^[A-Z]{1}[0-9]{1}$");
                return letters.IsMatch(token);
            }

        }

        public class ConstantOperand : Operand
        {
            readonly double value;

            public ConstantOperand(string token)
            {
                value = Convert.ToDouble(token);
            }

            public ConstantOperand(double value)
            {
                this.value = value;
            }

            public override double GetValue()
            {
                return value;
            }
        }
    }
}
