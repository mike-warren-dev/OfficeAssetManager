namespace OfficeAssetManager.Models;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    public int? ExternalSystemId { get; set; }
    public string DisplayName { get; set; } = null!;
    public string? SiteName { get; set; }
}
