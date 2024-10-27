<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroPuntoReciclaje.aspx.cs" Inherits="WebTCP_Grupo7.RegistroPuntoReciclaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mt-5">Registro de Punto de Reciclaje</h2>
        <p class="text-center mb-5">Ingrese los datos del punto de reciclaje:</p>

        <div runat="server">
            <div class="row  justify-content-center">

                <!-- Nombre del punto -->
                <div class="col-md-6 col-lg-7 fw-bold ">
                    <label for="txtNombre" class="form-label w-bold">Nombre del Punto de Reciclaje</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" placeholder="nombre" />
                    <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
                </div>

                <!-- Email -->
                <div class="col-md-6 col-lg-7 fw-bold">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" placeholder="email" />
                    <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
                    <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
                </div>

                <!-- Teléfono -->
                <div class="col-md-6 col-lg-7 fw-bold">
                    <label for="txtTelefono" class="form-label">Teléfono</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtTelefono" class="form-control" placeholder="telefono" />
                    <asp:RequiredFieldValidator ErrorMessage="Teléfono requerido" ControlToValidate="txtTelefono" runat="server" CssClass="text-danger" />
                </div>

                <!-- Dirección -->
                <div class="col-md-6 col-lg-7 fw-bold">
                    <label for="txtDireccion" class="form-label">Dirección</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" placeholder="Calle y altura" />
                    <asp:RequiredFieldValidator ErrorMessage="Dirección requerida" ControlToValidate="txtDireccion" runat="server" CssClass="text-danger" />
                </div>

                <!-- Ciudad --> 
                <div class="col-md-6 col-lg-7 fw-bold">
                    <label for="txtCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCiudad" class="form-control" placeholder="ciudad" />
                    <asp:RequiredFieldValidator ErrorMessage="Ciudad requerida" ControlToValidate="txtCiudad" runat="server" CssClass="text-danger" />
                </div>

                <!-- Código Postal -->
                <div class="col-md-6 col-lg-7 fw-bold">
                    <label for="txtCP" class="form-label">Código Postal</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" placeholder="cp" />
                    <asp:RequiredFieldValidator ErrorMessage="Código Postal requerido" ControlToValidate="txtCP" runat="server" CssClass="text-danger" />
                </div>

                <!-- Botones -->
                <div class="col-12 text-center mt-3 ">
                    <asp:Button Text="Registrar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
                    <asp:Button Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
