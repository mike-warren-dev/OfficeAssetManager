using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeAssetManager.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Assets = new HashSet<Asset>();
            DisplayName = $"{FirstName} {LastName}";
        }

        public int EmployeeId { get; set; }
        public int? ExternalSystemId { get; set; }
        public string DisplayName { get; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [Range(1, 49, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? SiteId { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
