<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerificacionEmail.aspx.cs" Inherits="WebTCP_Grupo7.VerificacionEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mt-5">Punto de Reciclaje</h2>
        <p class="text-center mb-5">Ingrese el codigo que le llego a tu email:</p>

        <div class="row d-flex justify-content-center align-item-center p-4 mt-3 mb-5">
            <div class="col-md-6">
                <!-- Nombre del punto -->
                <div class="row g-1">
                    <div class="col-md-12 fw-bold ">
                        <label for="txtCodigo" class="form-label w-bold">Ingresa el codigo</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCodigo" class="form-control" placeholder="Codigo" />
                        <asp:RequiredFieldValidator ErrorMessage="Codigo requerido" ControlToValidate="txtCodigo" runat="server" CssClass="text-danger" />
                    </div>
                </div>
            </div>
            <!-- Botones -->
            <div class="col-12 text-center mt-3 ">
                <asp:Button Text="Validar" CssClass="btn btn-primary" ID="btnValidar" OnClick="btnValidar_Click" runat="server" />
                <asp:Button Text="Cancelar" CssClass="btn btn-secondary ms-2" ID="btnCancelar" runat="server" />
            </div>

        </div>
    </div>
</asp:Content>
