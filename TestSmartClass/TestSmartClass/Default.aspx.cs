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
using System.Globalization;

namespace TestSmartClass
{
    public partial class _Default : Page
    {
        string iddosen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT absen_log,nim,idmatkul,nid,url_foto,tanggal_absen,start_time,last_time from log_tbl"))
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
            run();
        }

        private void run()
        {
            string StrQuery;
            string QueryDel;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    using (MySqlCommand comm = new MySqlCommand())
                    {
                        comm.Connection = conn;
                        conn.Open();
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            string start = GridView1.Rows[i].Cells[7].Text;
                            string end = GridView1.Rows[i].Cells[8].Text;
                            iddosen = GridView1.Rows[i].Cells[3].Text;
                            DateTime Stime = DateTime.ParseExact(start, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
                            DateTime Etime = DateTime.ParseExact(end, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
                            TimeSpan ts = Etime - Stime;
                            string totalmasuk = ts.ToString();
                            StrQuery = "INSERT INTO absen_tbl (id_absen, nim, idmatkul, nid, url_foto, tanggal_absen, start_detect, last_detect,total_hadir) VALUES('"
                                + GridView1.Rows[i].Cells[0].Text + "', '"
                                + GridView1.Rows[i].Cells[1].Text + "', '"
                                + GridView1.Rows[i].Cells[2].Text + "', '"
                                + GridView1.Rows[i].Cells[3].Text + "', '"
                                + GridView1.Rows[i].Cells[4].Text + "', '"
                                + GridView1.Rows[i].Cells[6].Text + "', '"
                                + GridView1.Rows[i].Cells[7].Text + "', '"
                                + GridView1.Rows[i].Cells[8].Text + "', '"
                                + totalmasuk + "')";
                            comm.CommandText = StrQuery;
                            comm.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    using (MySqlCommand commdel = new MySqlCommand())
                    {
                        commdel.Connection = conn;
                        conn.Open();
                        QueryDel = "DELETE FROM log_tbl WHERE nid = '" + iddosen + "'";
                        commdel.CommandText = QueryDel;
                        commdel.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception Ex)
            {
                Response.Write("Something Wrong" + Ex);
            }
        }
    }
}