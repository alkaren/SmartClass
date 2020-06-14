using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestSmartClass.Models;

namespace TestSmartClass.Pages.Private
{
    public partial class MasterJadwal : System.Web.UI.Page
    {
        smartclassdbContext context = new smartclassdbContext();
        enum ModeForm { ViewData, UpdateData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            BindRuang();
            BindKelas();
            BindDosen();
            BindMatkul();
        }

        void BindGrid(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                if (context.jadwal_tbl.Count() > 0)
                {
                    GvData.DataSource = (from jd in context.jadwal_tbl select jd).ToList();
                    GvData.DataBind();
                }
                else
                {
                    GvData.DataSource = null;
                    GvData.DataBind();
                }
            }
        }

        void BindRuang(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                var get = (from rk in context.ruangkuliah_tbl select rk).ToList();

                if (context.ruangkuliah_tbl.Count() > 0)
                {
                    Dropdownlist1.DataTextField = "nama_ruang";
                    Dropdownlist1.DataValueField = "id_ruang";
                    Dropdownlist1.DataSource = get;
                    Dropdownlist1.DataBind();
                    Dropdownlist1.Items.Insert(0, new ListItem("--select Ruang--", "0"));

                }
                else
                {
                    Dropdownlist1.DataSource = null;
                    Dropdownlist1.DataBind();
                }
            }
        }

        void BindKelas(string param = "")
            {

                using (smartclassdbContext context = new smartclassdbContext())
                {
                    var get = (from kls in context.kelas_tbl select kls).ToList();

                    if (context.kelas_tbl.Count() > 0)
                    {
                        Dropdownlist2.DataTextField = "nama_kelas";
                        Dropdownlist2.DataValueField = "id_kelas";
                        Dropdownlist2.DataSource = get;
                        Dropdownlist2.DataBind();
                        Dropdownlist2.Items.Insert(0, new ListItem("--select Kelas--", "0"));

                    }
                    else
                    {
                        Dropdownlist2.DataSource = null;
                        Dropdownlist2.DataBind();
                    }
                }
            }

        void BindDosen(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                var get = (from ds in context.dosen_tbl select ds).ToList();

                if (context.dosen_tbl.Count() > 0)
                {
                    Dropdownlist3.DataTextField = "nama_dosen";
                    Dropdownlist3.DataValueField = "nid";
                    Dropdownlist3.DataSource = get;
                    Dropdownlist3.DataBind();
                    Dropdownlist3.Items.Insert(0, new ListItem("--select Dosen--", "0"));

                }
                else
                {
                    Dropdownlist3.DataSource = null;
                    Dropdownlist3.DataBind();
                }
            }
        }

        void BindMatkul(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                var get = (from mt in context.matkul_tbl select mt).ToList();

                if (context.matkul_tbl.Count() > 0)
                {
                    Dropdownlist4.DataTextField = "nama_matkul";
                    Dropdownlist4.DataValueField = "id_matkul";
                    Dropdownlist4.DataSource = get;
                    Dropdownlist4.DataBind();
                    Dropdownlist4.Items.Insert(0, new ListItem("--select Matkul--", "0"));

                }
                else
                {
                    Dropdownlist4.DataSource = null;
                    Dropdownlist4.DataBind();
                }
            }
        }

        
        //void LoadDetail(string fid)
        //{

        //    var ret = (from jdl in context.jadwal_tbl select jdl).Where(jdl => jdl.id_jadwal == fid).FirstOrDefault();

        //    if (ret != null)
        //    {
        //        TxtId.Text = ret.id_jadwal;
        //        Dropdownlist1.Text = ret.id_ruang;
        //        Dropdownlist2.Text = ret.id_kelas;
        //        Dropdownlist3.Text = ret.nid;
        //        Dropdownlist4.Text = ret.id_matkul;
        //         = ret.tanggal_jadwal;
        //        TxtTimestart.Text = ret.start_kuliah;
        //        TxtTimefinish.Text = ret.finish_kuliah;
        //    }
        //    else
        //    {
        //        Alert("ID tidak ditemukan");
        //    }
        //}

        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    TxtDate.Text = Calender1.SelectedDate.ToShortDateString();
        //}
        //private void DoSave()
        //{
        //    try
        //    {
        //        using (smartclassdbContext context = new smartclassdbContext())
        //        {
        //            if (context != null)
        //            {
        //                jadwal_tbl obj = new jadwal_tbl();
        //                obj.id_jadwal = TxtId.Text;
        //                obj.id_ruang = Dropdownlist1.Text;
        //                obj.id_kelas = Dropdownlist2.Text;
        //                obj.nid = Dropdownlist3.Text;
        //                obj.id_matkul = Dropdownlist4.Text;
        //                obj.tanggal_jadwal = TxtDate.Text;
        //                obj.start_kuliah = TxtTimestart.Text;
        //                obj.finish_kuliah = TxtTimefinish.Text;
        //                context.jadwal_tbl.Add(obj);
        //                context.SaveChanges();
        //                SetLayout(ModeForm.ViewData);
        //                Alert("data berhasil disimpan");
        //            }
        //            else
        //            {
        //                Alert("Data gagal disimpan");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private void DoUpdate()
        //{
        //    try
        //    {
        //        using (smartclassdbContext context = new smartclassdbContext())
        //        {
        //            if (context != null)
        //            {
        //                var jadwals = context.jadwal_tbl.Where(x => x.id_jadwal == TxtId.Text);

        //                foreach (var jadwal in jadwals)
        //                {

        //                    jadwal.id_jadwal = TxtId.Text;
        //                    jadwal.id_ruang = Dropdownlist1.Text;
        //                    jadwal.id_kelas = Dropdownlist2.Text;
        //                    jadwal.nid = Dropdownlist3.Text;
        //                    jadwal.id_matkul = Dropdownlist4.Text;
        //                    jadwal.tanggal_jadwal = TxtDate.Text;
        //                    jadwal.start_kuliah = TxtTimestart.Text;
        //                    jadwal.finish_kuliah = TxtTimefinish.Text;

        //                }
        //                context.SaveChanges();
        //                SetLayout(ModeForm.ViewData);
        //                Alert("data berhasil diupdate");


        //            }
        //            else
        //            {
        //                Alert("Data gagal disimpan");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        private void DoDelete(string id)
        {
            try
            {
                if (id != null)
                {
                    jadwal_tbl obj = context.jadwal_tbl.First(x => x.id_jadwal == id);
                    context.jadwal_tbl.Remove(obj);
                    context.SaveChanges();
                    BindGrid();
                }
                else
                {
                    Alert("Id Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int ParseInt(string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);

            return ret;
        }


        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        protected void GvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvData.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                //case "ubah":
                //    SetLayout(ModeForm.UpdateData);
                //    LoadDetail(IDS.ToString().Trim());
                //    break;

                case "hapus":
                    DoDelete(IDS.ToString().Trim());
                    break;

                //case "lihat":
                //    SetLayout(ModeForm.DetailData);
                //    LoadDetail(IDS.ToString().Trim());
                //    break;
            }
        }

        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    //case "save":
                    //    DoSave();
                    //    break;

                    case "add":
                        SetLayout(ModeForm.AddData);
                        break;

                    //case "update":
                    //    DoUpdate();
                    //    break;

                    case "cancel":
                        SetLayout(ModeForm.ViewData);
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }

        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddData:
                    //GenerateAccount();
                    //ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;

                    break;

                case ModeForm.UpdateData:
                    //GenerateAccount();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtId.Enabled = true;
                    Dropdownlist1.Enabled = true;
                    Dropdownlist2.Enabled = true;
                    Dropdownlist3.Enabled = true;
                    Dropdownlist4.Enabled = true;
                    //TxtDate.Enabled = true;
                    //TxtTimestart.Enabled = true;
                    //TxtTimefinish.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    BindGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;


            }
        }
    }
}