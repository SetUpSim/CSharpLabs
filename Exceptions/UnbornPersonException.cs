namespace Lab01Stasiuk.Exceptions
{
    class UnbornPersonException : ArgumentException
    {
        public UnbornPersonException(string message) : base(message)
        {
        }
    }
}