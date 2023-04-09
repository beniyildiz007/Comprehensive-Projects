<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciGuncelle2.aspx.cs" Inherits="OgrenciGuncelle2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox4" runat="server" CssClass="form-control" Enabled="true">Şifre</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox5" runat="server" CssClass="form-control" Enabled="true">Şifre Tekrar</asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Güncelle" ID="guncelle" class="btn btn-success" OnClick="guncelle_Click"/>

        </div>
    </form>


</asp:Content>

