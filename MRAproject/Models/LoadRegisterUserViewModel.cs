using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAproject.Models
{
    public class LoadRegisterUserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string Caption { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        public string resultMessage { get; set; }

        public List<User> Users { get; set; }

        public bool IsEditMode { get; set; }
    }

    public class LoadRegisterPersonJsViewModel
    {
        public List<User> Users { get; set; }
    }
}