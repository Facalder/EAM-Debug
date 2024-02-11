using System;
using System.ComponentModel.DataAnnotations;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset_Classification
    {
        [Key]
        public string? Classification { get; set; }
    }
}
