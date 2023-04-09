<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="OgrenciEkle.aspx.cs" Inherits="OgrenciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtOgrAd" runat="server">Öğrenci Adı</asp:Label>
                <asp:TextBox id="txtOgrAd" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server">Öğrenci Soyadı</asp:Label>
                <asp:TextBox id="txtOgrSoyad" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrTelefon" runat="server">Öğrenci Telefon</asp:Label>
                <asp:TextBox id="txtOgrTelefon" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrMail" runat="server">Öğrenci Mail</asp:Label>
                <asp:TextBox id="txtOgrMail" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server">Öğrenci Şifre</asp:Label>
                <asp:TextBox id="txtOgrSifre" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server">Öğrenci Fotoğraf Linki</asp:Label>
                <asp:TextBox id="txtOgrFoto" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Kaydet" id="kaydet" class="btn btn-info" OnClick="kaydet_Click" />

    </form>
</asp:Content>

