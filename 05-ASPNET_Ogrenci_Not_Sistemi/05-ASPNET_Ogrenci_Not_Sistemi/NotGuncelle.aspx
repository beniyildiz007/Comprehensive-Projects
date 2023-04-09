<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="NotGuncelle.aspx.cs" Inherits="NotGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtDersAdi" runat="server">Ders Adı</asp:Label>
                <asp:TextBox ID="txtDersAdi" Enabled="false" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrID" runat="server">Öğrenci ID</asp:Label>
                <asp:TextBox ID="txtOgrID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrAdSoyad" runat="server">Öğrenci Adı Soyadı</asp:Label>
                <asp:TextBox ID="txtOgrAdSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav1" runat="server">Sınav 1</asp:Label>
                <asp:TextBox ID="txtSinav1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav2" runat="server">Sınav 2</asp:Label>
                <asp:TextBox ID="txtSinav2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav3" runat="server">Sınav 3</asp:Label>
                <asp:TextBox ID="txtSinav3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOrtalama" runat="server">Ortalama</asp:Label>
                <asp:TextBox ID="txtOrtalama" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtDurum" runat="server">Durum</asp:Label>
                <asp:TextBox ID="txtDurum" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Hesapla" ID="hesapla" class="btn btn-toolbar" OnClick="hesapla_Click" />
        <asp:Button runat="server" Text="Güncelle" ID="guncelle" class="btn btn-primary" OnClick="guncelle_Click" />

    </form>


</asp:Content>

