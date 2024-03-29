namespace Lab01Stasiuk.Exceptions
{
    class EmailFormatException : FormatException
    {
        public EmailFormatException(string message) : base(message)
        {
        }
    }
}