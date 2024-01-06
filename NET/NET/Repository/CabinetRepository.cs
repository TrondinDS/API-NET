using NET.Domain;
using Npgsql;
using System.Xml.Linq;

namespace NET.Repository
{
    public interface ICabinetRepository
    {
        int AddCabinet(Cabinet cabinet);
        Cabinet SelectCabinetWhereId(int id);
        List<Cabinet> GetAllCabinets();
        void UpdateCabinet(Cabinet cabinet);
        void DeleteCabinet(int id);
    }

    public class CabinetRepository : ICabinetRepository
    {
        private readonly string _connectionString;
        public CabinetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddCabinet(Cabinet cabinet)
        {
            int cabinetId = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO public.cabinet (name, compani, user_id) VALUES (@name, @compani, @userId) RETURNING id";
                    command.Parameters.AddWithValue("name", cabinet.name);
                    command.Parameters.AddWithValue("compani", cabinet.company);
                    command.Parameters.AddWithValue("userId", cabinet.user_id);

                    cabinetId = (int)command.ExecuteScalar();
                }
            }

            return cabinetId;
        }

        public void DeleteCabinet(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM public.cabinet WHERE id = @cabinetId";
                    command.Parameters.AddWithValue("cabinetId", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cabinet> GetAllCabinets()
        {
            List<Cabinet> cabinets = new List<Cabinet>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM public.cabinet";

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cabinet cabinet = new Cabinet()
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                company = reader.GetString(2),
                                user_id = reader.GetInt32(3)
                            };

                            cabinets.Add(cabinet);
                        }
                    }
                }
            }

            return cabinets;
        }

        public void UpdateCabinet(Cabinet cabinet)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE public.cabinet SET name = @name, compani = @compani, user_id = @userId WHERE id = @cabinetId";
                    command.Parameters.AddWithValue("name", cabinet.name);
                    command.Parameters.AddWithValue("compani", cabinet.company);
                    command.Parameters.AddWithValue("userId", cabinet.user_id);
                    command.Parameters.AddWithValue("cabinetId", cabinet.id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Cabinet SelectCabinetWhereId(int id)
        {
            Cabinet cabinet = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM public.cabinet WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cabinet = new Cabinet()
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                company = reader.GetString(2),
                                user_id = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }

            return cabinet;
        }
    }
}
