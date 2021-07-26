using MRAproject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRAproject.DataAccess
{
    public class UserService
    {
        static string _connectionString = "Data Source=ANDIK;Initial Catalog=MRAproject;Integrated Security=True";

        public static string Register(User user)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand("AddUser", conn);
            comm.CommandType = CommandType.StoredProcedure;
            conn.Open();
            int result = comm.ExecuteNonQuery();
            conn.Close();

            if (result > 0)

                return "ثبت با موفقیت انجام شد ";
            return "ثبت انجام نشد";
        }
        public static User GetByID(int id)
        {
            List<User> user = Get(id);
            if (user != null && user.Count != 0)
                return user[0];
            return null;
        }

        public static List<User> Get(int id = 0, string name = "",string lastname="",string phone="",string emailaddress="",string caption="")
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand("GetUser", conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            DataTable dt = new DataTable();

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            if (id == 0)
                _id.Value = DBNull.Value;
            else
                _id.Value = id;


            SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(name))
                _name.Value = DBNull.Value;
            else
                _name.Value = name;

            SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(lastname))
                _lastname.Value = DBNull.Value;
            else
                _lastname.Value = lastname;

            SqlParameter _phone = new SqlParameter("@Pone", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(phone))
                _phone.Value = DBNull.Value;
            else
                _phone.Value = phone;

            SqlParameter _emailaddress = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(emailaddress))
                _emailaddress.Value = DBNull.Value;
            else
                _emailaddress.Value = emailaddress;

            SqlParameter _caption = new SqlParameter("@Caption", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(caption))
                _caption.Value = DBNull.Value;
            else
                _caption.Value = caption;

            comm.Parameters.Add(_id);
            comm.Parameters.Add(_name);
            comm.Parameters.Add(_lastname);
            comm.Parameters.Add(_phone);
            comm.Parameters.Add(_emailaddress);
            comm.Parameters.Add(_caption);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return User.Convert(dt);
        }

        //public static bool Login(string username, string password, out User admin)
        //{
        //    SqlConnection conn = new SqlConnection(_connectionString);
        //    SqlCommand comm = new SqlCommand("Loginn", conn);
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = comm;

        //    DataTable dt = new DataTable();
        //    SqlParameter _username = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
        //    if (string.IsNullOrEmpty(username))
        //        _username.Value = DBNull.Value;
        //    else
        //        _username.Value = username;

        //    SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        //    if (string.IsNullOrEmpty(password))
        //        _password.Value = DBNull.Value;
        //    else
        //        _password.Value = password;

        //    comm.Parameters.Add(_username);
        //    comm.Parameters.Add(_password);

        //    conn.Open();
        //    da.Fill(dt);
        //    conn.Close();

        //    admin = null;
        //    if (dt != null && dt.Rows.Count == 1)
        //    {
        //        admin = User.Convert(dt)?[0];
        //        return true;
        //    }
        //    return false;
        //}
        public static string Delete(int id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand("DeletUser", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            if (id == 0)
                _id.Value = DBNull.Value;
            else
                _id.Value = id;

            comm.Parameters.Add(_id);

            conn.Open();
            int result = comm.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
                return "حذف با موفقیت انجام شد";
            return "حذف انجام نشد";
        }

        public static string Edit(User user)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand("PersonEdit", conn);
            comm.CommandType = CommandType.StoredProcedure;

            if (user == null)
                return "اطلاعات ناقص است";

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            if (user.ID == 0)
                _id.Value = DBNull.Value;
            else
                _id.Value = user.ID;

            SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(user.Name))
                _name.Value = DBNull.Value;
            else
                _name.Value = user.Name;

            SqlParameter _lastname = new SqlParameter("@Lastname", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(user.LastName))
                _lastname.Value = DBNull.Value;
            else
                _lastname.Value = user.LastName;

            SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(user.Phone))
                _phone.Value = DBNull.Value;
            else
                _phone.Value = user.Phone;

            SqlParameter _emailaddress = new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 50);
            if (string.IsNullOrEmpty(user.EmailAddress))
                _emailaddress.Value = DBNull.Value;
            else
                _emailaddress.Value = user.EmailAddress;

            SqlParameter _caption = new SqlParameter("@Caption", SqlDbType.Date);
            if (string.IsNullOrEmpty(user.Caption))
                _caption.Value = DBNull.Value;
            else
                _caption.Value = user.Caption;

            comm.Parameters.Add(_id);
            comm.Parameters.Add(_name);
            comm.Parameters.Add(_lastname);
            comm.Parameters.Add(_phone);
            comm.Parameters.Add(_emailaddress);
            comm.Parameters.Add(_caption);


            conn.Open();
            int result = comm.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
                return "ویرایش با موفقیت انجام شد";
            return "ویرایش انجام نشد";
        }
    }
}
