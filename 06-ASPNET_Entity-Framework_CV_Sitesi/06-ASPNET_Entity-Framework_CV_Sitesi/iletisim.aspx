<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="_06_CvEntityProje.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered" style="margin-left: 30px; width: 90%">
        <tr>
            <th>ID</th>
            <th>AD SOYAD</th>
            <th>MAİL</th>
            <th>MESAJI GÖR</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <itemtemplate>
                <tr>
                    <td><%# Eval("ID")  %></td>
                    <td><%# Eval("ADSOYAD")  %></td>
                    <td><%# Eval("MESAJ")  %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-info" NavigateUrl='<%# "MesajDetay.aspx?ID="+Eval("ID") %>'>Mesajı Gör</asp:HyperLink></td>
                </tr>
            </itemtemplate>
        </asp:Repeater>
    </table>


</asp:Content>
