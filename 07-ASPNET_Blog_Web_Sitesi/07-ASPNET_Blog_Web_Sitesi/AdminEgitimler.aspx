<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminEgitimler.aspx.cs" Inherits="AdminEgitimler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>BAŞLIK</th>
                <th>ALT BAŞLIK</th>
                <th>AÇIKLAMA</th>
                <th>GENEL NOT ORT</th>
                <th>TARİH</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("BASLIK") %></td>
                            <td><%# Eval("ALTBASLIK") %></td>
                            <td><%# Eval("ACIKLAMA") %></td>
                            <td><%# Eval("GNOT") %></td>
                            <td><%# Eval("TARIH") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminEgitimSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminEgitimGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminEgitimEkle.aspx" runat="server" CssClass="btn btn-info">EĞİTİM EKLE</asp:HyperLink>
    </form>

</asp:Content>

