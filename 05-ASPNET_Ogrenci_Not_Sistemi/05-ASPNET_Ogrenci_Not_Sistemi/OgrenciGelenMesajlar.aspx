<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciGelenMesajlar.aspx.cs" Inherits="OgrenciGelenMesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">GÖNDEREN</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">TARİH</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("GÖNDEREN") %></td>
                        <td><%#Eval("BASLIK") %></td>
                        <td><%#Eval("ICERIK") %></td>
                        <td><%#Eval("TARIH") %></td>
                        <%--                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>--%>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>

