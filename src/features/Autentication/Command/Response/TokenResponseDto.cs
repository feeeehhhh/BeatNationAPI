namespace src.features.Autentication.Command.Response
{
    public class TokenResponseDto
    {
        public string? AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string? RefreshToken { get; set; }
    }
}