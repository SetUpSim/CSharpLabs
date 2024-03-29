namespace Lab01Stasiuk.Exceptions
{
    class TooOldPersonException : ArgumentException
    {
        public TooOldPersonException(string message) : base(message)
        {
        }
    }
}