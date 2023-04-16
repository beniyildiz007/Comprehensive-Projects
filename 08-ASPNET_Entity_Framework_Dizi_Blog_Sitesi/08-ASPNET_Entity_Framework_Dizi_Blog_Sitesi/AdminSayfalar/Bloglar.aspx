<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Bloglar.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.Bloglar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered">
        <tr>
            <th>ID</th>
            <th>BAŞLIK</th>
            <th>TARİH</th>
            <th>TÜR</th>
            <th>KATEGORİ</th>
            <th>SİL</th>
            <th>GÜNCELLE</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BLOGID") %></td>
                    <td><%# Eval("BLOGBASLIK") %></td>
                    <td><%# Eval("BLOGTARIH") %></td>
                    <td><%# Eval("BLOGTUR") %></td>
                    <td><%# Eval("BLOGKATEGORI") %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl='<%# "BlogSil.aspx?BLOGID="+Eval("BLOGID") %>'>Sil</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "BlogGuncelle.aspx?BLOGID="+Eval("BLOGID") %>'>Güncelle</asp:HyperLink>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <a href="YeniBlog.aspx" class="btn btn-primary">Yeni Blog</a>
</asp:Content>
