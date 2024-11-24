<%@ Page Title="Confirmación de Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionRegistroPunto.aspx.cs" Inherits="WebTCP_Grupo7.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center">
            <i class="fas fa-check-circle text-success fa-5x"></i>
            <h1 class="text-success mt-4">¡Tu punto de reciclaje fue registrado con éxito!</h1>
            <p class="mt-3">
                Hemos recibido la información de tu punto de reciclaje.
                Actualmente, los datos están pendientes de aprobación por parte de nuestro equipo. 
                Este proceso puede tardar hasta <strong>72 horas</strong>.
            </p>
            <p>
                Si necesitas realizar alguna modificación o deseas dejar un comentario adicional, por favor, 
                envía un mensaje a nuestro correo electrónico: 
                <a href="mailto:ejemplo@gmail.com" class="text-primary"> info@DaleRecicla.com</a>.
            </p>
            <p>Gracias por contribuir a un planeta más limpio y sustentable. 🌍</p>
            <a href="Home.aspx" class="btn btn-primary mt-3">
                <i class="fas fa-home"></i> Volver al inicio
            </a>
        </div>
        
        <!-- Agregar la imagen aquí -->
        <div class="text-center mt-5">
            <img src="img/bannerHome.jpg" alt="Imagen destacada" class="img-fluid">
        </div>
    </div>

    <!-- Pie de página fijo en la parte inferior -->
    <footer class="bg-dark text-white text-center py-3">
        <div class="container">
            <p class="mb-0">© 2024 Tu Empresa. Todos los derechos reservados.</p>
        </div>
    </footer>
</asp:Content>
