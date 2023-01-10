namespace DesignPatterns.EntityFramework.Data;

public partial class Client
{
    public Guid ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public int? CountryId { get; set; }

    public string ClientEmail { get; set; } = null!;

    public virtual Country? Country { get; set; }
}
