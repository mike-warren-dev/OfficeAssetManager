using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class TempAsset
    {
        public int AssetId { get; set; }
        public Guid? Guid { get; set; }
        public int? EmployeeId { get; set; }
        public int? AssetTypeId { get; set; }
        public int? AssetStatusId { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public string? RemovedBy { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
