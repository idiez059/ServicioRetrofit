namespace WebApiRestE2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public usuario()
        //{
        //    calorias = new HashSet<calorias>();
        //}

        [Key]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string foto { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<calorias> calorias { get; set; }
    }
}
