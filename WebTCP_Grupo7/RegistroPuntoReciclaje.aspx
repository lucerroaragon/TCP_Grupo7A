<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroPuntoReciclaje.aspx.cs" Inherits="WebTCP_Grupo7.RegistroPuntoReciclaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro de Punto de Reciclaje</h2>
    <p>Ingrese los datos del punto de reciclaje:</p>

    <form class="row g-3">

        <!-- Nombre del punto -->
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtNombre" class="form-label">Nombre del Punto de Reciclaje</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" ReadOnly="true" placeholder="nombre" />
                <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Email y telefono -->
        <div class="row g-3">
            <div class="col-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" ReadOnly="true" placeholder="email" />
                <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
            </div>
            <div class="col-3">
                <label for="txtTelefono" class="form-label">Telefono</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtTelefono" class="form-control" ReadOnly="true" placeholder="telefono" />
                <asp:RequiredFieldValidator ErrorMessage="Telefono requerido" ControlToValidate="txtTelefono" runat="server" CssClass="text-danger" />
            </div>
        </div>
        <!-- Dirección yCiudad -->
        <div class="row g-3">
            <div class="col-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" ReadOnly="true" placeholder="Calle y altura" />
                <asp:RequiredFieldValidator ErrorMessage="Dirección requerida" ControlToValidate="txtDireccion" runat="server" CssClass="text-danger" />
            </div>
            <div class="col-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCiudad" class="form-control" ReadOnly="true" placeholder="ciudad" />
                <asp:RequiredFieldValidator ErrorMessage="Ciudad requerida" ControlToValidate="txtCiudad" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Código Postal -->
        <div class="row g-3">

            <div class="col-md-2">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" ReadOnly="true" placeholder="cp" />
                <asp:RequiredFieldValidator ErrorMessage="Código Postal requerido" ControlToValidate="txtCP" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Botones -->

        <div class="row g-4">
            <div class="col-md-1">
                <asp:Button Text="Registrar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
            </div>
            <div class="col-md-1">
                <asp:Button Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
            </div>
        </div>

    </form>

</asp:Content>
