<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YeniYetenekEkle.aspx.cs" Inherits="_06_CvEntityProje.YeniYetenekEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:30px">
        <h3>YENİ YETENEK EKLEME SAYFASI</h3>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Yeteneğini gir" CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Yetenek Derecesi..." CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-info" OnClick="Button1_Click" />

    </div>
</asp:Content>
