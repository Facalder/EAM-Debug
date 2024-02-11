using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset_Tree
    {
        public string? Parent_Id { get; set; }
        public string? Id { get; set; }
        public int? Level { get; set; }
        public string? Name { get; set; }
        public string? Indent_Name { get; set; }

        [JsonIgnore, NotMapped]
        [ForeignKey("Id")]
        public virtual ICollection<xpAsset_Tree>? xpAsset_Trees { get; set; } = new List<xpAsset_Tree>();

        //public xpAsset_Tree()
        //{
        //    xpAsset_Trees = new List<xpAsset_Tree>();
        //}

    }
}
