using System;
using System.ComponentModel.DataAnnotations;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset_Category
    {
        [Key]
        public string? Category { get; set; }
    }
}
