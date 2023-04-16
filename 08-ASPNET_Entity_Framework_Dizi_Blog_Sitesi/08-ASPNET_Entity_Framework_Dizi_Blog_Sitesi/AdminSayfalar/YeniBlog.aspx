<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YeniBlog.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.YeniBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" class="form-group">
        <asp:TextBox id="txtBaslik" runat="server" CssClass="form-control" placeholder="Blog Başlık"></asp:TextBox>
        <br />
        <asp:TextBox id="txtTarih" runat="server" CssClass="form-control" placeholder="Blog Tarih"></asp:TextBox>
        <br />
        <asp:TextBox id="txtGorsel" runat="server" CssClass="form-control" placeholder="Blog Görsel"></asp:TextBox>
        <br />
        <asp:DropDownList id="drpTur" runat="server" CssClass="form-control" DataTextField="TURAD" DataValueField="TURID"></asp:DropDownList>
        <br />
        <asp:DropDownList id="drpKategori" runat="server" CssClass="form-control" DataTextField="KATEGORIAD" DataValueField="KATEGORIID"></asp:DropDownList>
        <br />
        <asp:TextBox id="txtIcerik" runat="server" CssClass="form-control" placeholder="Blog İçerik" textmode="multiline" height="200px"></asp:TextBox>
        <br />
        <asp:Button id="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
    </form>

</asp:Content>
