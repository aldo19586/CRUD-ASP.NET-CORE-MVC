using CRUDCORE.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        Conexion cn = new Conexion();
        public List<ContactoModel> Listar()
        {
            var oList = new List<ContactoModel>();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) {
                        oList.Add(new ContactoModel()
                        {
                            IdContacto =Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER", conexion);
                cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {

            bool rpta;

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDAR", conexion);
           
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex) {
                string error = ex.Message;
                rpta = false;
            
            }


            return rpta;

        }
        public bool Editar(ContactoModel oContacto)
        {

            bool rpta;

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;

            }


            return rpta;

        }
        public bool Eliminar(int IdContacto)
        {

            bool rpta;

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR", conexion);
                    cmd.Parameters.AddWithValue("@IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;

            }


            return rpta;

        }
    }
}
