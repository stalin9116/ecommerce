using ecommerce.WebASP.Logica;
using ecommerce.WebASP.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.WebASP.WebForms.Administracion.Producto
{
    public partial class wfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                _taskProductos.Wait();
                var _listaProducto = _taskProductos.Result;


                loadProductos(_listaProducto);

            }
            UC_DatosEventos();
        }

        private void UC_DatosEventos()
        {
            GridView gridview = (GridView)this.UC_Datos1.FindControl("GridView1");
            gridview.RowCommand += new GridViewCommandEventHandler(Uc_Datos_RowCommand);
        }


        void Uc_Datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                //Encriptar
                Response.Redirect("wfmProductoNuevo.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "Eliminar")
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => LogicaProducto.getProductXId(int.Parse(codigo)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto != null)
                {
                    Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.deleteProduct(_infoProducto));
                    _taskSaveProduct.Wait();
                    var resultado = _taskSaveProduct.Result;
                    if (resultado)
                    {
                        Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                        _taskProductos.Wait();
                        var _listaProducto = _taskProductos.Result;
                        loadProductos(_listaProducto);
                        //Response.Write("<sript>alert('Registro Eliminado Correctamente'); </script>");
                    }
                }
            }
        }


        private void loadProductos(List<TBL_PRODUCTO> _listaProducto)
        {
            if (_listaProducto != null && _listaProducto.Count > 0)
            {
                UC_Datos1.loadData(_listaProducto.Select(data => new
                {
                    ID = data.pro_id,
                    CODIGO = data.pro_codigo,
                    NOMBRE = data.pro_nombre,
                    PRECIO_C = data.pro_preciocompra.ToString("0.00"),
                    PRECIO_V = data.pro_precioventa.ToString("0.00"),
                    STOCK_MIN = data.pro_stockminimo,
                    STOCK_MAX = data.pro_stockmaximo,
                    CATEGORIA = data.TBL_CATEGORIA.cat_nombre,
                    ESTADO = data.pro_status
                }).ToList());
            }
        }

        protected void imbBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar(ddlBuscar.SelectedValue);
        }

        private void Buscar(string op)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                List<TBL_PRODUCTO> _listaProducto = new List<TBL_PRODUCTO>();
                string datoaBuscar = txtBuscar.Text;

                switch (op)
                {
                    case "T":
                        Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                        _taskProductos.Wait();
                        _listaProducto = _taskProductos.Result;
                        loadProductos(_listaProducto);
                        break;
                    case "C":
                        Task<List<TBL_PRODUCTO>> _taskProductos2 = Task.Run(() => LogicaProducto.searchProductXCode(datoaBuscar));
                        _taskProductos2.Wait();
                        _listaProducto = _taskProductos2.Result;
                        loadProductos(_listaProducto);
                        break;
                    case "N":
                        Task<List<TBL_PRODUCTO>> _taskProductos3 = Task.Run(() => LogicaProducto.searchProductXNombre(datoaBuscar));
                        _taskProductos3.Wait();
                        _listaProducto = _taskProductos3.Result;
                        loadProductos(_listaProducto);
                        break;
                    case "CA":
                        Task<List<TBL_PRODUCTO>> _taskProductos4 = Task.Run(() => LogicaProducto.searchProductXCategoria(datoaBuscar));
                        _taskProductos4.Wait();
                        _listaProducto = _taskProductos4.Result;
                        loadProductos(_listaProducto);
                        break;
                }

            }

        }

        private void nuevoProduct()
        {
            Response.Redirect("wfmProductoNuevo.aspx", true);
        }

        protected void imbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            nuevoProduct();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevoProduct();
        }
    }
}