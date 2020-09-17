using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LemonMember.Models
{
    public class UserModel
    {
        public string student_id { get; set; }
        public string student_dept { get; set; }
        public string membership_token { get; set; }
        public string qq { get; set; }
        public string tel { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string register_date { get; set; }
        public string password { get; set; }
    }
}