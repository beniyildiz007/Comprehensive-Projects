<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminSertifikaEkle.aspx.cs" Inherits="AdminSertifikaEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtSertifika" runat="server" Text="SERTİFİKA ADI"></asp:Label>
                <asp:TextBox ID="txtSertifika" runat="server" CssClass="form-control" placeholder="Sertifikanın adını girin..."></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtLink" runat="server" Text="LİNK"></asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control" placeholder="Sertifikanın linkini girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click"/>

        </div>
    </form>

</asp:Content>

