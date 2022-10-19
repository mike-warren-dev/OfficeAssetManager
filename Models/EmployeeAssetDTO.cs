namespace OfficeAssetManager.Models
{
    public class EmployeeAssetDTO
    {
        public EmployeeAssetDTO()
        {
            Assets = new List<AssetDTO>();
        }
        public string EmployeeDisplayName { get; set; }
        public List<AssetDTO> Assets { get; set; }
    }
}
