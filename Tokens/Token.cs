namespace Assets.Package.Tokens
{
    public abstract class Token
    {
        public TokenData Data { get; }
        public bool IsInUse { get; set; }

        public Token(TokenData data)
        {
            Data = data;
        }
    }
}