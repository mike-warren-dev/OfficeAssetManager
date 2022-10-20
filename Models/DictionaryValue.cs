namespace OfficeAssetManager.Models;

public partial class DictionaryValue
{
    public int ValueId { get; set; }
    public int? DictionaryId { get; set; }
    public string? DisplayName { get; set; }

    public virtual Dictionary? Dictionary { get; set; }
}
