using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class UserDac
    {
        public int Save(Users user)
        {
            int result = 0;
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Save_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@age", user.Age);
                    cmd.Parameters.AddWithValue("@isEmployed", user.IsEmployed);
                    cmd.Parameters.AddWithValue("@dateOfBirth", DateTime.Now);
                    result = cmd.ExecuteNonQuery();
                }
                

            }
            catch(Exception ex)
            {
                result = -1;
            }
            return result; 
        }

        public int Delete(int id)
        {
            int result = 0;
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Delete_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int Update(Users user)
        {
            int result = 0;
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Update_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@age", user.Age);
                    cmd.Parameters.AddWithValue("@isEmployed", user.IsEmployed);
                    cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public List<Users> GetAll()
        {
            List<Users> users = new List<Users>();
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetAll_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Users user = new Users();
                        user.Id = Convert.ToInt32(dr["Id"]);
                        user.Name = Convert.ToString(dr["Name"]);
                        user.Age = Convert.ToString(dr["Age"]);
                        user.IsEmployed =  Convert.ToBoolean (dr["IsEmployed"]);
                        user.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                        users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                users = null;
            }
            return users;
        }

        public List<Users> Search(string name)
        {
            List<Users> users = new List<Users>();
            try
            {
                SqlConnection con = DbCon.GetConnection();
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Search_", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Users user = new Users();
                        user.Id = Convert.ToInt32(dr["Id"]);
                        user.Name = Convert.ToString(dr["Name"]);
                        user.Age = Convert.ToString(dr["Age"]);
                        user.IsEmployed = Convert.ToBoolean(dr["IsEmployed"]);
                        user.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                        users.Add(user);
                    }
                }

            }
            catch (Exception ex)
            {
                users = null;
            }
            return users;
        }

    }
}
