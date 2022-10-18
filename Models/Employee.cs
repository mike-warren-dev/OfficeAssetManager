using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AssetAssignments = new HashSet<AssetAssignment>();
        }

        public int EmployeeId { get; set; }
        public int? ExternalSystemId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? SiteId { get; set; }

        public virtual ICollection<AssetAssignment> AssetAssignments { get; set; }
    }
}
