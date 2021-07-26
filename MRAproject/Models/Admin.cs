using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MRAproject.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public static List<Admin> Convert(DataTable dt)
        {
            List<Admin> result = null;

            if (dt.Rows.Count != 0)
            {
                result = new List<Admin>();
                Admin temp = null;
                foreach (DataRow row in dt.Rows)
                {
                    temp = new Admin();

                    if (dt.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                        temp.Id = System.Convert.ToInt32(row["Id"]);

                    if (dt.Columns.Contains("UserName") && row["UserName"] != DBNull.Value)
                        temp.UserName = System.Convert.ToString(row["UserName"]);

                    if (dt.Columns.Contains("Password") && row["Password"] != DBNull.Value)
                        temp.Password = System.Convert.ToString(row["Password"]);
                    if (dt.Columns.Contains("Role") && row["Role"] != DBNull.Value)
                        temp.Role = new Role((Role.Type)System.Convert.ToInt32(row["Role"]));

                    result.Add(temp);
                }
            }
            return result;
        }
    }
        public class Role
        {
            public enum Type
            {
                Admin = 1,
                Client = 2
            }

            public Role(Type id)
            {
                this.ID = id;
            }

            public Type ID { get; set; }
            public string Title
            {
                get
                {
                    string result = "";
                    switch (ID)
                    {
                        case Type.Admin:
                            result = "مدیر";
                            break;
                        case Type.Client:
                            result = "کاربر";
                            break;

                    }
                    return result;
                }
            }
        }  
}