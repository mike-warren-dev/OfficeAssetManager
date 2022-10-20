using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeAssetManager.Models
{
    public partial class Asset
    {
        public int AssetId { get; set; }
        public Guid? Guid { get; set; }
        public int? EmployeeId { get; set; }
        
        [Range(50, 149, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? AssetTypeId { get; set; }
        
        [Range(149, 199, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? AssetStatusId { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public string? RemovedBy { get; set; }
        public DateTime? RemovedDate { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
