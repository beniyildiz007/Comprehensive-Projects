<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MesajDetay.aspx.cs" Inherits="_06_CvEntityProje.MesajDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 30px; max-width: 500px;">
        <h3>MESAJ DETAYLARI</h3>
        <br />
        <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtMesaj" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="btnMesajlar" runat="server" Text="MESAJLARIM" CssClass="btn btn-info" OnClick="btnMesajlar_Click"/>

    </div>

</asp:Content>
