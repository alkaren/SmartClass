using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestSmartClass.Controllers;
using TestSmartClass.Models;

namespace TestSmartClass.Pages.Private
{
    public partial class MasterMahasiswa : System.Web.UI.Page
    {
        MahasiswaControlls mahasiswaControl = new MahasiswaControlls();
        enum ModeForm { ViewData, UpdateData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

            //GvData.RowCommand += GvData_RowCommand;
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
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = mahasiswaControl.GetData();
                var datas = ret.ToArray();

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = mahasiswaControl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }

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

        //void LoadDetail(string fid)
        //{
        //    var ret = customerControl.DetailData(fid);
        //    var data = ret.Result;

        //    if (data != null)
        //    {
        //        TxtCustomerNo.Text = data.customerNo.ToString();
        //        TxtCustomerName.Text = data.customerName;
        //        TxtCusEmail.Text = data.customerEmail;
        //        TxtCompanyName.Text = data.companyName;
        //        TxtCompanyAddress.Text = data.companyAddress;
        //        TxtPhoneNo.Text = data.companyPhone;
        //        TxtComEmail.Text = data.companyEmail;

        //        if (data.accountNo != null)
        //        {
        //            TxtAccountNo.SelectedIndex = TxtAccountNo.Items.IndexOf(
        //                TxtAccountNo.Items.FindByValue(data.accountNo.ToString()));
        //        }
        //        else
        //        {
        //            TxtAccountNo.SelectedIndex = 0;
        //        }
        //    }
        //}

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
            var data = new mahasiswa_tbl
            {
                id = TxtId.Text,
                NIM = TxtNim.Text,
                Nama = TxtNama.Text,
                Email = TxtEmail.Text
            };

            //if (TxtAccountNo.SelectedValue != "-1")
            //{
            //    data.accountNo = ParseInt(TxtAccountNo.SelectedValue);
            //}

            var ret = mahasiswaControl.AddData(data);

            if (ret != false )
            {
                //ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        //private void DoDelete(string id)
        //{
        //    var ret = customerControl.DeleteData(id);

        //    if (ret.Result)
        //    {
        //        RefreshGrid();
        //        Alert("Data berhasil dihapus");
        //    }
        //    else
        //    {
        //        Alert("Gagal menghapus data");
        //    }
        //}

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
            RefreshGrid();
        }
        #endregion

        //#region Action function
        //// Action on datagrid table
        //private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    var IDS = e.CommandArgument;
        //    switch (e.CommandName)
        //    {
        //        case "ubah":
        //            SetLayout(ModeForm.UpdateData);
        //            LoadDetail(IDS.ToString().Trim());
        //            break;

        //        case "hapus":
        //            DoDelete(IDS.ToString().Trim());
        //            break;

        //        case "lihat":
        //            SetLayout(ModeForm.DetailData);
        //            LoadDetail(IDS.ToString().Trim());
        //            break;
        //    }
        //}
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

                //case ModeForm.UpdateData:
                //    GenerateAccount();
                //    PanelGrid.Visible = false;
                //    PanelInput.Visible = true;
                //    TxtCustomerName.Enabled = true;
                //    TxtCusEmail.Enabled = true;
                //    TxtCompanyName.Enabled = true;
                //    TxtCompanyAddress.Enabled = true;
                //    TxtPhoneNo.Enabled = true;
                //    TxtComEmail.Enabled = true;
                //    TxtAccountNo.Enabled = true;
                //    BtnSave.Visible = false;
                //    BtnUpdate.Visible = true;
                //    break;

                case ModeForm.ViewData:
                    RefreshGrid();
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