using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class DictionaryValue
    {
        public int DictionaryValueId { get; set; }
        public int SysValue { get; set; }
        public int DictionaryId { get; set; }
        public string DisplayName { get; set; } = null!;

        public virtual Dictionary Dictionary { get; set; } = null!;
    }
}
