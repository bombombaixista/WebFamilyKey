public class Tenant   // ✅ novo model
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class User     // ✅ já existia
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

    public int TenantId { get; set; }   // FK para Tenant
    public Tenant? Tenant { get; set; }
}
