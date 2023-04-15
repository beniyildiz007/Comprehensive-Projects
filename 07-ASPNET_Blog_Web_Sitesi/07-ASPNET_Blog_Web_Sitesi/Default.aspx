<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Resume - Start Bootstrap Theme</title>

    <!-- Bootstrap core CSS -->
    <link href="Dosyalar/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,700" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Muli:400,400i,800,800i" rel="stylesheet">
    <link href="Dosyalar/vendor/fontawesome-free/css/all.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Dosyalar/css/resume.min.css" rel="stylesheet">
</head>

<body id="page-top">

    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
        <a class="navbar-brand js-scroll-trigger" href="#page-top">
            <span class="d-block d-lg-none">Clarence Taylor</span>
            <span class="d-none d-lg-block">
                <img class="img-fluid img-profile rounded-circle mx-auto mb-2" src="Dosyalar/img/profile.jpg" alt="">
            </span>
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#about">HAKKIMDA</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#experience">DENEYİMLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#education">EĞİTİM HAYATIM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#skills">YETENEKLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#interests">HOBİLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#awards">ÖDÜL VE SERTİFİKALARIM</a>
                </li>
            </ul>
        </div>
    </nav>

    <div class="container-fluid p-0">

        <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="my-auto">
                        <h1 class="mb-0">
                            <asp:Label ID="lblAd" runat="server" Text='<%# Eval("AD") %>'></asp:Label>

                            <span class="text-primary">
                                <asp:Label ID="lblSoyad" runat="server" Text='<%# Eval("SOYAD") %>'></asp:Label></span>
                        </h1>
                        <div class="subheading mb-5">
                            <asp:Label ID="lblAdres" runat="server" Text='<%# Eval("ADRES") %>'></asp:Label><p></p>
                            <asp:Label ID="lblTelefon" runat="server" Text='<%# Eval("MAIL") %>'></asp:Label><p></p>

                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("TELEFON") %>'></asp:Label>
                        </div>
                        <p class="lead mb-5">
                            <asp:Label ID="lblHakkimda" runat="server" Text='<%# Eval("KISANOT") %>'></asp:Label>
                        </p>
                        <div class="social-icons">
                            <a href="https://www.linkedin.com/in/berkan-nihat-yildiz/" target="_blank">
                                <i class="fab fa-linkedin-in"></i>
                            </a>
                            <a href="https://www.instagram.com/beniyildiz007/" target="_blank">
                                <i class="fab fa-instagram"></i>
                            </a>
                            <a href="https://github.com/beniyildiz007" target="_blank">
                                <i class="fab fa-github"></i>
                            </a>
                            <a href="https://www.hackerrank.com/beniyildiz007?hr_r=1" target="_blank">
                                <i class="fab fa-hackerrank"></i>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
            <div class="my-auto">
                <h2 class="mb-5">DENEYİMLERİM</h2>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="resume-item d-flex flex-column flex-md-row mb-5">
                            <div class="resume-content mr-auto">
                                <h3 class="mb-0">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("BASLIK") %>'></asp:Label>
                                </h3>
                                <div class="subheading mb-3">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ALTBASLIK") %>'></asp:Label>
                                </div>
                                <p>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Label>
                                </p>
                            </div>
                            <div class="resume-date text-md-right">
                                <span class="text-primary">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("TARIH") %>'></asp:Label>
                                </span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="education">
            <div class="my-auto">
                <h2 class="mb-5">EĞİTİM HAYATIM</h2>
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div class="resume-item d-flex flex-column flex-md-row mb-5">
                            <div class="resume-content mr-auto">
                                <h3 class="mb-0">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("BASLIK") %>'></asp:Label></h3>
                                <div class="subheading mb-3">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ALTBASLIK") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Label>
                                </div>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("GNOT") %>'></asp:Label>
                                </p>
                            </div>
                            <div class="resume-date text-md-right">
                                <span class="text-primary">
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("TARIH") %>'></asp:Label></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="skills">
            <div class="my-auto">
                <h2 class="mb-5">YETENEKLERİM</h2>

                <div class="subheading mb-3">Programlama Dilleri & Araçlar</div>
                <ul class="list-inline dev-icons">
                    <li class="list-inline-item">
                        <i class="fab fa-html5"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-css3-alt"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-js-square"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-angular"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-php"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-react"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-python"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-node-js"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-wordpress"></i>
                    </li>
                </ul>

                <div class="subheading mb-3">İŞ AKIŞI</div>
                <asp:Repeater ID="Repeater4" runat="server">
                    <ItemTemplate>
                        <ul class="fa-ul mb-0">
                            <li>
                                <i class="fa-li fa fa-check"></i>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("YETENEK") %>'></asp:Label></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="interests">
            <div class="my-auto">
                <h2 class="mb-5">HOBİLERİM</h2>
                <asp:Repeater ID="Repeater5" runat="server">
                    <ItemTemplate>
                        <p>
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("HOBI") %>'></asp:Label>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="awards">
            <div class="my-auto">
                <h2 class="mb-5">SERTİFİKALARIM</h2>
                <asp:Repeater ID="Repeater6" runat="server">
                    <ItemTemplate>
                        <ul class="fa-ul mb-0">
                            <li>
                                <i class="fa-li fa fa-trophy text-warning"></i>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("LINK") %>' Target="_blank"><%# Eval("ODUL") %></asp:HyperLink>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

    </div>

    <!-- Bootstrap core JavaScript -->
    <script src="Dosyalar/vendor/jquery/jquery.min.js"></script>
    <script src="Dosyalar/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="Dosyalar/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for this template -->
    <script src="Dosyalar/js/resume.min.js"></script>

</body>

</html>
