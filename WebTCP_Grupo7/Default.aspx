<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTCP_Grupo7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Menú lateral fijo (Sticky) -->
            <div class="col-md-3 mb-3 mt-4">
                <div class="card shadow-sm p-4 sticky-top" style="top: 120px; background-color: #f8f9fa;">
                    <h5 class="fw-bold">Filtrar Centros de Reciclaje</h5>

                    <!-- Filtros por Ciudad -->
                    <div class="form-group mt-3">
                        <label for="ciudadSelect" class="form-label">Provincia:</label>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>                            
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Municipio -->
                    <div class="form-group mt-3">
                        <label for="municipioSelect" class="form-label">Municipio:</label>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>                            
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Municipio -->
                    <div class="form-group mt-3">
                        <label for="localidadSelect" class="form-label">Localidad:</label>
                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>                            
                        </asp:DropDownList>
                    </div>


                    <!-- Botón de filtro -->
                    <asp:Button ID="Button1" runat="server" Text="Aplicar Filtros" CssClass="btn btn-success mt-4 w-100" OnClick="btnFiltrar_Click" />
                </div>
            </div>

            <!-- Contenido principal -->
            <div class="col-md-9">
                <!-- Descripción de la página -->
                <div class="card shadow-sm p-4 mb-4 mt-4">
                    <p class="lead">
                        Aquí puedes encontrar todos los <span class="fw-bold">Centros de Reciclaje Disponibles</span>.
                        Filtra por <span class="fw-bold">Material, Ciudad o Municipio</span> para encontrar el punto
                        de reciclaje más cercano y adecuado para tus necesidades.
                    </p>
                </div>


                <!-- Contenedor para los puntos de reciclaje -->
                <div class="row">
                    <div class="col-12">
                        <div class="row" id="PuntoReciclajeContainer" runat="server">
                            <!-- Los puntos de reciclaje se llenarán dinámicamente desde el servidor -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

