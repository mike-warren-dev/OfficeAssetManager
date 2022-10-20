namespace OfficeAssetManager.Models;

public class AssetDTO
{
    public Guid? Guid { get; set; }
    public string? AssetTypeDisplayName { get; set; }
    public string? AssignedTo { get; set; }
}
