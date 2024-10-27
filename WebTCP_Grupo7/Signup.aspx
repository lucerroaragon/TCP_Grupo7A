<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebTCP_Grupo7.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4">Registro de Usuario</h2>
        <asp:Panel ID="pnlSignUpForm" runat="server" CssClass="mx-auto" style="max-width: 600px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="text-center d-block mb-3"></asp:Label>
            
            <div class="row">
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" AssociatedControlID="txtApellido" />
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" AssociatedControlID="txtDNI" />
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico:" AssociatedControlID="txtEmail" />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" AssociatedControlID="txtTelefono" />
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" AssociatedControlID="txtDireccion" />
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" AssociatedControlID="txtPassword" />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="col-md-6 mb-4">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmar Contraseña:" AssociatedControlID="txtConfirmPassword" />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnSignUp" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnSignUp_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
