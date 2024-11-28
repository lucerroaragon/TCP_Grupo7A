<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCentro.aspx.cs" Inherits="WebTCP_Grupo7.DetalleCentro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container my-5">
        <div class="position-fixed bottom-0 start-0 p-3" style="z-index: 1050;">
            <!-- Mensaje dinámico -->
            <asp:Label ID="lblMessage" runat="server" CssClass="alert d-none" Visible="false" />
        </div>

        <h2 class="text-center mb-4">Detalles del Centro de Reciclaje</h2>

        <!-- Fila que divide en dos columnas -->
        <div class="row">
            <!-- Columna izquierda: Información del centro -->
            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-header">
                        <h5 id="centerName" runat="server">Nombre del Centro de Reciclaje</h5>
                    </div>
                    <div class="card-body">
                        <p><strong>Dirección:</strong> <span id="centerAddress" runat="server"></span></p>
                        <p><strong>Teléfono:</strong> <span id="centerPhone" runat="server"></span></p>
                        <p><strong>Horario:</strong> <span id="centerHours" runat="server"></span></p>
                        <p><strong>Descripción:</strong> <span id="centerDescription" runat="server"></span></p>
                        <p><strong>Materiales que recicla:</strong> <span id="TipoReciclaje" runat="server"></span></p>
                        <p><strong>Informacion Suministrada por:</strong> <span id="centerInfo" runat="server"></span></p>
                    </div>
                </div>
            </div>

            <!-- Columna derecha: Mapa -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="text-center">Ubicación en el Mapa</h5>
                    </div>
                    <div class="card-body">
                        <!-- IFrame del mapa -->
                        <asp:Literal ID="centerMap" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <div class="row" id="PuntoReciclajeContainer" runat="server">
                    <!-- Los puntos de reciclaje se llenarán dinámicamente desde el servidor -->
                </div>
            </div>
        </div>




        <!-- Formulario para Comentarios -->
        <div class="card shadow-sm mb-4">
            <div class="card-header bg-primary text-white text-center">
                <h4 class="mb-0">Deja un Comentario</h4>
            </div>
            <div class="card-body">
                <asp:Panel ID="pnlCommentForm" runat="server" CssClass="form-group">
                    <!-- Etiqueta e ícono para el comentario -->
                    <label for="txtComment" class="form-label">
                        <i class="bi bi-person-circle me-2"></i>Tu Comentario
                    </label>
                    <!-- Caja de texto -->
                    <asp:TextBox
                        ID="txtComment"
                        runat="server"
                        CssClass="form-control shadow-sm"
                        TextMode="MultiLine"
                        Rows="4"
                        Placeholder="Escribe tu comentario aquí..." />
                    <!-- Botón para enviar -->
                    <asp:Button
                        ID="btnSubmitComment"
                        runat="server"
                        Text="Enviar Comentario"
                        CssClass="btn btn-primary mt-3 w-100 shadow-sm"
                        OnClick="btnSubmitComment_Click"
                        OnClientClick="focusOnCommentBox();" />

                </asp:Panel>
            </div>
        </div>






        <!-- Lista de Comentarios -->
        <h4 class="text-center mt-5">Comentarios Anteriores</h4>
        <asp:Repeater ID="rptComments" runat="server" OnItemCommand="rptComments_ItemCommand">
            <ItemTemplate>
                <div class="card shadow-sm mb-3">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2">
                            <i class="bi bi-person-circle me-2 text-primary" style="font-size: 1.5rem;"></i>
                            <h5 class="mb-0 user-name">
                                <%# Eval("Usuario.Nombre") %> <%# Eval("Usuario.Apellido") %>
                            </h5>
                        </div>
                        <p class="text-secondary mb-2">
                            <%# Eval("Comentario") %>
                        </p>
                        <small class="text-muted">
                            <%# Eval("FechaCometario", "{0:dd/MM/yyyy HH:mm}") %>
                        </small>
                        <!-- Botón de eliminar -->
                        <asp:Button
                            ID="btnDeleteComment"
                            runat="server"
                            Text="Eliminar"
                            CssClass="btn btn-danger btn-sm"
                            CommandName="Delete"
                            CommandArgument='<%# Eval("IdComentario") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>







    </div>
    <script>
        document.addEventListener('DOMContentLoaded', () => {
            applyTitleCaseToComments();
            hideSuccessMessage();
        });

        function toTitleCase(text) {
            return text
                .toLowerCase()
                .split(' ')
                .map(word => word.charAt(0).toUpperCase() + word.slice(1))
                .join(' ');
        }

        function applyTitleCaseToComments() {
            const elements = document.querySelectorAll('.user-name');
            elements.forEach(el => {
                el.textContent = toTitleCase(el.textContent.trim());
            });
        }

        function hideSuccessMessage() {
            const messageLabel = document.getElementById('<%= lblMessage.ClientID %>');
            if (messageLabel) {
                setTimeout(() => {
                    messageLabel.classList.add('d-none'); // Oculta el mensaje
                }, 3000);
            }
        }


        function focusOnCommentBox() {
            // Obtén el control de la caja de comentarios usando el ClientID generado por ASP.NET
            const commentBox = document.getElementById('<%= txtComment.ClientID %>');

            if (commentBox) {
                commentBox.focus();  // Pone el foco en el TextBox
            }
        }
    </script>




</asp:Content>


