<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_06_CvEntityProje.Default" %>

<!--
Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE html>
<html>
<head>
    <title>Entity CV Projesi</title>
    <!-- custom-theme -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Delightful Profile template Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login sign up Responsive web template, SmartPhone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="/web/application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- //custom-theme -->
    <link href="/web/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!-- js -->
    <script src="/web/js/jquery-2.2.3.min.js"></script>
    <!-- //js -->
    <!-- font-awesome-icons -->
    <link href="/web/css/font-awesome.css" rel="stylesheet">
    <!-- //font-awesome-icons -->
    <link href="/web/css/lightcase.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/web/css/easy-responsive-tabs.css " />
    <link href="//fonts.googleapis.com/css?family=Arsenal:400,400i,700,700i&amp;subset=cyrillic,cyrillic-ext,latin-ext,vietnamese" rel="stylesheet">
</head>
<body>
    <div class="main">
        <h1>YAZILIM KİMLİK KARTI</h1>
        <div class="w3_agile_main_grids">
            <div class="w3layouts_main_grid_left">
                <div class="w3_main_grid_left_grid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <h2><%# Eval("BILGILER") %></h2>
                        </ItemTemplate>
                    </asp:Repeater>
                    <p>Full Stack Software Developer</p>
                    <div class="w3l_figure">
                        <img src="/web/images/profil-min.png" alt="Berkan Nihat Yıldız" style="width:140px; height:140px;" />
                    </div>
                    <ul class="agileinfo_social_icons">
                        <li><a href="https://github.com/beniyildiz007" class="w3_agileits_facebook"><i class="fa fa-github" aria-hidden="true"></i></a></li>
                        <li><a href="https://www.linkedin.com/in/berkan-nihat-yildiz/" class="wthree_twitter"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                        <li><a href="https://www.instagram.com/beniyildiz007/" class="agileinfo_google"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="w3layouts_main_grid_right">
                <div class="w3ls_main_grid_right_grid">
                    <div id="parentHorizontalTab">
                        <ul class="resp-tabs-list hor_1">
                            <li><i class="fa fa-user" aria-hidden="true"></i>HAKKIMDA</li>
                            <li><i class="fa fa-briefcase" aria-hidden="true"></i>ÇALIŞMALARIM</li>
                            <li><i class="fa fa-map-marker" aria-hidden="true"></i>İLETİŞİM</li>
                        </ul>
                        <div class="resp-tabs-container hor_1">
                            <div class="agileits_main_grid_right_grid">
                                <!-- HAKKIMDA YAZISI -->
                                <p style="font-weight: bold; font-size: larger">Eğitim Hayatım</p>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <div><%# Eval("EGITIM") %></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <p style="font-weight: bold; font-size: larger; margin-top: 15px;">İş Deneyimlerim</p>
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <div><%# Eval("ISDENEYIMLERI") %></div>
                                    </ItemTemplate>
                                </asp:Repeater>
<%--                                <div class="wthree_tab_grid_sub">
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>321</h5>
                                        <p>Tweets</p>
                                    </div>
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>213</h5>
                                        <p>Followers</p>
                                    </div>
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>123</h5>
                                        <p>Following</p>
                                    </div>
                                    <div class="clear"></div>
                                </div>--%>
                                <br />
                                <br />
                                <div class="agileits_skills">
                                    <h3>YETENEKLERİM</h3>
                                    <div class="w3_agileits_skills_grid">
                                        <ul>
                                            <asp:Repeater ID="Repeater4" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <label><%# Eval("YETENEK") %></label>
                                                        <span></span>%<%# Eval("DERECE") %></li>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="wthree_main_grid_right_grid">
                                <h3>BİTİRDİĞİM PROJELERİM</h3>
                                <div class="w3_agileits_main_grid_work_grids">
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/1.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/1.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/2.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/2.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/3.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/3.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/4.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/4.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/5.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/5.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/6.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/6.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                            <div class="wthree_main_grid_right_grid">
                                <h3>İLETİŞİM ADRESLERİM</h3>
                                <form action="#" method="post" runat="server">
                                    <div class="agileits_w3layouts_contact_left">
                                        <asp:TextBox ID="txtAd" runat="server" placeholder="Adınız" style="padding:15px"></asp:TextBox>
                                        <asp:TextBox ID="txtMail" runat="server" placeholder="Mail Adersiniz" style="margin:15px 0px; padding:15px;"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Mesajınız" TextMode="MultiLine" style="padding:15px"></asp:TextBox>
                                    </div>
                                    <div class="agileits_w3layouts_contact_right">
                                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6032.791420422463!2d29.216823697311423!3d40.885133896740264!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cac350c8107edd%3A0x1e2dde395846822a!2zU2FwYW4gQmHEn2xhcsSxLCAzNDg5MyBQZW5kaWsvxLBzdGFuYnVs!5e0!3m2!1str!2str!4v1681230584677!5m2!1str!2str" style="border: 0"></iframe>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="agile_submit">
                                        <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" />
                                    </div>
                                </form>
                                <div class="wthree_tab_grid">
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-mobile" aria-hidden="true"></i></li>
                                        <li>Telefon<span>+90 507 932 4972</span></li>
                                    </ul>
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-envelope-o" aria-hidden="true"></i></li>
                                        <li>Mail<span><a href="mailto:yildiz.nihatberkan@gmail.com">yildiz.nihatberkan@gmail.com</a></span></li>
                                    </ul>
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-map-marker" aria-hidden="true"></i></li>
                                        <li>Adres<span>Pendik / İstanbul</span></li>
                                    </ul>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="agileits_copyright">
            <p>© 2017 Delightful Profile. All rights reserved | Design by <a href="http://w3layouts.com/">W3layouts</a></p>
        </div>
    </div>
    <script src="/web/js/easyResponsiveTabs.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //Horizontal Tab
            $('#parentHorizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                tabidentify: 'hor_1', // The tab groups identifier
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
        });
    </script>
    <!-- light-case -->
    <script src="/web/js/lightcase.js"></script>
    <script src="/web/js/jquery.events.touch.js"></script>
    <script>
        $('.showcase').lightcase();
    </script>
    <!-- //light-case -->

</body>
</html>
