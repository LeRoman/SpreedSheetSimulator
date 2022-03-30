namespace SpreedSheet
{
    public class ErrorCell : Cell
    {
        public ErrorCell(Table table) : base(table)
        {
            Value = Errors.ParsingError;
        }

    }
}
