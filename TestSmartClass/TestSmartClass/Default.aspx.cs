using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace TestSmartClass
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT absen_log,NIM,url_foto,tanggal_absen,start_time,last_time,total_time from log_tbl"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            run_cmd();
        }

        private void run_cmd()
        {

            string fileName = @"D:/git/SmartClass/hello.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python27\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            Console.ReadLine();

        }

        //private void run_cmd(string cmd, string args)
        //{
        //    ProcessStartInfo start = new ProcessStartInfo();
        //    start.FileName = cmd;
        //    start.Arguments = string.Format("{0} {1}", cmd, args);
        //    start.UseShellExecute = false;
        //    start.RedirectStandardOutput = true;
        //    using (Process process = Process.Start(start))
        //    {
        //        using (StreamReader reader = process.StandardOutput)
        //        {
        //            string result = reader.ReadToEnd();
        //            Console.Write(result);
        //            Console.ReadLine();
        //        }
        //    }
        //}
    }
}