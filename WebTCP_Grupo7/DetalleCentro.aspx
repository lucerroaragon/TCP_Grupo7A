<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCentro.aspx.cs" Inherits="WebTCP_Grupo7.DetalleCentro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="container my-5">
        <h2 class="text-center mb-4">Detalles del Centro de Reciclaje</h2>
        
        <!-- Información del Centro de Reciclaje -->
        <div class="card mb-4">
            <div class="card-header">
                <h5 id="centerName" runat="server">Nombre del Centro de Reciclaje</h5>
            </div>
            <div class="card-body">
                <p><strong>Dirección:</strong> <span id="centerAddress" runat="server"></span></p>
                <p><strong>Teléfono:</strong> <span id="centerPhone" runat="server"></span></p>
                <p><strong>Horario:</strong> <span id="centerHours" runat="server"></span></p>
                <p><strong>Descripción:</strong> <span id="centerDescription" runat="server"></span></p>
            </div>
        </div>

        <!-- Formulario para Comentarios -->
        <h4 class="text-center mb-3">Deja un Comentario</h4>
        <asp:Panel ID="pnlCommentForm" runat="server">
            <asp:Label ID="lblComment" runat="server" Text="Comentario:" AssociatedControlID="txtComment" CssClass="mb-2" />
            <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
            <asp:Button ID="btnSubmitComment" runat="server" Text="Enviar Comentario" CssClass="btn btn-primary mt-2" OnClick="btnSubmitComment_Click" />
        </asp:Panel>

        <!-- Lista de Comentarios -->
        <h4 class="text-center mt-5">Comentarios Anteriores</h4>
        <asp:Repeater ID="rptComments" runat="server">
            <ItemTemplate>
                <div class="border rounded p-3 mb-2">
                    <strong><%# Eval("UserName") %></strong>
                    <p><%# Eval("CommentText") %></p>
                    <small><%# Eval("CommentDate", "{0:dd/MM/yyyy HH:mm}") %></small>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
