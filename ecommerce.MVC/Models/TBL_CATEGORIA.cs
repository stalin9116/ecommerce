//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce.MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CATEGORIA()
        {
            this.TBL_PRODUCTO = new HashSet<TBL_PRODUCTO>();
        }
        [DisplayName("Nombre")]
        [StringLength(10)]
        [Required]
        public string cat_nombre { get; set; }
        [DisplayName("Id")]
        public short cat_id { get; set; }
        [DisplayName("Descripcion")]
        public string cat_descripcion { get; set; }
        [DisplayName("Estado")]
        public string cat_status { get; set; }
        [DisplayName("Fecha Creación")]
        public System.DateTime cat_fechacreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PRODUCTO> TBL_PRODUCTO { get; set; }
    }
}
