<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebTCP_Grupo7.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <!-- Banner de bienvenida -->
        <section class="banner" style="background-image: url('img/bannerHome.jpg'); background-size: cover; background-position: center; text-align: center; color: white; height: 100vh; display: flex; flex-direction: column; justify-content: center; align-items: center;">
            <h1 id="title" style="font-size: 3rem; font-weight: bold; margin-top: 0; padding: 0;">Centros de Reciclaje Cerca de Ti</h1>
            <p class="description" style="font-size: 1.25rem; margin-top: 20px; padding: 0;">Descubre, valora y comparte los centros de reciclaje en tu comunidad. <br>¡Ayuda a mejorar el medio ambiente!</p>

            <!-- Botón Call-to-Action -->
            <section class="cta" style="text-align: center; margin-top: 40px;">
                <a href="Default.aspx" class="btn-cta" style="background-color: #4CAF50; color: white; padding: 15px 30px; text-decoration: none; font-size: 18px; border-radius: 5px;">Ver Centros de Reciclaje</a>
            </section>
        </section>
    </main>
</asp:Content>
