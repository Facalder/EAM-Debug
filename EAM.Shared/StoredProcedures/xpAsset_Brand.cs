using System;
using System.ComponentModel.DataAnnotations;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset_Brand
    {
        [Key]
        public string? Brand { get; set; }
    }
}
