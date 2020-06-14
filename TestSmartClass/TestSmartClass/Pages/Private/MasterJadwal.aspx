<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="MasterJadwal.aspx.cs" Inherits="TestSmartClass.Pages.Private.MasterJadwal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                 <div class="card card-warning">
                     <div class="card-header">
                      <h3 class="card-title">Data Tabel Jadwal</h3>
                    </div>

                     <div class="card-body">
                         <asp:GridView OnPageIndexChanging="GvData_PageIndexChanging" CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="true" PagerSettings-Mode="NumericFirstLast" AllowSorting="true" EmptyDataText="Data Kosong">
                        <Columns>
                            <asp:BoundField DataField="id_jadwal" HeaderText="ID Jadwal" />
                            <asp:BoundField DataField="id_ruang" HeaderText="ID Ruang" />
                            <asp:BoundField DataField="id_kelas" HeaderText="ID Kelas" />
                            <asp:BoundField DataField="nid" HeaderText="ID Dosen" />
                            <asp:BoundField DataField="id_matkul" HeaderText="ID Matkul" />
                            <asp:BoundField DataField="tanggal_jadwal" HeaderText="Tanggal Jadwal" />
                            <asp:BoundField DataField="start_kuliah" HeaderText="Start Kuliah" />
                            <asp:BoundField DataField="finish_kuliah" HeaderText="Finish Kuliah" />
                            <asp:TemplateField HeaderText="Aksi">
                                <ItemTemplate>
                                    <table id="example1">
                                        <tr>
                                            <td>
                                                <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("id_jadwal") %>' CommandName="ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("id_jadwal") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
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
                <h3 class="card-title">Master Form Dosen</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form role="form">
                  <div class="card-body">
                  <div class="form-group">
                    <label for="id">ID Jadwal</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtId" TextMode="SingleLine" CssClass="form-control" name="idjdwl"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtId" ValidationGroup="vg1" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Silahkan isi ID Jadwal"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_ruang">ID Ruang</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist1" AutoPostBack="true" CssClass="form-control" name="idruang"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist1" ValidationGroup="vg1" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Silahkan isi ID Ruang"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_kelas">ID Kelas</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist2" AutoPostBack="true" CssClass="form-control" name="idkelas"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist2" ValidationGroup="vg1" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Silahkan isi ID Kelas"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_dosen">ID Dosen</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist3" AutoPostBack="true" CssClass="form-control" name="iddosen"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist3" ValidationGroup="vg1" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Silahkan isi ID Dosen"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_matkul">ID Matkul</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist4" AutoPostBack="true" CssClass="form-control" name="idmatkul"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist4" ValidationGroup="vg1" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Silahkan isi ID Matkul"></asp:RequiredFieldValidator>
                  </div>
                    <!-- Date -->
                    <div class="form-group">
                      <label>Date:</label>
                      <div class="input-group date" id="reservationdate" data-target-input="nearest">
                        <input type="text" class="form-control datetimepicker-input" id="Calender1" data-target="#reservationdate" />
                        <div class="input-group-append" data-target="#reservationdate" data-toggle="datetimepicker">
                          <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                        </div>
                      </div>
                    </div>
                    <!-- time Picker -->
                    <div class="bootstrap-timepicker">
                      <div class="form-group">
                        <label>Start:</label>
                        <div class="input-group date" id="timepicker2" data-target-input="nearest">
                          <input type="text" id="Txtstart" class="form-control datetimepicker-input" data-target="#timepicker2" />
                          <div class="input-group-append" data-target="#timepicker2" data-toggle="datetimepicker">
                            <div class="input-group-text"><i class="far fa-clock"></i></div>
                          </div>
                        </div>
                <!-- /.input group -->
                      </div>
              <!-- /.form group -->
            </div>
            <!-- time Picker finish -->
            <div class="bootstrap-timepicker">
              <div class="form-group">
                <label>Finish:</label>
                <div class="input-group date" id="timepicker" data-target-input="nearest">
                  <input type="text" id="Txtfinish" class="form-control datetimepicker-input" data-target="#timepicker" />
                  <div class="input-group-append" data-target="#timepicker" data-toggle="datetimepicker">
                    <div class="input-group-text"><i class="far fa-clock"></i></div>
                  </div>
                </div>
                <!-- /.input group -->
              </div>
              <!-- /.form group -->
            </div>
          </div>
               <%-- <div class="card-body">
                  <div class="form-group">
                    <label for="id">ID Jadwal</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtId" TextMode="SingleLine" CssClass="form-control" name="idjdwl"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtId" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi ID Jadwal"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_ruang">ID Ruang</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist1" AutoPostBack="true" CssClass="form-control" name="idruang"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist1" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi ID Ruang"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_kelas">ID Kelas</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist2" AutoPostBack="true" CssClass="form-control" name="idkelas"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist2" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silahkan isi ID Kelas"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_dosen">ID Dosen</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist3" AutoPostBack="true" CssClass="form-control" name="iddosen"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist3" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silahkan isi ID Dosen"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <label for="id_matkul">ID Matkul</label>
                    <asp:DropDownList runat="server" ValidationGroup="vg1" ID="Dropdownlist4" AutoPostBack="true" CssClass="form-control" name="idmatkul"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="Dropdownlist1" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silahkan isi ID Matkul"></asp:RequiredFieldValidator>
                  </div>
                    <div class="form-group">
                    <label for="tgljadwal">Tanggal Jadwal</label>
                    <asp:Calendar ID="Calender1" runat="server" SelectionMode="DayWeekMonth" OnSelectionChanged="Calender1_SelectionChanged"></asp:Calendar>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtDate" TextMode="SingleLine" CssClass="form-control" name="date"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtDate" ValidationGroup="vg1" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Silahkan isi Tanggal Jadwal"></asp:RequiredFieldValidator>
                  </div>
                    <div class="form-group">
                    <label for="start">Start Kuliah</label>
                     <asp:Timer ID="Time1" runat="server"></asp:Timer>
                      <asp:TextBox runat="server" ID="TxtTimestart" TextMode="SingleLine" CssClass="form-control" name="start"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtTimestart" ValidationGroup="vg1" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Silahkan isi Jam Start Kuliah"></asp:RequiredFieldValidator>
                  </div>
                    <div class="form-group">
                    <label for="finish">Finish Kuliah</label>
                     <asp:Timer ID="Time2" runat="server"></asp:Timer>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtTimefinish" TextMode="SingleLine" CssClass="form-control" name="finish"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtTimefinish" ValidationGroup="vg1" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Silahkan isi Jam Finish Kuliah"></asp:RequiredFieldValidator>
                  </div>
                </div>--%>
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
    <!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

<!-- jQuery timepicker library -->
<link rel="stylesheet" href="jquery-timepicker/jquery.timepicker.min.css">
<script src="jquery-timepicker/jquery.timepicker.min.js"></script>
    <script src="jquery-1.11.2js"></script>
    <script src="jquery-ui.js"></script>
    <script type="text/javascript">
            $(document).ready(function () {
                $('#TxtDate').datepicker({
                    appendText: 'yyy-mm-dd',
                    shownOn: 'both',
                    buttonText: 'Calender',
                    dateFormat: 'yyy-mm-dd',
                    changeMonth: true,
                    changeYear: true
                })
            })
    </script>
    <script>
            $(document).ready(function(){
                $('#TxtStart').timepicker({
                    timeFormat: 'h:mm:p'
                })
            }
    </script>
     <script>
            $(document).ready(function () {
                $('#TxtFinish').timepicker({
                    timeFormat: 'h:mm:p'
                })
            }
    </script>

</asp:Content>
