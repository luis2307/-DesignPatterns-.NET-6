namespace DesignPatternsAPP.Models.ViewModels
{
    public class ClientViewModel
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CountryId { get; set; }
        public string Country { get; set; } = null!;

    }
}
