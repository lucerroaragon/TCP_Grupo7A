<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="WebTCP_Grupo7.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            let isValid = true;

            // Nombre
            const txtNombre = document.getElementById('txtNombre');
            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                isValid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            // Apellido
            const txtApellido = document.getElementById('txtApellido');
            if (txtApellido.value.trim() === "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                isValid = false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            // Email
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

            // Contraseña
            const txtContraseña = document.getElementById('txtDireccion');
            if (txtContraseña.value.trim() === "") {
                txtContraseña.classList.add("is-invalid");
                txtContraseña.classList.remove("is-valid");
                isValid = false;
            } else {
                txtContraseña.classList.remove("is-invalid");
                txtContraseña.classList.add("is-valid");
            }

            return isValid;
        }

    </script>
    <div class="container" style="margin-top: 50px;">
        <div class="row justify-content-center">
            <div class="form-header text-center">
                <h1 class="form-title">Completa tu información</h1>
                <p class="form-description">Por favor, completa los datos para registrarte.</p>


                <!-- Nombre y Apellido -->
                <div class="row justify-content-center">
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

                <!-- Email y Contraseña -->
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
                    </div>
                </div>


                <!-- Botones -->
                <div class="row justify-content-center">
                    <div class="col-md-1">
                        <asp:Button Text="Registrarse" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
