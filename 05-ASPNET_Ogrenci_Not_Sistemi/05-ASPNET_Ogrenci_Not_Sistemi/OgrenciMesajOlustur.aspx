<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciMesajOlustur.aspx.cs" Inherits="OgrenciMesajOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtGonderen" runat="server">Gönderen</asp:Label>
                <asp:TextBox ID="txtGonderen" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAlici" runat="server">Alıcı</asp:Label>
                <asp:TextBox ID="txtAlici" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtMesajBaslik" runat="server">Mesaj Başlık</asp:Label>
                <asp:TextBox ID="txtMesajBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtIcerik" runat="server">Mesaj İçerik</asp:Label>
                <textarea id="txtIcerik" cols="20" rows="7" class="form-control" runat="server"></textarea>
            </div>
        </div>
        <asp:Button runat="server" Text="Mesaj Gönder" ID="btnGonder" class="btn btn-info" OnClick="btnGonder_Click" />

    </form>

</asp:Content>

