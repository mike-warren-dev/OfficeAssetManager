using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OfficeAssetManager.Models;

public partial class Employee
{
    public Employee()
    {
        Assets = new HashSet<Asset>();
    }

    public int EmployeeId { get; set; }
    public int? ExternalSystemId { get; set; }
    public string DisplayName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int? SiteId { get; set; }

    [JsonIgnore]
    public virtual ICollection<Asset> Assets { get; set; }
}
