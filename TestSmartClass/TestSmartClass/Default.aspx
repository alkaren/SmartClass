<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestSmartClass._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Absen Logs</h1>
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField DataField="absen_log" HeaderText="Absen Log"></asp:BoundField>
                    <asp:BoundField DataField="nim" HeaderText="NIM"></asp:BoundField>
                    <asp:BoundField DataField="id_kelas" HeaderText="Kelas"></asp:BoundField>
                    <asp:BoundField DataField="id_matkul" HeaderText="Matakuliah"></asp:BoundField>
                    <asp:BoundField DataField="nid" HeaderText="Dosen"></asp:BoundField>
                    <asp:BoundField DataField="url_foto" HeaderText="Bukti Kehadiran"></asp:BoundField>
                    <asp:TemplateField HeaderText="Bukti Kehadiran">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height = "100" Width = "100" runat="server" 
             ImageUrl='<%# ResolveUrl(Eval("url_foto").ToString()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tanggal_absen" HeaderText="Tanggal"></asp:BoundField>
                    <asp:BoundField DataField="start_time" HeaderText="Mulai Terdetect"></asp:BoundField>
                    <asp:BoundField DataField="last_time" HeaderText="Terakhir Terdetect"></asp:BoundField>
                </Columns>

            </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="validate"/>
    </div>

</asp:Content>
