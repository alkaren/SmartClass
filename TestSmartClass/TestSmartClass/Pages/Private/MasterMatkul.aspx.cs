using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestSmartClass.Models;

namespace TestSmartClass.Pages.Private
{
    public partial class MasterMatkul : System.Web.UI.Page
    {
        smartclassdbContext context = new smartclassdbContext();
        enum ModeForm { ViewData, UpdateData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        void BindGrid(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                if (context.matkul_tbl.Count() > 0)
                {
                    GvData.DataSource = (from mt in context.matkul_tbl select mt).ToList();
                    GvData.DataBind();

                    
                }
                else
                {
                    GvData.DataSource = null;
                    GvData.DataBind();
                }
            }
        }

        //void Grid(string param = "")
        //{

        //    using (smartclassdbContext context = new smartclassdbContext())
        //    {
        //        var get = (from kls in context.kelas_tbl select kls).ToList();

        //        if (context.kelas_tbl.Count() > 0)
        //        {
        //            Dropdownlist1.DataTextField = "nama_kelas";
        //            Dropdownlist1.DataValueField = "id_kelas";
        //            Dropdownlist1.DataSource = get;
        //            Dropdownlist1.DataBind();
        //            Dropdownlist1.Items.Insert(0, new ListItem("--select ID Kelas--", "0"));

        //        }
        //        else
        //        {
        //            Dropdownlist1.DataSource = null;
        //            Dropdownlist1.DataBind();
        //        }
        //    }
        //}

        void LoadDetail(string fid)
        {

            var ret = (from mt in context.matkul_tbl select mt).Where(mt => mt.id_matkul == fid).FirstOrDefault();

            if (ret != null)
            {
                TxtId.Text = ret.id_matkul;
                TxtNama.Text = ret.nama_matkul;
                TxtJam.Text = ret.total_jam;
            }
            else
            {
                Alert("ID tidak ditemukan");
            }
        }

        private void DoSave()
        {
            try
            {
                using (smartclassdbContext context = new smartclassdbContext())
                
                {
                    if (context != null)
                    {
                        matkul_tbl obj = new matkul_tbl();
                        obj.id_matkul = TxtId.Text;
                        obj.nama_matkul = TxtNama.Text;
                        obj.total_jam = TxtJam.Text;
                        context.matkul_tbl.Add(obj);
                        context.SaveChanges();
                        SetLayout(ModeForm.ViewData);
                        Alert("data berhasil disimpan");
                    }
                    else
                    {
                        Alert("Data gagal disimpan");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DoUpdate()
        {
            try
            {
                using (smartclassdbContext context = new smartclassdbContext())
                {
                    if (context != null)
                    {
                        var matkuls = context.matkul_tbl.Where(x => x.id_matkul == TxtId.Text);

                        foreach (var matkul in matkuls)
                        {

                            matkul.id_matkul = TxtId.Text;
                            matkul.nama_matkul = TxtNama.Text;
                            matkul.total_jam = TxtJam.Text;


                        }
                        context.SaveChanges();
                        SetLayout(ModeForm.ViewData);
                        Alert("data berhasil diupdate");


                    }
                    else
                    {
                        Alert("Data gagal disimpan");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DoDelete(string id)
        {
            try
            {
                if (id != null)
                {
                    matkul_tbl obj = context.matkul_tbl.First(x => x.id_matkul == id);
                    context.matkul_tbl.Remove(obj);
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
                case "ubah":
                    SetLayout(ModeForm.UpdateData);
                    LoadDetail(IDS.ToString().Trim());
                    break;

                case "hapus":
                    DoDelete(IDS.ToString().Trim());
                    break;

                case "lihat":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(IDS.ToString().Trim());
                    break;
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
                    case "save":
                        DoSave();
                        break;

                    case "add":
                        SetLayout(ModeForm.AddData);
                        break;

                    case "update":
                        DoUpdate();
                        break;

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
                    TxtNama.Enabled = true;
                    TxtJam.Enabled = true;
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