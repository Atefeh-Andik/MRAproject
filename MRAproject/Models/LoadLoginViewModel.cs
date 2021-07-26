using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRAproject.Models
{
    public class LoadLoginViewModel
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Message { set; get; }
    }
}