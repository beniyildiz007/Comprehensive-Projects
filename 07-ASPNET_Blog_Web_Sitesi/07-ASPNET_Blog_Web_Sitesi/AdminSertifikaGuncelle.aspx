<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminSertifikaGuncelle.aspx.cs" Inherits="AdminSertifikaGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSertifika" runat="server" Text="SERTİFİKA ADI"></asp:Label>
                <asp:TextBox ID="txtSertifika" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtLink" runat="server" Text="LİNK"></asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="GÜNCELLE" OnClick="btnGuncelle_Click" />

        </div>
    </form>

</asp:Content>

