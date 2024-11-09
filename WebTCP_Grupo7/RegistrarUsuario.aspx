<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="WebTCP_Grupo7.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 50px;">
        <div class="row justify-content-center">
            <div class="form-header text-center">
                <h1 class="form-title">Completa tu información</h1>
                <p class="form-description">Por favor, completa los datos para registrarte.</p>
            </div>

            <div class="row justify-content-center">
                 <div class="col-md-3">
                        <label for="txtNombreUsuario" class="form-label">Nombre de usuario</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombreUsuario" class="form-control" placeholder="nombre usuario" />
                    <asp:RequiredFieldValidator ErrorMessage="Nombre de usuario requerido" ControlToValidate="txtNombreUsuario" runat="server" CssClass="text-danger" />
                    </div>
                <div class="col-md-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" placeholder="nombre" />
                    <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
                </div>
                <div class="col-md-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" placeholder="apellido" />
                    <asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" placeholder="email" />
                    <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
                    <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
                </div>

                <div class="col-md-3">
                    <label for="txtPassword" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtPassword" class="form-control" placeholder="Contraseña" TextMode="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="Contraseña requerida" ControlToValidate="txtPassword" runat="server" CssClass="text-danger" />
                    <asp:CompareValidator ErrorMessage="Las contraseñas no coinciden" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" Operator="Equal" runat="server" CssClass="text-danger" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-3">
                    <label for="txtConfirmPassword" class="form-label">Confirmar Contraseña</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtConfirmPassword" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="Confirmar Contraseña requerida" ControlToValidate="txtConfirmPassword" runat="server" CssClass="text-danger" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-1">
                    <asp:Button Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" />
                </div>
                <div class="col-md-1">
                    <asp:Button Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>