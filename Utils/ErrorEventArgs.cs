namespace Lab01Stasiuk.Utils
{
    class ErrorEventArgs
    {
        public string Message { get; set; }

        public ErrorEventArgs(string message)
        {
            Message = message;
        }
    }
}
