using MRAproject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MRAproject.DataAccess
{
    public class AdminService
    {
        static string _connectionString = "Data Source=ANDIK;Initial Catalog=MRAproject;Integrated Security=True";

        public static bool Login(int id,string username, string password, out Admin admin)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand("Loginn", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            DataTable dt = new DataTable();

            SqlParameter _id = new SqlParameter("@Id", SqlDbType.Int);
            if (id == 0)
                _id.Value = DBNull.Value;
            else
                _id.Value = id;

            SqlParameter _username = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(username))
                _username.Value = DBNull.Value;
            else
                _username.Value = username;

            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(password))
                _password.Value = DBNull.Value;
            else
                _password.Value = password;

            comm.Parameters.Add(_username);
            comm.Parameters.Add(_password);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            admin = null;
            if (dt != null && dt.Rows.Count == 1)
            {
                admin = Admin.Convert(dt)?[0];
                return true;
            }
            return false;
        }
    }
}