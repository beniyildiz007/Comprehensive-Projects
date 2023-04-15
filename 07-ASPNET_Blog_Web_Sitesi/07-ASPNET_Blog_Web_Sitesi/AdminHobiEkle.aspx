<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminHobiEkle.aspx.cs" Inherits="AdminHobiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtHobi" runat="server" Text="HOBİ"></asp:Label>
                <asp:TextBox ID="txtHobi" runat="server" CssClass="form-control" placeholder="Hobinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>

