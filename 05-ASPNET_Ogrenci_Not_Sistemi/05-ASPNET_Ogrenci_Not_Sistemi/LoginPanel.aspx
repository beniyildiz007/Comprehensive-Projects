<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPanel.aspx.cs" Inherits="LoginPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Dosyalar1/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 843px;
            margin: auto;
        }

        .auto-style2 {
            margin-bottom: 15px;
            width: 650px;
            margin: auto;
            margin-top: 150px;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div class="auto-style2">
            <h1 class="text-center"><strong>Udemy Web Not Giriş Paneli</strong></h1>
            <br />
            <br />
            <div>
                <em>
                <asp:Label for="txtKullaniciAdi" runat="server" CssClass="auto-style3">Kullanıcı Adı</asp:Label>
                </em>
                <asp:TextBox ID="txtKullaniciAdi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <em>
                <asp:Label for="txtSifre" runat="server" CssClass="auto-style3">Şifre</asp:Label>
                </em>
                <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <strong>
            <asp:Button runat="server" Text="Giriş Yap" ID="girisYap" class="btn btn-warning" Width="650px" Height="50px" Font-Bold="True" OnClick="girisYap_Click" />
            </strong>
            <br />
            <br />
            <strong>
            <asp:Button runat="server" Text="Öğretmen Girişi" ID="Button1" class="btn btn-danger" Width="192px" Height="50px" Font-Bold="True" OnClick="Button1_Click" /></strong>&nbsp;
            <strong>
            <asp:Button runat="server" Text="Şifremi Unuttum" ID="Button2" class="btn btn-default" Width="250px" Height="50px" Font-Bold="True" /></strong>&nbsp;
            <strong>
            <asp:Button runat="server" Text="Yardım" ID="Button3" class="btn btn-info" Width="192px" Height="50px" Font-Bold="True" />

            </strong>

        </div>
    </form>
</body>
</html>
