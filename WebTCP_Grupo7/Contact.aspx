<%@ Page Title="Contactanos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebTCP_Grupo7.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
       <h2 class="text-center mb-4"><%: Title %></h2>
        
        <div class="row">
            <!-- Columna con información de contacto -->
            <div class="col-md-6">
                <h3 class="mb-4">Información de Contacto</h3>
                <address>
                    <strong>Dirección:</strong><br />
                    Calle Ficticia 123<br />
                    Tigre, Buenos Aires, Argentina<br />
                    <abbr title="Teléfono"></abbr> +54 11 1234-5678
                </address>

                <h4 class="mt-4">Soporte:</h4>
                <p>
                    <a href="mailto:support@EcoConecta.com">soporte@ecoconecta.com</a>
                </p>
                
                <h4>Marketing:</h4>
                <p>
                    <a href="mailto:marketing@EcoConecta.com">marketing@ecoconecta.com</a>
                </p>

                <h4>Redes Sociales:</h4>
                <p>
                    <a href="https://www.facebook.com/EcoConecta" target="_blank">Facebook</a> | 
                    <a href="https://twitter.com/EcoConecta" target="_blank">Twitter</a> | 
                    <a href="https://www.instagram.com/EcoConecta" target="_blank">Instagram</a>
                </p>
            </div>

            <!-- Columna con formulario de contacto -->
            <div class="col-md-6">
                <h3 class="mb-4">Formulario de Contacto</h3>
                <p class="text-center mb-4">Rellena los campos a continuación y nos pondremos en contacto contigo.</p>
                <asp:Panel ID="pnlContactForm" runat="server">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <div class="mb-3">
                        <asp:Label ID="lblName" runat="server" Text="Nombre:" AssociatedControlID="txtName" />
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblMessageSubject" runat="server" Text="Mensaje:" AssociatedControlID="txtMessage" />
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                    </div>
                    <div class="mb-3 text-center">
                        <asp:Button ID="btnSend" runat="server" Text="Enviar Mensaje" CssClass="btn btn-primary" OnClick="btnSend_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>