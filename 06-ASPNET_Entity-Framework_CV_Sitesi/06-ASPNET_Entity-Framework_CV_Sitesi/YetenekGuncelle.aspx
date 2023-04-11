<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YetenekGuncelle.aspx.cs" Inherits="_06_CvEntityProje.YetenekGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 30px">
        <h3>YETENEK GÜNCELLEME SAYFASI</h3>
        <br />
        <asp:TextBox ID="txtYetenek" runat="server" placeholder="Yeteneğini gir" CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Yetenek Derecesi..." CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click"/>

    </div>


</asp:Content>
