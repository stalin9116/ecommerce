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
    
    public partial class TBL_PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PRODUCTO()
        {
            this.TBL_DETALLEPEDIDO = new HashSet<TBL_DETALLEPEDIDO>();
        }
    
        public int pro_id { get; set; }
        public string pro_codigo { get; set; }
        public string pro_nombre { get; set; }
        public decimal pro_preciocompra { get; set; }
        public decimal pro_precioventa { get; set; }
        public string pro_imagen { get; set; }
        public string pro_descripcion { get; set; }
        public int pro_stockminimo { get; set; }
        public int pro_stockmaximo { get; set; }
        public System.DateTime pro_fechacreacion { get; set; }
        public string pro_status { get; set; }
        public Nullable<short> cat_id { get; set; }
    
        public virtual TBL_CATEGORIA TBL_CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DETALLEPEDIDO> TBL_DETALLEPEDIDO { get; set; }
    }
}