using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MRAproject.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string Caption { get; set; }
        //public Role Role { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        internal static List<User> Convert(DataTable dt)
        {
            List<User> result = null;

            if (dt.Rows.Count != 0)
            {
                result = new List<User>();
                User temp = null;
                foreach (DataRow row in dt.Rows)
                {
                    temp = new User();

                    if (dt.Columns.Contains("ID") && row["ID"] != DBNull.Value)
                        temp.ID = System.Convert.ToInt32(row["ID"]);

                    if (dt.Columns.Contains("Name") && row["Name"] != DBNull.Value)
                        temp.Name = System.Convert.ToString(row["Name"]);

                    if (dt.Columns.Contains("LastName") && row["LastName"] != DBNull.Value)
                        temp.LastName = System.Convert.ToString(row["LastName"]);

                    if (dt.Columns.Contains("Phone") && row["Phone"] != DBNull.Value)
                        temp.Phone = System.Convert.ToString(row["Phone"]);

                    if (dt.Columns.Contains("EmailAddress") && row["EmailAddress"] != DBNull.Value)
                        temp.EmailAddress = System.Convert.ToString(row["EmailAddress"]);

                    //if (dt.Columns.Contains("UserName") && row["UserName"] != DBNull.Value)
                    //    temp.UserName = System.Convert.ToString(row["UserName"]);

                    //if (dt.Columns.Contains("Password") && row["Password"] != DBNull.Value)
                    //    temp.Password = System.Convert.ToString(row["Password"]);

                    //if (dt.Columns.Contains("Role") && row["Role"] != DBNull.Value)
                    //    temp.Role = new Role((Role.Type)System.Convert.ToInt32(row["Role"]));

                    result.Add(temp);
                }
            }
            return result;
        }
    }
    //public class Role
    //{
    //    public enum Type
    //    {
    //        Admin = 1,
    //        Client = 2
    //    }

    //    public Role(Type id)
    //    {
    //        this.ID = id;
    //    }

    //    public Type ID { get; set; }
    //    public string Title
    //    {
    //        get
    //        {
    //            string result = "";
    //            switch (ID)
    //            {
    //                case Type.Admin:
    //                    result = "مدیر";
    //                    break;
    //                case Type.Client:
    //                    result = "کاربر";
    //                    break;

    //            }
    //            return result;
    //        }
    //    }
    //}
}