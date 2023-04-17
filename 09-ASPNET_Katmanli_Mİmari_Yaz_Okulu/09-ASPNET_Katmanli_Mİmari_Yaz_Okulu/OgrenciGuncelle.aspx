<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OgrenciGuncelle.aspx.cs" Inherits="OgrenciGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <form runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtOgrID" runat="server" Text="Öğrenci ID:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrID" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrAd" runat="server" Text="Öğrenci Adı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrAd" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server" Text="Öğrenci Soyadı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrSoyad" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrNumara" runat="server" Text="Öğrenci Numara:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrNumara" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server" Text="Öğrenci Şifre:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrSifre" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server" Text="Öğrenci Fotoğraf:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrFoto" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Güncelle" ID="btnGuncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click" />


        </div>

    </form>

</asp:Content>

