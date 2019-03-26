namespace WebApiRestE2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class alimentos
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public alimentos()
        //{
        //    calorias1 = new HashSet<calorias>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public int calorias { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<calorias> calorias1 { get; set; }
    }
}
