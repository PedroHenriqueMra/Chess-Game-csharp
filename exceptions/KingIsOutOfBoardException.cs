namespace ChessGame.Exceptions
{
    [System.Serializable]
    public class KingIsOutOfBoardException : System.Exception
    {
        public KingIsOutOfBoardException() { }
        public KingIsOutOfBoardException(string message) : base(message) { }
        public KingIsOutOfBoardException(string message, System.Exception inner) : base(message, inner) { }
        protected KingIsOutOfBoardException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } 
}
