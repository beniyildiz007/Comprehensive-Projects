<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OgrenciListesi.aspx.cs" Inherits="OgrenciListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th>Öğrenci ID</th>
            <th>Öğrenci Ad</th>
            <th>Öğrenci Soyad</th>
            <th>Öğrenci Numara</th>
            <th>Öğrenci Şifre</th>
            <th>Öğrenci Fotoğraf</th>
            <th>Bakiye</th>
            <th>İşlemler</th>
        </tr>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("OGRID") %></td>
                        <td><%# Eval("AD") %></td>
                        <td><%# Eval("SOYAD") %></td>
                        <td><%# Eval("NUMARA") %></td>
                        <td><%# Eval("SIFRE") %></td>
                        <td><%# Eval("FOTOGRAF") %></td>
                        <td><%# Eval("BAKIYE") %></td>
                        <td>
                            <asp:HyperLink ID="HyperLink1"  CssClass="btn btn-danger" runat="server" NavigateUrl='<%# "OgrenciSil.aspx?OGRID="+Eval("OGRID") %>'>Sil</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" CssClass="btn btn-success" runat="server" NavigateUrl='<%# "OgrenciGuncelle.aspx?OGRID="+Eval("OGRID") %>'>Güncelle</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

