<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciDefault.aspx.cs" Inherits="OgrenciDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" Enabled="false">Toplam Öğrenci Sayısı: 136</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox2" runat="server" CssClass="form-control" Enabled="false">Toplam Öğretmen Sayısı: 14</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox3" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox4" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox5" runat="server" CssClass="form-control" Enabled="false">En Başarılı Ders: Matematik</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox6" runat="server" CssClass="form-control" Enabled="false">Toplam Atılan Mesaj: 2547</asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Şifre Değiştir" ID="sifreDegistir" class="btn btn-primary" OnClick="guncelle_Click"/>

        </div>
    </form>


</asp:Content>

