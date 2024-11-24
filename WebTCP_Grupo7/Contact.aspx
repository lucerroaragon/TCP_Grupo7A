<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebTCP_Grupo7.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="title-main"><%: Title %></h2>
        
        <div class="row">
            <div class="col-md-6">
                <h2 class="title1-main">Información de Contacto</h2>
                <address class="text-main">
                    <div class="subtitle-main mt-4">Dirección:</div>
                    Calle Ficticia 123<br />
                    Tigre, Buenos Aires, Argentina<br />
                    <abbr title="Teléfono"></abbr> +54 11 1234-5678
                </address>
                <!-- Secciones de soporte y redes sociales omitidas para brevedad -->
            </div>
            
            <div class="col-md-6">
                <h3 class="title1-main">Formulario de Contacto</h3>
                
                <!-- Etiqueta para mensajes -->
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

                <!-- Panel del formulario -->
                <asp:Panel ID="pnlContactForm" runat="server">
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblName" runat="server" Text="Nombre:" AssociatedControlID="txtName" CssClass="form-label" />
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblSurname" runat="server" Text="Apellido:" AssociatedControlID="txtSurname" CssClass="form-label" />
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" CssClass="form-label" />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblPhone" runat="server" Text="Teléfono:" AssociatedControlID="txtPhone" CssClass="form-label" />
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    
                    <div class="mb-3">
                        <asp:Label ID="lblMessageSubject" runat="server" Text="Mensaje:" AssociatedControlID="txtMessage" CssClass="form-label" />
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