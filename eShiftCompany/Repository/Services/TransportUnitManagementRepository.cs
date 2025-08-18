using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Repository.Services
{
    public class TransportUnitManagementRepository : ITransportUnitManagementRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public void Add(TransportUnitManagementModel unit)
        {
            if (string.IsNullOrEmpty(unit.Type))
                throw new ArgumentException("Unit type must be specified.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (unit.Type == "Lorry")
                {
                    query = "INSERT INTO Lorries (PlateNumber, Model, Capacity, Status) VALUES (@p1, @p2, @p3, @p4)";
                }
                else if (unit.Type == "Container")
                {
                    query = "INSERT INTO Containers (ContainerNumber, Size, Capacity, Status) VALUES (@p1, @p2, @p3, @p4)";
                }
                else
                {
                    throw new ArgumentException("Unknown transport unit type: " + unit.Type);
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@p1", unit.PlateOrContainerNumber);
                    cmd.Parameters.AddWithValue("@p2", unit.ModelOrSize);
                    cmd.Parameters.AddWithValue("@p3", unit.Capacity);
                    cmd.Parameters.AddWithValue("@p4", unit.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(TransportUnitManagementModel unit)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";

                if (unit.Type == "Lorry")
                {
                    query = "UPDATE Lorries SET PlateNumber=@p1, Model=@p2, Capacity=@p3, Status=@p4 WHERE LorryID=@id";
                }
                else if (unit.Type == "Container")
                {
                    query = "UPDATE Containers SET ContainerNumber=@p1, Size=@p2, Capacity=@p3, Status=@p4 WHERE ContainerID=@id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p1", unit.PlateOrContainerNumber);
                cmd.Parameters.AddWithValue("@p2", unit.ModelOrSize);
                cmd.Parameters.AddWithValue("@p3", unit.Capacity);
                cmd.Parameters.AddWithValue("@p4", unit.Status);
                cmd.Parameters.AddWithValue("@id", unit.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string type, int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string table = (type == "Lorry") ? "Lorries" : "Containers";
                string column = (type == "Lorry") ? "LorryID" : "ContainerID";

                SqlCommand cmd = new SqlCommand($"DELETE FROM {table} WHERE {column}=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public TransportUnitManagementModel GetById(string type, int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";
                
                TransportUnitManagementModel unit = null;

                if (type == "Lorry")
                {
                    query = "SELECT * FROM Lorries WHERE LorryID=@id";
                    
                }
                else if (type == "Container")
                {
                    query = "SELECT * FROM Containers WHERE ContainerID=@id";
                   
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    unit = new TransportUnitManagementModel
                    {
                        ID = id,
                        Type = type,
                        PlateOrContainerNumber = dr[type == "Lorry" ? "PlateNumber" : "ContainerNumber"].ToString(),
                        ModelOrSize = dr[type == "Lorry" ? "Model" : "Size"].ToString(),
                        Capacity = Convert.ToDecimal(dr["Capacity"]),
                        Status = dr["Status"].ToString()
                    };
                }

                return unit;
            }
        }

        public List<TransportUnitManagementModel> GetAll(string type)
        {
            List<TransportUnitManagementModel> list = new List<TransportUnitManagementModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = (type == "Lorry") ? "SELECT * FROM Lorries" : "SELECT * FROM Containers";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var unit = new TransportUnitManagementModel
                    {
                        ID = Convert.ToInt32(dr[type == "Lorry" ? "LorryID" : "ContainerID"]),
                        Type = type,
                        PlateOrContainerNumber = dr[type == "Lorry" ? "PlateNumber" : "ContainerNumber"].ToString(),
                        ModelOrSize = dr[type == "Lorry" ? "Model" : "Size"].ToString(),
                        Capacity = Convert.ToDecimal(dr["Capacity"]),
                        Status = dr["Status"].ToString()
                    };
                    list.Add(unit);
                }
            }
            return list;
        }

        public void AddLorry(TransportUnitManagementModel model)
        {
            throw new NotImplementedException();
        }

        public object GetAllLorries()
        {
            throw new NotImplementedException();
        }
    }
}
