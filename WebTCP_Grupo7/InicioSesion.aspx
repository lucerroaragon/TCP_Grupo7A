<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="WebTCP_Grupo7.InicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 50px;">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h2 class="text-center">Inicio de Sesión</h2>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="text-center d-block mb-3"></asp:Label>
                
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Usuario:" CssClass="form-label" />
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator 
                        ID="rfvUsername" 
                        runat="server" 
                        ControlToValidate="txtUsername" 
                        ErrorMessage="El usuario es obligatorio." 
                        ForeColor="Red" />
                </div>
                
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" CssClass="form-label" />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator 
                        ID="rfvPassword" 
                        runat="server" 
                        ControlToValidate="txtPassword" 
                        ErrorMessage="La contraseña es obligatoria." 
                        ForeColor="Red" />
                </div>
                
                <div class="text-center" style="margin-top: 10px;">
                    <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
                </div>

                <!-- Enlace de Olvidé Contraseña -->
                <div class="text-center mt-3">
                    <a href="RecuperarContrasena.aspx" class="text-muted">¿Olvidaste tu contraseña?</a>
                </div>
                
                <!-- Enlace de Registro para Usuarios no registrados -->
                <div class="text-center mt-2">
                    <p>¿No estás registrado? <a href="RegistrarUsuario.aspx" class="text-muted">Crea una cuenta</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
