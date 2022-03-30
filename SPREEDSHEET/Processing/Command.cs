using System;
using static SpreedSheet.Processing.Operands;

namespace SpreedSheet
{
    public abstract class Command
    {
        public static Command NewCommand(String token, Table table)
        {
            if (NumberCell.IsNumber(token))
            {
                return new ConstantOperand(token);
            }

            if (ReferenceOperand.IsReference(token))
            {
                return new ReferenceOperand(token,table);
            }

            if (AdditionOperation.IsAddition(token))
            {
                return new AdditionOperation();
            }

            if (SubstractionOperation.IsSubstraction(token))
            {
                return new SubstractionOperation();
            }

            if (MultiplicationOperation.IsMultiplication(token))
            {
                return new MultiplicationOperation();
            }

            if (DivisionOperation.IsDivision(token))
            {
                return new DivisionOperation();
            }

            throw new UnknownTokenException();
        }
    }
}
