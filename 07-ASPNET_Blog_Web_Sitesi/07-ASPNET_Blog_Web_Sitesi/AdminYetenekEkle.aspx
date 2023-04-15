<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminYetenekEkle.aspx.cs" Inherits="AdminYetenekEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtYetenek" runat="server" Text="YETENEK"></asp:Label>
                <asp:TextBox ID="txtYetenek" runat="server" CssClass="form-control" placeholder="Yeteneğinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>

