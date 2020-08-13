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

    public partial class TBL_CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CLIENTE()
        {
            this.TBL_PEDIDO = new HashSet<TBL_PEDIDO>();
            this.TBL_DIRECCIONES = new HashSet<TBL_DIRECCIONES>();
        }

        [DisplayName("Id")]
        public long cli_id { get; set; }
        [DisplayName("Identificación")]
        public string cli_identificacion { get; set; }
        [DisplayName("Tipo")]
        public string cli_tipoidentificacion { get; set; }
        [DisplayName("Apellidos")]
        public string cli_apellidos { get; set; }
        [DisplayName("Nombres")]
        public string cli_nombres { get; set; }
        [DisplayName("Genero")]
        public string cli_genero { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public System.DateTime cli_fechanacimiento { get; set; }
        [DisplayName("Telefono")]
        public string cli_telefono { get; set; }
        [DisplayName("Celular")]
        public string cli_celurar { get; set; }
        [DisplayName("Correo")]
        public string cli_email { get; set; }
        [DisplayName("Estado")]
        public string cli_status { get; set; }
        [DisplayName("Fecha Creación")]
        public System.DateTime cli_fechacreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PEDIDO> TBL_PEDIDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DIRECCIONES> TBL_DIRECCIONES { get; set; }
    }
}
