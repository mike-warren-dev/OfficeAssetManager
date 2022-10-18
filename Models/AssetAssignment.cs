using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class AssetAssignment
    {
        public int AssetAssignmentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AssetId { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public string? RemovedBy { get; set; }
        public DateTime? RemovedDate { get; set; }

        public virtual Asset? Asset { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
