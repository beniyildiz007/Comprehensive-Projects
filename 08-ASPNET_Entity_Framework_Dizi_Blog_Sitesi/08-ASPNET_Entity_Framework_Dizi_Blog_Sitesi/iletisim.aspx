<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-content">
        <div class="container">
            <div class="contact-info">
                <h2>İLETİŞİM</h2>
                <p>Blog sayffamızda bulunan film ve dizilere eklemek istedikleriniz için veya yorumlarda yaşayacağınız herhangi bir problem olursa bu panelden bizlere mesaj gönderebilirsiniz. Mesaj gönderme sırasında mutlaka mail adresinizi doğru bir şekilde yazın ki bu mail üzerinden sizlere dönüş yapabilelim.</p>
            </div>
            <div class="contact-details">
                <form runat="server">
                    <asp:TextBox ID="txtAdSoyad" runat="server" placeholder="Ad Soyad" required></asp:TextBox>
                    <asp:TextBox ID="txtMail" runat="server" placeholder="Mail" required></asp:TextBox>
                    <asp:TextBox ID="txtTelefon" runat="server" placeholder="Telefon" required></asp:TextBox>
                    <asp:TextBox ID="txtKonu" runat="server" placeholder="Konu" required></asp:TextBox>
                    <asp:TextBox ID="txtMesaj" runat="server" placeholder="Mesajınız" required TextMode="MultiLine" Height="200px"></asp:TextBox>
                    <asp:Button ID="btnGonder" runat="server" Text="Gönder" OnClick="btnGonder_Click" />
                </form>
            </div>
            <div class="contact-details">
                <div class="col-md-6 contact-map">
                    <div style="max-width:100%;list-style:none; transition: none;overflow:hidden;width:500px;height:500px;"><div id="g-mapdisplay" style="height:100%; width:100%;max-width:100%;"><iframe style="height:100%;width:100%;border:0;" frameborder="0" src="https://www.google.com/maps/embed/v1/place?q=İstanbul,+Türkiye&key=AIzaSyBFw0Qbyq9zTFTd-tUY6dZWTgaQzuU17R8"></iframe></div><a class="googlecoder" rel="nofollow" href="https://www.bootstrapskins.com/themes" id="get-data-for-embed-map">premium bootstrap themes</a><style>#g-mapdisplay img.text-marker{max-width:none!important;background:none!important;}img{max-width:none}</style></div></div>
                <div class="col-md-6 company_address">
                    <h4>Adresimiz</h4>
                    <p>500 Lorem Ipsum Dolor Sit,</p>
                    <p>22-56-2-9 Sit Amet, Lorem,</p>
                    <p>USA</p>
                    <p>Phone:(00) 222 666 444</p>
                    <p>Fax: (000) 123 456 78 0</p>
                    <p>Email: <a href="mailto:info@example.com">info@mycompany.com</a></p>
                    <p>Follow on: <a href="#">Facebook</a>, <a href="#">Twitter</a></p>
                </div>
                <div class="clearfix"></div>
            </div>


        </div>
    </div>



</asp:Content>
