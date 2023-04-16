<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="content-grids">
            <div class="col-md-8 content-main">
                <div class="content-grid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="content-grid-info">
                                <img src='<%# Eval("BLOGGORSEL") %>' alt="" style="height: 500px; max-width: 600px" />
                                <div class="post-info">
                                    <h4><a href='BlogDetay.aspx?ID=<%# Eval("BLOGID") %>'>'<%# Eval("BLOGBASLIK") %>'</a>  '<%# Eval("BLOGTARIH") %>'</h4>
                                    <p>'<%# Eval("BLOGICERIK") %>'</p>
                                    <a href='BlogDetay.aspx?ID=<%# Eval("BLOGID") %>'><span></span>Devamını Oku</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-md-4 content-right">
                <div class="recent">
                    <h3>En Son Bloglar</h3>
                    <ul>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><%# Eval("BLOGBASLIK") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="comments">
                    <h3>Son Yorumlar</h3>
                    <ul>
                        <li><a href="#">Amada Doe </a>on <a href="#">Hello World!</a></li>
                        <li><a href="#">Peter Doe </a>on <a href="#">Photography</a></li>
                        <li><a href="#">Steve Roberts  </a>on <a href="#">HTML5/CSS3</a></li>
                    </ul>
                </div>
                <div class="clearfix"></div>
<%--                <div class="archives">
                    <h3>Arşivler</h3>
                    <ul>
                        <li><a href="#">Ocak 2023</a></li>
                        <li><a href="#">Şubat 2023</a></li>
                        <li><a href="#">Mart 2023</a></li>
                        <li><a href="#">Nisan 2023</a></li>
                    </ul>
                </div>--%>
                <div class="categories">
                    <h3>Kategoriler</h3>
                    <ul>
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><%# Eval("KATEGORIAD") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
