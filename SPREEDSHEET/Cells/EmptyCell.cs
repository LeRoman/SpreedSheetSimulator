namespace SpreedSheet
{
    public class EmptyCell : Cell
    {
        public EmptyCell(Table table) : base(table)
        {
            this.Value = "";
        }
    }
}
