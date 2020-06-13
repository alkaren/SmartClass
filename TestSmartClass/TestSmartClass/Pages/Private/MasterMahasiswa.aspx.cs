using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestSmartClass.Models;

namespace TestSmartClass.Pages.Private
{
    
    public partial class MasterMahasiswa : System.Web.UI.Page
    {
        smartclassdbContext context = new smartclassdbContext();
        //MahasiswaControlls mahasiswaControl = new MahasiswaControlls();
        enum ModeForm { ViewData, UpdateData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        #region Custom function
        // Clear input fields
        //void ClearFields()
        //{
        //    TxtCustomerNo.Text = "Otomatis";
        //    TxtCustomerName.Text = "";
        //    TxtCusEmail.Text = "";
        //    TxtCompanyName.Text = "";
        //    TxtCompanyAddress.Text = "";
        //    TxtPhoneNo.Text = "";
        //    TxtComEmail.Text = "";
        //    TxtAccountNo.SelectedIndex = 0;
        //}

        // Reload datagrid
        void BindGrid(string param = "")
        {

            using (smartclassdbContext context = new smartclassdbContext())
            {
                if (context.mahasiswa_tbl.Count() > 0)
                {
                    GvData.DataSource = (from mh in context.mahasiswa_tbl select mh).ToList();
                    GvData.DataBind();
                }
                else
                {
                    GvData.DataSource = null;
                    GvData.DataBind();
                }
            }
            //GvData.DataBind();

            //if (param == null || param == "")
            //{
            //    var ret = mahasiswaControl.GetData();
            //    var datas = ret.ToArray();

            //    if (datas != null && datas.Count() > 0)
            //    {
            //        GvData.DataSource = datas;
            //        GvData.DataBind();
            //    }
            //}
            //else
            //{
            //    var ret = mahasiswaControl.GetDataByContaint(param);
            //    var datas = ret.Result;

            //    if (datas != null && datas.Count() > 0)
            //    {
            //        GvData.DataSource = datas;
            //        GvData.DataBind();
            //    }
            //}

            //if (GvData.Rows.Count > 0)
            //{
            //    //Allow Paging
            //    GvData.AllowCustomPaging = true;
            //    //This replaces <td> with <th>    
            //    GvData.UseAccessibleHeader = true;
            //    //This will add the <thead> and <tbody> elements    
            //    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    //This adds the <tfoot> element. Remove if you don't have a footer row    
            //    GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }

        void LoadDetail(string fid)
        {

            var ret = (from mh in context.mahasiswa_tbl select mh).Where(mh => mh.id == fid).FirstOrDefault();

            if (ret != null)
            {
                TxtId.Text = ret.id;
                TxtNim.Text = ret.NIM;
                TxtNama.Text = ret.Nama;
                TxtEmail.Text = ret.Email;
            }
            else
            {
                Alert("ID tidak ditemukan");
            }
        }

        //private void DoUpdate()
        //{
        //    int id = ParseInt(TxtCustomerNo.Text);
        //    var data = new customertbl
        //    {
        //        customerNo = id,
        //        customerName = TxtCustomerName.Text,
        //        customerEmail = TxtCusEmail.Text,
        //        companyName = TxtCompanyName.Text,
        //        companyAddress = TxtCompanyAddress.Text,
        //        companyPhone = TxtPhoneNo.Text,
        //        companyEmail = TxtComEmail.Text,
        //        modBy = currentUser,
        //        modDate = DatetimeHelper.GetDatetimeNow()
        //    };

        //    if (TxtAccountNo.SelectedValue != "-1")
        //    {
        //        data.accountNo = ParseInt(TxtAccountNo.SelectedValue);
        //    }

        //    var ret = customerControl.UpdateData(id.ToString(), data);

        //    if (ret.Result)
        //    {
        //        ClearFields();
        //        SetLayout(ModeForm.ViewData);
        //        Alert("Data berhasil diubah");
        //    }
        //    else
        //    {
        //        Alert("Gagal mengubah data");
        //    }
        //}

        private void DoSave()
        {
            try
            {
                using (smartclassdbContext context = new smartclassdbContext())
                {
                    if(context != null)
                    {
                        mahasiswa_tbl obj = new mahasiswa_tbl();
                        obj.id = TxtId.Text;
                        obj.NIM = TxtNim.Text;
                        obj.Nama = TxtNama.Text;
                        obj.Email = TxtEmail.Text;
                        context.mahasiswa_tbl.Add(obj);
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
            catch(Exception ex)
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
                        var mahasiswas = context.mahasiswa_tbl.Where(x => x.id == TxtId.Text);

                        foreach (var mahasiswa in mahasiswas)
                        {
                            // change the properties
                            mahasiswa.id = TxtId.Text;
                            mahasiswa.NIM = TxtNim.Text;
                            mahasiswa.Nama = TxtNama.Text;
                            mahasiswa.Email = TxtEmail.Text;
                            //context.mahasiswa_tbl(obj);
                            
                        }
                        context.SaveChanges();
                        SetLayout(ModeForm.ViewData);
                        Alert("data berhasil diupdate");
                        // EF will pick up those changes and save back to the database.

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
                if(id != null)
                {
                    mahasiswa_tbl obj = context.mahasiswa_tbl.First(x => x.id == id);
                    context.mahasiswa_tbl.Remove(obj);
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

        // DropDown Generator

        //private void GenerateAccount()
        //{
        //    TxtAccountNo.Items.Clear();
        //    TxtAccountNo.Items.Insert(0, new ListItem("Tidak memiliki akun", "-1"));

        //    var ret = accountControl.GetDataCustomer();
        //    var datas = ret.Result;

        //    if (datas != null && datas.Count() > 0)
        //    {
        //        TxtAccountNo.DataSource = datas;
        //        TxtAccountNo.DataTextField = "username";
        //        TxtAccountNo.DataValueField = "accountNo";
        //        TxtAccountNo.DataBind();
        //    }

        //    TxtAccountNo.SelectedIndex = 0;
        //}

        // Helper function
        private int ParseInt(string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);

            return ret;
        }

        // Alert
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
        #endregion

        //#region Action function
        //// Action on datagrid table
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
        //// Action Field
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
        //protected void ActionImageButton(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var btn = sender as ImageButton;
        //        var command = btn.CommandName;

        //        switch (command)
        //        {
        //            case "search":
        //                var param = (TxtSearch.Text).Trim();
        //                RefreshGrid(param);
        //                break;

        //            case "refresh":
        //                TxtSearch.Text = "";
        //                RefreshGrid();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert("Terjadi Kesalahan");
        //    }
        //}

        //// Change layout
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
                    //TxtCustomerName.Enabled = true;
                    //TxtCusEmail.Enabled = true;
                    //TxtCompanyName.Enabled = true;
                    //TxtCompanyAddress.Enabled = true;
                    //TxtPhoneNo.Enabled = true;
                    //TxtComEmail.Enabled = true;
                    //TxtAccountNo.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    //GenerateAccount();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtId.Enabled = true;
                    TxtNim.Enabled = true;
                    TxtNama.Enabled = true;
                    TxtEmail.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    BindGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                    //case ModeForm.DetailData:
                    //    GenerateAccount();
                    //    PanelInput.Visible = true;
                    //    PanelGrid.Visible = false;
                    //    TxtCustomerName.Enabled = false;
                    //    TxtCusEmail.Enabled = false;
                    //    TxtCompanyName.Enabled = false;
                    //    TxtCompanyAddress.Enabled = false;
                    //    TxtPhoneNo.Enabled = false;
                    //    TxtComEmail.Enabled = false;
                    //    TxtAccountNo.Enabled = false;
                    //    BtnSave.Visible = false;
                    //    BtnUpdate.Visible = false;
                    //    break;
            }
        }
        ////#endregion

    }

}