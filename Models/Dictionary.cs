using System;
using System.Collections.Generic;

namespace OfficeAssetManager.Models
{
    public partial class Dictionary
    {
        public Dictionary()
        {
            DictionaryValues = new HashSet<DictionaryValue>();
        }

        public int DictionaryId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<DictionaryValue> DictionaryValues { get; set; }
    }
}
