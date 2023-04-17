<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtOgrAd" runat="server" Text="Öğrenci Adı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrAd" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server" Text="Öğrenci Soyadı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrSoyad" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrNumara" runat="server" Text="Öğrenci Numara:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrNumara" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server" Text="Öğrenci Şifre:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrSifre" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server" Text="Öğrenci Fotoğraf:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrFoto" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Kaydet" id="btnKaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />


        </div>

    </form>
</asp:Content>

