using LemonMember.Dao;
using LemonMember.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LemonMember.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult register()
        {
            return View();
        }

        [HttpPost,ActionName("register")]
        public ActionResult register(int?id)
        {
            //生成membership_token
            var rnd = new Random();
            var tokenData = new byte[8];
            rnd.NextBytes(tokenData);
            var token = Convert.ToBase64String(tokenData).TrimEnd('=');

            //获取前端数据
            UserModel user = new UserModel();
            user.name = Request["name"];
            user.gender = Request["gender"];
            user.student_id = Request["student_id"];
            user.student_dept = Request["student_dept"];
            user.membership_token = token;
            user.tel = Request["tel"];
            user.qq = Request["qq"];
            user.password = Request["set_pwd"];
            user.register_date = DateTime.Now.ToString();

            //配置插入数据库
            string insert_membership = string.Format("INSERT into membership (student_id,student_dept,membership_token,qq,tel,name,gender,register_date,password) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",user.student_id,user.student_dept,user.membership_token,user.qq,user.tel,user.name,user.gender,user.register_date,user.password);
            //连接数据库执行语句
            mysqldao msd = new mysqldao();
            bool status = msd.MysqlCon_insert(insert_membership);
            if(status == true)
            {
                ViewData["token"] = user.membership_token;
                //Response.Redirect("Register/Message");
                //Response.Write("<script language='javascript'>window.open('Message.cshtml');</script>");
                return Redirect("Message?token="+user.membership_token);
            }
           else
            {
                //Response.Redirect("Register/error");
                //Response.Write("<script language='javascript'>window.open('error.cshtml');</script>");
                return Redirect("error");
            }
            //return Redirect("Register/Message");
        }

        public ActionResult Message()
        {
            ViewData["token"] = Request["token"];
            return View();
        }

        public ActionResult error()
        {
            return View();
        }
    }
}