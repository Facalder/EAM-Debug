using System;
using System.ComponentModel.DataAnnotations;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset_Group
    {
        [Key]
        public string? Id { get; set; }
        public string? Description { get; set; }
        public string? Stream { get; set; }
    }
}
