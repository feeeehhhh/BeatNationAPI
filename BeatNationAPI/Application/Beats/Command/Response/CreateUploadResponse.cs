namespace BeatNationAPI.Application.Beats.Command.Response
{
<<<<<<< HEAD
    public record CreateUploadResponse( string publicUrl);
=======
    public record CreateUploadResponse(
    string UploadUrl,
    Dictionary<string, string> UploadHeaders,
    string PublicUrl
    );
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
}