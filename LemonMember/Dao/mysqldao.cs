using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using MySql;
using MySql.Data.MySqlClient;

namespace LemonMember.Dao
{
    public class mysqldao
    {
        public bool MysqlCon_insert(string insert)
        {
            bool status = true;
            try
            {
                MySqlConnection con = new MySqlConnection("server=47.93.51.66;database=lemon;uid=root;pwd=remymartin;charset='gbk'");
                con.Execute(insert);
            }
            catch (Exception e)
            {
                string message = e.Message;
                status = false;
            }
            

            return status;
        }
    }
}