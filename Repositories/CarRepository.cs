using Microsoft.Data.SqlClient;
using Models;
using System.Text;

namespace Repositories
{
    public class CarRepository
    {
        private readonly string _strConn = "Data Source=127.0.0.1; Initial Catalog=DBCar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection conn;

        public CarRepository()
        {
            conn = new SqlConnection(_strConn);
            conn.Open();
        }

        public bool Insert(Car car)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new(Car.INSERT, conn);

                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool Update(Car car)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new(Car.UPDATE, conn);

                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.Parameters.Add(new SqlParameter("@Id", car.Id));

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new(Car.DELETE, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                int lines = cmd.ExecuteNonQuery();

                if(lines != 0) result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<Car> GetAll() 
        {
            List<Car> list = new();

            try
            {
                SqlCommand cmd = new(Car.GETALL, conn);
                using var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Car car = new Car();

                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);

                    list.Add(car);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public Car? Get(int id)
        {
            Car? car = null;
            StringBuilder sb = new StringBuilder();

            try
            {
                SqlCommand cmd = new(Car.GET, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    car = new();

                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return car;
        }
    }
}
