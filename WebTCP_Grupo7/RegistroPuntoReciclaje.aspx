<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroPuntoReciclaje.aspx.cs" Inherits="WebTCP_Grupo7.RegistroPuntoReciclaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
            const tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                return new bootstrap.Tooltip(tooltipTriggerEl);
            });
        });
    </script>


    <div class="container">
        <h2 class="text-center mt-5">Registro de Punto de Reciclaje</h2>
        <p class="text-center mb-5">Ingrese los datos del punto de reciclaje:</p>

        <div class="row d-flex justify-content-center align-items-center p-4 mt-3 mb-5">
            <div class="col-md-6">
                <!-- Nombre del punto -->
                <div class="row g-1">
                    <div class="col-md-12 fw-bold">
                        <label for="txtNombre" class="form-label">Nombre del Punto de Reciclaje</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" placeholder="Nombre" />
                        <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger d-block" />
                    </div>
                </div>

                <!-- Email y Teléfono -->
                <div class="row g-1">
                    <div class="col-md-6 fw-bold">
                        <label for="txtEmail" class="form-label">Email (opcional)</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" placeholder="email" />
                        <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger d-block" />
                    </div>

                    <div class="col-md-6 fw-bold">
                        <label for="txtTelefono" class="form-label">Teléfono (opcional)</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtTelefono" class="form-control" placeholder="telefono" />
                        <asp:RegularExpressionValidator ErrorMessage="El teléfono debe contener solo números y puede incluir '+' o '-'" ControlToValidate="txtTelefono" ValidationExpression="^\+?[0-9\s\-]{7,15}$" runat="server" CssClass="text-danger d-block" />
                    </div>
                </div>

                <!-- Hora de Apertura y Cierre -->
                <div class="row g-1">
                    <div class="col-md-3 fw-bold">
                        <label for="txtHoraApertura" class="form-label">Hora de Apertura</label>
                        <asp:TextBox ID="txtHoraApertura" runat="server" CssClass="form-control" TextMode="Time" />
                        <asp:RequiredFieldValidator ControlToValidate="txtHoraApertura" ErrorMessage="El horario es obligatorio" runat="server" CssClass="text-danger d-block" />
                    </div>
                    <div class="col-md-3 fw-bold">
                        <label for="txtHoraCierre" class="form-label">Hora de Cierre</label>
                        <asp:TextBox ID="txtHoraCierre" runat="server" CssClass="form-control" TextMode="Time" />
                        <asp:RequiredFieldValidator ControlToValidate="txtHoraCierre" ErrorMessage="El horario es obligatorio" runat="server" CssClass="text-danger d-block" />
                    </div>
                    <div class="col-md-6 fw-bold">
                        <label for="ddlMateriales" class="form-label d-flex align-items-centerl">
                            Materiales Reciclables
                            <span class="fas fas-normal fa-question-circle fa-question-circle-base m-l" data-bs-toggle="tooltip" data-bs-placement="right" title="Mantén presionada la tecla Ctrl (o Cmd en Mac) y haz clic para seleccionar múltiples opciones">❓</span>
                        </label>
                        <asp:ListBox ID="ddlMateriales" runat="server" CssClass="form-select" Rows="3" SelectionMode="Multiple"></asp:ListBox>
                        <asp:RequiredFieldValidator ErrorMessage="Materiales requeridos" ControlToValidate="ddlMateriales" runat="server" CssClass="text-danger d-block" />
                    </div>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <!-- Dirección, Provincia, Municipio, Localidad -->
                        <div class="row g-1">
                            <div class="col-md-6 fw-bold">
                                <label for="txtDireccion" class="form-label">Dirección</label>
                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" placeholder="Calle y altura" />
                                <asp:RequiredFieldValidator ErrorMessage="Dirección requerida" ControlToValidate="txtDireccion" runat="server" CssClass="text-danger d-block" />
                            </div>

                            <div class="col-md-6 fw-bold">
                                <label for="ddlProvincias" class="form-label">Provincia</label>
                                <asp:DropDownList ID="ddlProvincias" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ErrorMessage="Provincia requerida" ControlToValidate="ddlProvincias" runat="server" CssClass="text-danger d-block" />
                            </div>
                        </div>

                        <div class="row g-1">
                            <div class="col-md-6 fw-bold">
                                <label for="ddlMunicipios" class="form-label">Municipio</label>
                                <asp:DropDownList ID="ddlMunicipios" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ErrorMessage="Municipio requerido" ControlToValidate="ddlMunicipios" runat="server" CssClass="text-danger d-block" />
                            </div>

                            <div class="col-md-6 fw-bold">
                                <label for="ddlLocalidad" class="form-label">Localidad</label>
                                <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ErrorMessage="Localidad requerida" ControlToValidate="ddlLocalidad" runat="server" CssClass="text-danger d-block" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <!-- Código Postal -->
                <div class="row g-1">
                    <div class="col-md-6 fw-bold">
                        <label for="txtCP" class="form-label">Código Postal</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" placeholder="cp" />
                        <asp:RequiredFieldValidator ErrorMessage="Código Postal requerido" ControlToValidate="txtCP" runat="server" CssClass="text-danger d-block" />
                    </div>
                </div>
            </div>

            <!-- Imagenes -->
            <div class="col-md-4 fw-bold">
                <label class="form-label">Imagenes</label>
                <asp:FileUpload ID="fileUploadImagenes" runat="server" AllowMultiple="true" />
                <asp:Image ID="txtImgenes" ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" runat="server" CssClass="img-fluid mb-4" />
            </div>

            <!-- Botones -->
            <div class="col-12 text-center mt-3">
                <% if (Request.QueryString["IdPR"] == null)
                    { %>
                <asp:Button Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" ID="btnRegistrar" runat="server" />
                <% }
                    else
                    { %>
                <asp:Button Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" ID="btnModificar" runat="server" />
                <% } %>
                <asp:Button Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClientClick="return confirmarCancelacion();" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" />
            </div>
        </div>
    </div>

    <!-- Script de confirmación -->
    <script type="text/javascript">
        function confirmarCancelacion() {
            return confirm("¿Estás seguro de que deseas cancelar? Todos los cambios no guardados se perderán.");
        }
    </script>
</asp:Content>
