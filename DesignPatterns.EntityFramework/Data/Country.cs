

namespace DesignPatterns.EntityFramework.Data;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
