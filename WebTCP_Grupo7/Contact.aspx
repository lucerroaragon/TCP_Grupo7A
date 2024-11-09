<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebTCP_Grupo7.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
       <h2 class="title-main"><%: Title %></h2>
        
        <div class="row">
            <!-- Columna con información de contacto -->
            <div class="col-md-6">
                <h2 class="title1-main">Información de Contacto</h2>
                <address class="text-main">
                     <div class="subtitle-main mt-4">Dirección:</div>
                    Calle Ficticia 123<br />
                    Tigre, Buenos Aires, Argentina<br />
                    <abbr title="Teléfono"></abbr> +54 11 1234-5678
                </address>

                <h4 class="subtitle-main mt-4">Soporte:</h4>
                <p class="text-main">
                    <a href="mailto:support@EcoConecta.com">soporte@ecoconecta.com</a>
                </p>
                
                <h4 class="subtitle-main">Marketing:</h4>
                <p class="text-main">
                    <a href="mailto:marketing@EcoConecta.com">marketing@ecoconecta.com</a>
                </p>

                <h4 class="subtitle-main">Redes Sociales:</h4>
                <p class="text-main">
                    <a href="https://www.facebook.com/EcoConecta" target="_blank">Facebook</a> | 
                    <a href="https://twitter.com/EcoConecta" target="_blank">Twitter</a> | 
                    <a href="https://www.instagram.com/EcoConecta" target="_blank">Instagram</a>
                </p>
            </div>

<!-- Columna con formulario de contacto -->
<div class="col-md-6">
    <h3 class="title1-main">Formulario de Contacto</h3>
    <p class="text-main text-center mb-4">Rellena los campos a continuación y nos pondremos en contacto contigo.</p>
    <asp:Panel ID="pnlContactForm" runat="server">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
        
        <!-- Fila de Nombre y Apellido en columnas -->
        <div class="row mb-3">
            <!-- Campo Nombre -->
            <div class="col-md-6">
                <asp:Label ID="lblName" runat="server" Text="Nombre:" AssociatedControlID="txtName" CssClass="form-label" />
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>
            
            <!-- Campo Apellido -->
            <div class="col-md-6">
                <asp:Label ID="lblSurname" runat="server" Text="Apellido:" AssociatedControlID="txtSurname" CssClass="form-label" />
                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" />
            </div>
        </div>

        <!-- Fila de Email y Teléfono en columnas -->
        <div class="row mb-3">
            <!-- Campo Email -->
            <div class="col-md-6">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" CssClass="form-label" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>

            <!-- Campo Teléfono -->
            <div class="col-md-6">
                <asp:Label ID="lblPhone" runat="server" Text="Teléfono:" AssociatedControlID="txtPhone" CssClass="form-label" />
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
            </div>
        </div>
        
        <!-- Campo Mensaje -->
        <div class="mb-3">
            <asp:Label ID="lblMessageSubject" runat="server" Text="Mensaje:" AssociatedControlID="txtMessage" CssClass="form-label" />
            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
        </div>
        
        <!-- Botón Enviar -->
        <div class="mb-3 text-center">
            <asp:Button ID="btnSend" runat="server" Text="Enviar Mensaje" CssClass="btn btn-primary" OnClick="btnSend_Click" />
        </div>
    </asp:Panel>
</div>

        </div>
    </div>
</asp:Content>
