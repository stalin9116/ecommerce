using ecommerce.WebASP.Logica;
using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ecommerce.WebASP.WebForms.Administracion.Producto
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int idProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProducto(idProducto);
                }
            }
        }

        private void loadProducto(int idProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => LogicaProducto.getProductXId(idProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                lblId.Text = _infoProducto.pro_id.ToString();
                txtCodigo.Text = _infoProducto.pro_codigo;
                UC_Categoria1.DropDownList.SelectedValue = _infoProducto.cat_id.ToString();
                txtNombre.Text = _infoProducto.pro_nombre;
                txtDescripcion.Text = _infoProducto.pro_descripcion;
                txtPrecioCompra.Text = _infoProducto.pro_preciocompra.ToString();
                txtPrecioVenta.Text = _infoProducto.pro_precioventa.ToString();
                txtStockMinimo.Text = _infoProducto.pro_stockminimo.ToString();
                txtStockMaximo.Text = _infoProducto.pro_stockmaximo.ToString();
            }
        }


        private void newProduct()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockMaximo.Text = "";
            txtStockMinimo.Text = "";
            UC_Categoria1.DropDownList.SelectedIndex = 0;
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }

        protected void imbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();
        }

        private void saveProduct()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                //_infoProducto.pro_id = 100;
                _infoProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                _infoProducto.pro_codigo = txtCodigo.Text;
                _infoProducto.pro_nombre = txtNombre.Text;
                _infoProducto.pro_descripcion = txtDescripcion.Text;

                //imagen

                if (FileUploadProducto.HasFile)
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        try
                        {
                            if (FileUploadProducto.PostedFile.ContentType == "image/png" || FileUploadProducto.PostedFile.ContentType == "image/jpeg")
                            {
                                if (FileUploadProducto.PostedFile.ContentLength < 100000)
                                {
                                    string nombreArchivo = txtCodigo.Text + ".jpg";
                                    FileUploadProducto.SaveAs(Server.MapPath("~/images/products/") + nombreArchivo);
                                }
                                else
                                {
                                    lblMensaje.Text = "El tamaño máximo de la imagen es de 100 kb";
                                }
                            }
                            else
                            {
                                lblMensaje.Text = "Solo se aceptan imagen de tipo Png y Jpeg";
                            }
                        }
                        catch (Exception)
                        {

                            lblMensaje.Text = "Error al cargar la imagen de producto. ";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "El campo codigo de producto es obligatorio para la carga de imagen";
                    }
                }


                _infoProducto.pro_imagen = "~/images/products/" + txtCodigo.Text + ".jpg";


                _infoProducto.pro_preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                _infoProducto.pro_precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                _infoProducto.pro_stockminimo = Convert.ToInt32(txtStockMinimo.Text);
                _infoProducto.pro_stockmaximo = Convert.ToInt32(txtStockMaximo.Text);
                Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.saveProduct(_infoProducto));
                _taskSaveProduct.Wait();
                var resultado = _taskSaveProduct.Result;
                if (resultado)
                {
                    lblMensaje.Text = "Registro Guardado Correctamente";
                    newProduct();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;

            }
        }

        private void updateProduct()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => LogicaProducto.getProductXId(int.Parse(lblId.Text)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto != null)
                {
                    _infoProducto.pro_id = int.Parse(lblId.Text);
                    _infoProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                    _infoProducto.pro_codigo = txtCodigo.Text;
                    _infoProducto.pro_nombre = txtNombre.Text;
                    _infoProducto.pro_descripcion = txtDescripcion.Text;

                    //imagen
                    if (FileUploadProducto.HasFile)
                    {
                        if (!string.IsNullOrEmpty(txtCodigo.Text))
                        {
                            try
                            {
                                if (FileUploadProducto.PostedFile.ContentType == "image/png" || FileUploadProducto.PostedFile.ContentType == "image/jpeg")
                                {
                                    if (FileUploadProducto.PostedFile.ContentLength < 100000)
                                    {
                                        string nombreArchivo = txtCodigo.Text + ".jpg";
                                        FileUploadProducto.SaveAs(Server.MapPath("~/images/products/") + nombreArchivo);
                                        
                                    }
                                    else
                                    {
                                        lblMensaje.Text = "El tamaño máximo de la imagen es de 100 kb";
                                    }
                                }
                                else
                                {
                                    lblMensaje.Text = "Solo se aceptan imagen de tipo Png y Jpeg";
                                }
                            }
                            catch (Exception)
                            {

                                lblMensaje.Text = "Error al cargar la imagen de producto. ";
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "El campo codigo de producto es obligatorio para la carga de imagen";
                        }
                    }


                    _infoProducto.pro_imagen = "~/images/products/" + txtCodigo.Text + ".jpg";

                    _infoProducto.pro_preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    _infoProducto.pro_precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                    _infoProducto.pro_stockminimo = Convert.ToInt32(txtStockMinimo.Text);
                    _infoProducto.pro_stockmaximo = Convert.ToInt32(txtStockMaximo.Text);
                    Task<bool> _taskSaveProduct = Task.Run(() => LogicaProducto.updateProduct(_infoProducto));
                    _taskSaveProduct.Wait();
                    var resultado = _taskSaveProduct.Result;
                    if (resultado)
                    {
                        lblMensaje.Text = "Registro Modificado Correctamente";
                        Response.Redirect("wfmProductoLista.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;

            }
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                updateProduct();

            }
            else
            {
                saveProduct();
            }
        }

        protected void imbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                updateProduct();

            }
            else
            {
                saveProduct();
            }
        }
    }
}