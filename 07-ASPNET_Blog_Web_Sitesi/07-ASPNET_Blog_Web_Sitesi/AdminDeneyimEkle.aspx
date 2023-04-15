<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDeneyimEkle.aspx.cs" Inherits="AdminDeneyimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtBaslik" runat="server" Text="BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAltBaslik" runat="server" Text="ALT BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtAltBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAciklama" runat="server" Text="AÇIKLAMA"></asp:Label>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTarih" runat="server" Text="TARİH"></asp:Label>
                <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>

