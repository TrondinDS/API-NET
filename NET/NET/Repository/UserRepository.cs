using NET.Domain;
using Npgsql;

namespace NET.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        User SelectUserWhereId(int id);
        List<User> GetAllUsers();
        void UpdateUser(User cabinet);
        void DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int AddUser(User user)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO public.user (name, date) VALUES (@name, @date) RETURNING id";
                    command.Parameters.AddWithValue("name", user.name);
                    command.Parameters.AddWithValue("date", user.date);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM public.user WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM public.user";

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                date = reader.GetString(2)
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public User SelectUserWhereId(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM public.user WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User()
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                date = reader.GetString(2)
                            };

                            return user;
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateUser(User user)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE public.user SET name = @name, date = @date WHERE id = @id";
                    command.Parameters.AddWithValue("name", user.name);
                    command.Parameters.AddWithValue("date", user.date);
                    command.Parameters.AddWithValue("id", user.id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
