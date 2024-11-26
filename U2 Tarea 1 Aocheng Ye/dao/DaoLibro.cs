using MySql.Data.MySqlClient;

using System.Windows;

using U2_Tarea_1_Aocheng_Ye.dto;

namespace U2_Tarea_1_Aocheng_Ye.dao
{
    internal class DaoLibro
    {
        public void insertarLibro(Libro libro)
        {

            try
            {
                string query = "INSERT INTO catalogo (titulo, autor, editorial, fecha_publicacion, imagen, descripcion, precio, unidades, enventa) " +

                "VALUES (@titulo, @autor, @editorial, @fecha_publicacion, @imagen, @descripcion, @precio, @unidades, @enventa)";

                Conexion objetoConexion = new Conexion();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());

                myCommand.Parameters.AddWithValue("@titulo", libro.titulo);

                myCommand.Parameters.AddWithValue("@autor", libro.autor);

                myCommand.Parameters.AddWithValue("@editorial", libro.editorial);

                myCommand.Parameters.AddWithValue("@fecha_publicacion", libro.fecha_publicacion);

                myCommand.Parameters.AddWithValue("@imagen", libro.imagen);

                myCommand.Parameters.AddWithValue("@descripcion", libro.descripcion);

                myCommand.Parameters.AddWithValue("@precio", libro.precio);

                myCommand.Parameters.AddWithValue("@unidades", libro.unidades);

                myCommand.Parameters.AddWithValue("@enventa", libro.enventa);

                MySqlDataReader reader = myCommand.ExecuteReader();

                MessageBox.Show("¡Libro registrado exitosamente!");

                while (reader.Read()) { }

                objetoConexion.cerrarConexion();
            }

            catch (Exception ex)

            {
                MessageBox.Show("No se pudo guardar el libro. Error: " + ex.ToString());
            }
        }

        public List<Libro> listarLibros()
        {
            List<Libro> libros = new List<Libro>();
            try
            {

                string query = "Select * from catalogo";
                Conexion objetoConexion = new Conexion();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());

                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetDateTime(4),
                                            reader.GetString(5),
                                            reader.GetString(6),
                                            reader.GetFloat(7),
                                            reader.GetInt32(8),
                                            reader.GetBoolean(9)
                                            );
                    libros.Add(libro);
                }
                reader.Close();
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {  
                MessageBox.Show("No se pudo listar los libros. Error: " + ex.Message);
            }



            return libros;
        }


        public Libro buscarLibro(int? id = null, string titulo = null)
        {
            Libro libro = null;
            try
            {
                string query = "SELECT * FROM catalogo WHERE ";
                if (id.HasValue)
                {
                    query += "id = @id";
                }
                else if (!string.IsNullOrEmpty(titulo))
                {
                    query += "titulo = @titulo";
                }
                else
                {
                    throw new ArgumentException("Debe proporcionar un id o un título para buscar un libro.");
                }
                Conexion objetoConexion = new Conexion();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                if (id.HasValue)
                {
                    myCommand.Parameters.AddWithValue("@id", id.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@titulo", titulo);
                }
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    libro = new Libro(reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDateTime(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetFloat(7),
                        reader.GetInt16(8),
                        reader.GetBoolean(9));
                }
                reader.Close();
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            return libro;
        }

        public void modificarLibro(int id, Libro libro)
        {


            try
            {
                string query = "UPDATE catalogo SET titulo=@titulo, autor=@autor, editorial=@editorial, " +
                    "fecha_publicacion=@fecha_publicacion, imagen=@imagen, descripcion=@descripcion," +
                    " precio=@precio, unidades=@unidades, enventa=@enventa WHERE id = @id";


                Conexion objetoConexion = new Conexion();

                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());

                myCommand.Parameters.AddWithValue("@id", id);

                myCommand.Parameters.AddWithValue("@titulo", libro.titulo);

                myCommand.Parameters.AddWithValue("@autor", libro.autor);

                myCommand.Parameters.AddWithValue("@editorial", libro.editorial);

                myCommand.Parameters.AddWithValue("@fecha_publicacion", libro.fecha_publicacion);

                myCommand.Parameters.AddWithValue("@imagen", libro.imagen);

                myCommand.Parameters.AddWithValue("@descripcion", libro.descripcion);

                myCommand.Parameters.AddWithValue("@precio", libro.precio);

                myCommand.Parameters.AddWithValue("@unidades", libro.unidades);

                myCommand.Parameters.AddWithValue("@enventa", libro.enventa);


                MySqlDataReader reader = myCommand.ExecuteReader();

                objetoConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        public void eliminarLibro(int id, Libro libro)
        {
            try
            {
                string query = "DELETE FROM catalogo WHERE id = @id";
                Conexion objetoConexion = new Conexion();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());

                myCommand.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = myCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el libro." + ex);
            }
        }





    }
}


