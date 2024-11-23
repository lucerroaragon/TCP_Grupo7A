﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="WebTCP_Grupo7.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            let isValid = true;

            // Validación de Nombre
            const txtNombre = document.getElementById('txtNombre');
            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                isValid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            // Validación de Apellido
            const txtApellido = document.getElementById('txtApellido');
            if (txtApellido.value.trim() === "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                isValid = false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            // Validación de Email
            const txtEmail = document.getElementById('txtEmail');
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (txtEmail.value === "" || !emailPattern.test(txtEmail.value)) {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                isValid = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }
            // Validación de Contraseña (solo si es visible)
            const txtPassword = document.getElementById('<%= txtPassword.ClientID %>');
            const txtConfirmPassword = document.getElementById('<%= txtConfirmPassword.ClientID %>');
            if (txtPassword.offsetParent !== null) {
                if (txtPassword.value.trim() === "" || txtPassword.value !== txtConfirmPassword.value) {
                    txtPassword.classList.add("is-invalid");
                    txtConfirmPassword.classList.add("is-invalid");
                    isValid = false;
                } else {
                    txtPassword.classList.remove("is-invalid");
                    txtConfirmPassword.classList.remove("is-invalid");
                }
            }
      
            
            // Retornar si es válido o no
            return isValid;
        }

    </script>

    <div class="container flex-column min-vh-100" style="margin-top: 50px;">
        <div class="row justify-content-center">
            <div class="form-header text-center">
                <h1 class="form-title">Completa tu información</h1>
                <p class="form-description">Por favor, completa los datos para registrarte.</p>
            </div>


            <div class="row justify-content-center">
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" placeholder="email" />
                    <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
                    <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
                </div>
            </div>


            <div class="row justify-content-center">
                <div class="col-md-6">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" placeholder="apellido" />
                    <asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger" />
                </div>
                <div class="col-md-6">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" placeholder="nombre" />
                    <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
                </div>
            </div>


            <div class="row justify-content-center">
                <div class="col-md-6">
                    <label id="lblPassword" for="txtPassword" class="form-label" runat="server">Contraseña</label>
                    <asp:TextBox runat="server" ID="txtPassword" class="form-control" placeholder="Contraseña" TextMode="Password"/>
                    <asp:RequiredFieldValidator ID="rfvPassword" ErrorMessage="Contraseña requerida" ControlToValidate="txtPassword" runat="server" CssClass="text-danger" />
                </div>
                <div class="col-md-6">
                    <label id="ldlConfirmPassword" for="txtConfirmPassword" class="form-label" runat="server">Confirmar Contraseña</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtConfirmPassword" class="form-control" placeholder="Confirmar Contraseña" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" ErrorMessage="Confirmar Contraseña requerida" ControlToValidate="txtConfirmPassword" runat="server" CssClass="text-danger" />
                    <asp:CompareValidator ErrorMessage="Las contraseñas no coinciden" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" Operator="Equal" runat="server" CssClass="text-danger" />
                </div>

                <div class="modal fade" id="confirmationModal" tabindex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="confirmationModalLabel">Confirmación</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            ¿Estás seguro de que quieres enviar el formulario con los datos ingresados?
           
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button type="button" class="btn btn-primary" id="btnConfirmar">Confirmar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <!-- Botones de acción -->
            <div class="row justify-content-center">
                <div class="col-md-6 text-center">
                    <asp:Button Text="Registrarse" CssClass="btn btn-primary" OnClientClick="return validar();" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" Visible="true" />
                    <asp:Button Text="Modificar" CssClass="btn btn-primary" OnClientClick="return validar();" OnClick="btnModificar_Click" ID="btnModificar" runat="server" Visible="false" />
                </div>
                <div class="col-md-6 text-center">
                    <asp:Button Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
                </div>
          </div>


            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>
