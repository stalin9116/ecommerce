
using ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ecommerce.WebASP.Logica
{
    public class LogicaCategoria
    {
        private static BDDCORDICARRITOEntities db = new BDDCORDICARRITOEntities();

        public static async Task<List<TBL_CATEGORIA>> getAllCategory()
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.cat_status == "A"
                                                       ).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<TBL_CATEGORIA> getCategoryXId(int codigo)
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.cat_status == "A"
                                                   && data.cat_id.Equals(codigo)
                                                       ).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }


        public static async Task<bool> saveProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.cat_status = "A";
                _infoCategoria.cat_fechacreacion = DateTime.Now;
                db.TBL_CATEGORIA.Add(_infoCategoria);

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<bool> updateProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.cat_fechacreacion = DateTime.Now;

                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

        public static async Task<bool> deleteProduct(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.cat_fechacreacion = DateTime.Now;
                _infoCategoria.cat_status = "I";
                //Eliminar de forma fisica delete from 
                //db.TBL_CATEGORIA.Remove(_infoCategoria);
                //Actualizar Contexto Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar categoria");
            }
        }

    }
}