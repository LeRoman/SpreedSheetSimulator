namespace SpreedSheet
{
    public static class Errors
    {
        public static string UnknownTokenError { get; } = "#Unknown token";
        public static string TextCellError { get; } = "#Text in  expr.";
        public static string EmptyCellError { get; } = "#Empty cell";
        public static string ParsingError { get; } = "#Error during cell parsing";
    }
}
