namespace src.features.Beats.Command.Response
{
    public record CreateUploadResponse(
    string UploadUrl,
    Dictionary<string, string> UploadHeaders,
    string PublicUrl
    );
}