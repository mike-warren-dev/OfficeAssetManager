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
        }

        public int EmployeeId { get; set; }
        public int? ExternalSystemId { get; set; }
        public string DisplayName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;
        
        [Required]
        public string LastName { get; set; } = null!;
        
        public int? SiteId { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
