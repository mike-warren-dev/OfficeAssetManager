using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class Tempdictionaryvalue
    {
        public int ValueId { get; set; }
        public int? DictionaryId { get; set; }
        public string? DisplayName { get; set; }
    }
}
