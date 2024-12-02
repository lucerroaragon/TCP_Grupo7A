<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="WebTCP_Grupo7.RegistrarUsuario" %>

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

        function confirmarCancelacion() {
            return confirm("¿Estás seguro de que deseas cancelar el registro?");
        }

    </script>

    <div class="container flex-column min-vh-100 mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="text-center mb-4">
                    <h1 class="h3 mb-2">Completa tu información</h1>
                    <p class="lead">Por favor, completa los datos para registrarte.</p>
                </div>

                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger text-center mb-3" Visible="false"></asp:Label>

                <!-- Formulario -->
                <asp:Panel ID="formPanel" runat="server" CssClass="form">
                    <!-- Campo Nombre y Apellido -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" placeholder="Nombre" />
                            <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
                        </div>
                        <div class="col-md-6">
                            <label for="txtApellido" class="form-label">Apellido</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" placeholder="Apellido" />
                            <asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger" />
                        </div>
                    </div>

                    <!-- Campo Email -->
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" placeholder="Email" />
                        <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
                        <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
                    </div>

                    <!-- Contraseña y Confirmar Contraseña -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label id="lblPassword" for="txtPassword" class="form-label" runat="server" >Contraseña</label>
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" class="form-control" placeholder="Contraseña" />
                            <asp:RequiredFieldValidator ID="rfvPassword" ErrorMessage="Contraseña requerida" ControlToValidate="txtPassword" runat="server" CssClass="text-danger" />
                        </div>
                        <div class="col-md-6">
                            <label id="ldlConfirmPassword" for="txtConfirmPassword" class="form-label" runat="server" >Confirmar Contraseña</label>
                            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" class="form-control" placeholder="Confirmar Contraseña" />
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" ErrorMessage="Confirmar Contraseña requerida" ControlToValidate="txtConfirmPassword" runat="server" CssClass="text-danger" />
                            <asp:CompareValidator ErrorMessage="Las contraseñas no coinciden" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" Operator="Equal" runat="server" CssClass="text-danger" />
                        </div>
                    </div>

                    <!-- Botones -->
                    <div class="row justify-content-center mb-4">
                        <div class="col-6 text-center">
                            <asp:Button Text="Registrarse" CssClass="btn btn-primary" OnClientClick="return validar();" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" Visible="true" />
                            <asp:Button Text="Modificar" CssClass="btn btn-warning" OnClientClick="return validar();" OnClick="btnModificar_Click" ID="btnModificar" runat="server" Visible="false" />
                        </div>
                    </div>

                    <!-- Botón Cancelar -->
                    <div class="row justify-content-center">
                        <div class="col-6 text-center">
                            <asp:Button Text="Cancelar" CssClass="btn btn-secondary"
                                OnClientClick="return confirmarCancelacion();"
                                OnClick="btnCancelar_Click" ID="Button1" runat="server" />
                        </div>
                    </div>



                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
