using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public class BD
    {
        static string connString = "Host=localhost;Username=postgres;Password=1234;Database=laba3";

        NpgsqlConnection conn; //= new NpgsqlConnection(connString);

        string query;

        int id_user;
        public BD()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("Подключение к базе данных открыто");
            } 
            catch (Exception ex) {
                Console.WriteLine("При подключение к базе данных ввозникла ошибка: {ex.Message}");
            }
            finally
            {
                Console.Read();
            }
        }
        public bool IsUserBD(string login, string password)
        {
            query = "SELECT \"Id\" FROM public.user WHERE \"Login\" = @login AND \"Password\" = @password";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("login", login.Trim());
                    cmd.Parameters.AddWithValue("password", password.Trim());

                    var res = cmd.ExecuteScalar();
                    if (res != null)
                    {
                        // Если результат не null, то преобразуем его в long и записываем в переменную id
                        id_user = Convert.ToInt32(res);
                        return true;
                    }
                    else
                    {
                        // Если пользователь не найден, возвращаем false
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool Сomplaint(string problem)
        {
            query = "CALL public.\"Complaint\"(@id,@problem)";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("id", id_user);
                    cmd.Parameters.AddWithValue("problem", problem);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        internal bool AddComCon(string prob)
        {
            query = "UPDATE public.\"user\" SET \"ComCon\" = @prob WHERE \"Id\" = @id;";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("id", id_user);
                    cmd.Parameters.AddWithValue("prob", prob);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
