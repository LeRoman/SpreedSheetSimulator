using static SpreedSheet.Processing.Operands;

namespace SpreedSheet
{
    public abstract class Operation : Command
    {
        public abstract ConstantOperand Execute(Operand operand1, Operand operand2);
    }

    public class AdditionOperation : Operation
    {
        static string addition = "+";

        public override ConstantOperand Execute(Operand operand1, Operand operand2)
        {
            double value1 = operand1.GetValue();
            double value2 = operand2.GetValue();
            double result = value1 + value2;
            return new ConstantOperand(result);
        }
        public static bool IsAddition(string token)
        {
            return addition.Equals(token);
        }
    }

    public class SubstractionOperation : Operation
    {
        static string substraction = "-";

        public override ConstantOperand Execute(Operand operand1, Operand operand2)
        {
            double value1 = operand1.GetValue();
            double value2 = operand2.GetValue();
            double result = value1 - value2;
            return new ConstantOperand(result);
        }
        public static bool IsSubstraction(string token)
        {
            return substraction.Equals(token);
        }
    }

    public class DivisionOperation : Operation
    {
        static string division = "/";

        public override ConstantOperand Execute(Operand operand1, Operand operand2)
        {
            double value1 = operand1.GetValue();
            double value2 = operand2.GetValue();
            double result = value1 / value2;
            return new ConstantOperand(result);
        }
        public static bool IsDivision(string token)
        {
            return division.Equals(token);
        }
    }

    public class MultiplicationOperation : Operation
    {
        static string multiplication = "*";

        public override ConstantOperand Execute(Operand operand1, Operand operand2)
        {
            double value1 = operand1.GetValue();
            double value2 = operand2.GetValue();
            double result = value1 * value2;
            return new ConstantOperand(result);
        }
        public static bool IsMultiplication(string token)
        {
            return multiplication.Equals(token);
        }
    }
}
