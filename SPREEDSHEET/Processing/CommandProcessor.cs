using System.Collections.Generic;
using static SpreedSheet.Processing.Operands;

namespace SpreedSheet.Processing
{
    public static class CommandProcessor
    {
        public static double Execute(Stack<Command> commandStack)
        {
            while (commandStack.Count > 1)
            {
                Operand operand2 = (Operand)commandStack.Pop();
                Operation operation = (Operation)commandStack.Pop();
                Operand operand1 = (Operand)commandStack.Pop();
                Operand result = operation.Execute(operand1, operand2);
                commandStack.Push(result);
            }
            Operand resultFinal = (Operand)commandStack.Pop();
            return resultFinal.GetValue();
        }
    }
}
