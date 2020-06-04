using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ecommerce.WebASP.Logica
{
    public class LogicaProducto
    {
        private static BDDCORDICARRITOEntities db = new BDDCORDICARRITOEntities();

        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.pro_status == "A"
                                                       ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXId(int codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.pro_status == "A"
                                                   && data.pro_id.Equals(codigo)
                                                       ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXCode(string codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.pro_status == "A"
                                                   && data.pro_codigo.Equals(codigo)
                                                       ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_status = "A";
                _infoProducto.pro_fechacreacion = DateTime.Now;
                db.TBL_PRODUCTO.Add(_infoProducto);

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_fechacreacion = DateTime.Now;

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }

        public static async Task<bool> deleteProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_fechacreacion = DateTime.Now;
                _infoProducto.pro_status = "I";
                //Eliminar de forma fisica delete from 
                //db.TBL_PRODUCTO.Remove(_infoProducto);
                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar productos");
            }
        }


    }
}