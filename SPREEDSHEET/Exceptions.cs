using System;

namespace SpreedSheet
{

    public class UnknownTokenException : Exception
    {
       
    }

    public class TextCellException : Exception
    {

    }

    public class EmptyCellException : Exception
    {

    }

    public class NonExistentCellException : Exception
    {
        public NonExistentCellException(string message) : base(message)
        { }
    }
}