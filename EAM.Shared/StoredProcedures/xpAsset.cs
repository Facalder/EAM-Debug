using System;
using System.ComponentModel.DataAnnotations;

namespace EAM.Shared.StoredProcedures
{
    public class xpAsset
    {
        [Key]
        public string? Company_Id { get; set; }
        public string? Id { get; set; }
        public string? Category { get; set; }
        public string? Prefix { get; set; }
        public string? Class { get; set; }
        public string? Serial_Number { get; set; }
        public string? Name { get; set; }
        public string? Classification { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Fuel { get; set; }
        public string? Emission { get; set; }
        public int? Production_Year { get; set; }
        public string? Type { get; set; }
        public string? Specifications { get; set; }
        public string? Item_Condition { get; set; }
        public DateTime? Purchase_Date { get; set; }
        public decimal? Price { get; set; }
        public string? Supplier_Id { get; set; }
        public string? Warranty { get; set; }
        public DateTime? Warranty_Exp_Date { get; set; }
        public string? Insurance { get; set; }
        public DateTime? Insurance_Exp_Date { get; set; }
        public DateTime? Resale_Date { get; set; }
        public decimal? Resale_Price { get; set; }
        public int? Hours_Meter { get; set; }
        public string? Status { get; set; }
    }
}
