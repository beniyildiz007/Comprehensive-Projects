<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminYetenekler.aspx.cs" Inherits="AdminYetenekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>YETENEKLER</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("YETENEK") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminYetenekSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminYetenekGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminYetenekEkle.aspx" runat="server" CssClass="btn btn-info">YETENEK EKLE</asp:HyperLink>
    </form>

</asp:Content>

