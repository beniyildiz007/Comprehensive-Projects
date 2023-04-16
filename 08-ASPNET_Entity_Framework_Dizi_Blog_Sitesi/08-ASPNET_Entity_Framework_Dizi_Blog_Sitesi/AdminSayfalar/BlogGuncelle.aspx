<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BlogGuncelle.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.BlogGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" class="form-group">
        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control" placeholder="Blog Başlık"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control" placeholder="Blog Tarih"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtGorsel" runat="server" CssClass="form-control" placeholder="Blog Görsel"></asp:TextBox>
        <br />
        <asp:DropDownList ID="drpTur" runat="server" CssClass="form-control" DataTextField="TURAD" DataValueField="TURID"></asp:DropDownList>
        <br />
        <asp:DropDownList ID="drpKategori" runat="server" CssClass="form-control" DataTextField="KATEGORIAD" DataValueField="KATEGORIID"></asp:DropDownList>
        <br />
        <asp:TextBox ID="txtIcerik" runat="server" CssClass="form-control" placeholder="Blog İçerik" TextMode="multiline" Height="200px"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click" />
    </form>

</asp:Content>
