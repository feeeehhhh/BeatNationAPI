namespace BeatNationAPI.Models
{
    public class Producer
    {
        public Guid Id {get;set;}

        // Relação com User (Identity)
        public Guid UserId  {get;set;}
        public User? User {get;set;}
        public string? ArtistName {get;set;}
        public string? Bio {get;set;}
        public string? ProfileImageUrl {get;set;}
        public string? BannerUrl {get;set;}
        public string? Instagram {get;set;}
        public string? Spotfy {get;set;}
        public string? Youtube {get;set;}
        public string? IsVerified {get;set;}
        public string? CreatedAt {get;set;}
        public string? UpdatedAt {get;set;}

        //Referência aos beats
        public Beat? Beats {get;set;}

    }
}