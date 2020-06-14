<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="MasterKelas.aspx.cs" Inherits="TestSmartClass.Pages.Private.MasterKelas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                 <div class="card card-warning">
                     <div class="card-header">
                      <h3 class="card-title">Data Tabel Kelas</h3>
                    </div>

                     <div class="card-body">
                         <asp:GridView OnPageIndexChanging="GvData_PageIndexChanging" CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="true" PagerSettings-Mode="NumericFirstLast" AllowSorting="true" EmptyDataText="Data Kosong">
                        <Columns>
                            <asp:BoundField DataField="id_kelas" HeaderText="ID Kelas" />
                            <asp:BoundField DataField="nama_kelas" HeaderText="Nama Kelas" />
                            <asp:TemplateField HeaderText="Aksi">
                                <ItemTemplate>
                                    <table id="example1">
                                        <tr>
                                            <td>
                                                <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("id_kelas") %>' CommandName="ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("id_kelas") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                        </Columns>
                    </asp:GridView>
                     </div>
                 </div>
                <asp:Button CssClass="btn btn-warning" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton"/>
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                
                <div class="card card-warning">
              <div class="card-header">
                <h3 class="card-title">Master Form Kelas</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                <div class="card-body">
                  <div class="form-group">
                    <label for="id">ID Kelas</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtId" TextMode="SingleLine" CssClass="form-control" name="idkls"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtId" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi ID Kelas"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="nim">Nama Kelas</label>
                      <asp:TextBox runat="server" ID="TxtNama" TextMode="SingleLine" CssClass="form-control" name="nama"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtNama" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi Nama Kelas"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-warning" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton"/>
                      <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton"/>
                    <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Ubah" CommandName="update" OnClick="ActionButton"/>
                  <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
                </div>
              </form>
            </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script>
        $(document).ready(function () {
            $('#<%= GvData.ClientID %>').DataTable();
    </script>

</asp:Content>
