using SpreedSheet.Processing;
using System;
using System.Collections.Generic;
using static SpreedSheet.Processing.Operands;

namespace SpreedSheet
{
    public class ExpressionCell : Cell
    {
        readonly Stack<Command> commandStack = new Stack<Command>();
        readonly List<Cell> dependsOn = new List<Cell>();
        string temp;
        readonly List<char> operationsList = new List<char> { '*', '/', '+', '-' };

        public ExpressionCell(string value, Table table) : base(table)
        {
            ParseExpression(value);
        }

        void ParseExpression(string value)

        {
            string expression = value.Substring(1);

            try
            {
                for (int i = 0; i < expression.Length; i++)
                {
                    
                    if (operationsList.Contains(expression[i]))
                    {
                        if (!String.IsNullOrEmpty(temp))
                        {
                            commandStack.Push(Command.NewCommand(temp,GetTable()));
                            temp = "";
                        }
                        commandStack.Push(Command.NewCommand(expression[i].ToString(), GetTable()));
                        continue;
                    }

                    temp += expression[i];
                    if(i==expression.Length-1) commandStack.Push(Command.NewCommand(temp, GetTable()));
                }
            }

            catch (UnknownTokenException)
            {
                Value=Errors.UnknownTokenError;
                base.Compute();
            }

        }

        public void Resolve()
        {
            foreach (Command command in commandStack)
            {
                if (command is ReferenceOperand)
                {
                    string reference = ((ReferenceOperand)command).GetReference();

                    Cell referenceCell = GetTable().GetCell(reference);
                    dependsOn.Add(referenceCell);
                }
            }
        }

        internal override void Compute()
        {
            try
            {
                if (!(IsComputed()))
                {

                    foreach (var cell in dependsOn)
                    {
                        if (cell is TextCell)
                            throw new TextCellException();
                        if (cell is EmptyCell)
                            throw new EmptyCellException();

                        cell.Compute();
                    }

                    double result = CommandProcessor.Execute(commandStack);
                    Value=Convert.ToString(result);
                    base.Compute();
                }
            }
            catch (TextCellException) { Value=Errors.TextCellError; }
            catch (EmptyCellException) { Value=Errors.EmptyCellError; }
        }

        public static bool IsExpression(string value)
        {
            return (value[0] == '=');
        }
    }
}
