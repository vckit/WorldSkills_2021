namespace WorldSkills.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegionCodes
    {
        [Column("Region name (EN)")]
        [StringLength(50)]
        public string Region_name__EN_ { get; set; }

        [Column("Region name (RU)")]
        [StringLength(50)]
        public string Region_name__RU_ { get; set; }

        [Column("Subject Code")]
        public int? Subject_Code { get; set; }

        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [Column("OKATO Code")]
        public int? OKATO_Code { get; set; }

        [Column("ISO 3166-2")]
        [StringLength(50)]
        public string ISO_3166_2 { get; set; }
    }
}
