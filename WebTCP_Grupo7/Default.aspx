<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTCP_Grupo7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container">
            <!-- Descripción de la página -->
            <div class="row mb-4 mt-4 ">
                <div class="col-12">
                    <div class="card shadow-sm p-4">
                        <p class="lead f-bold">Aquí puedes encontrar todos los<span class="fw-bold"> Centros de Reciclaje Disponibles</span> . Filtra por <span class="fw-bold">Material, Ciudad o Municipio</span> para encontrar el punto de reciclaje más cercano y adecuado para tus necesidades.</p>

                    </div>

                </div>
            </div>



            <!-- Botón para abrir el offcanvas -->
            <button class="btn btn-primary mt-4 mb-4 " type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasFiltro" aria-controls="offcanvasFiltro">
                Filtro
            </button>

            <!-- Offcanvas (drawer) de filtro -->
            <div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasFiltro" aria-labelledby="offcanvasFiltroLabel">
                <div class="offcanvas-header">
                    <h5 id="offcanvasFiltroLabel" class="offcanvas-title">Filtrar Centros de Reciclaje</h5>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <!-- Filtros por Material -->
                    <div class="form-group">
                        <label for="materialSelect" class="form-label">Material:</label>
                        <asp:DropDownList ID="materialSelect" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Plástico" Value="Plástico"></asp:ListItem>
                            <asp:ListItem Text="Vidrio" Value="Vidrio"></asp:ListItem>
                            <asp:ListItem Text="Papel" Value="Papel"></asp:ListItem>
                            <asp:ListItem Text="Metales" Value="Metales"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Ciudad -->
                    <div class="form-group mt-3">
                        <label for="ciudadSelect" class="form-label">Ciudad:</label>
                        <asp:DropDownList ID="ciudadSelect" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Ciudad A" Value="CiudadA"></asp:ListItem>
                            <asp:ListItem Text="Ciudad B" Value="CiudadB"></asp:ListItem>
                            <asp:ListItem Text="Ciudad C" Value="CiudadC"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Municipio -->
                    <div class="form-group mt-3">
                        <label for="municipioSelect" class="form-label">Municipio:</label>
                        <asp:DropDownList ID="municipioSelect" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Municipio X" Value="MunicipioX"></asp:ListItem>
                            <asp:ListItem Text="Municipio Y" Value="MunicipioY"></asp:ListItem>
                            <asp:ListItem Text="Municipio Z" Value="MunicipioZ"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Botón de filtro -->
                    <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" CssClass="btn btn-success mt-4 w-100" OnClick="btnFiltrar_Click" />
                </div>
            </div>

            <!-- Contenedor para mostrar los puntos de reciclaje -->
            <div class="row" id="PuntoReciclajeContainer" runat="server">
                <!-- Los puntos de reciclaje se llenarán dinámicamente desde el servidor -->
            </div>
        </div>
    </section>
</asp:Content>
