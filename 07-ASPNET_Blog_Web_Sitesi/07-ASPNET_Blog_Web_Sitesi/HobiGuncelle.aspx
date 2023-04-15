<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="HobiGuncelle.aspx.cs" Inherits="HobiGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <div>
                <asp:Label for="txtHobi" runat="server" Text="HOBİ"></asp:Label>
                <asp:TextBox ID="txtHobi" runat="server" CssClass="form-control" placeholder="Hobinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click"/>

        </div>
    </form>

</asp:Content>

