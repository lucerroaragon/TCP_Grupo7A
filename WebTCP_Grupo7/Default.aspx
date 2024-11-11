<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTCP_Grupo7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Menú lateral fijo fuera de la sección de contenido -->
    

    <!-- Contenido principal con desplazamiento a la derecha del menú lateral fijo -->
    <section style="margin-left: 270px;">
        <div class="position-fixed card shadow-sm p-4" style="width: 350px; height: 65vh; top: 120px; left: 30px; background-color: #f8f9fa; padding: 20px;">
            <h5 class="fw-bold">Filtrar Centros de Reciclaje</h5>

            <!-- Filtros por Material -->
            <div class="form-group mt-3 ">
                <label for="materialSelect" class="form-label">Material:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
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
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
                    <asp:ListItem Text="-" Value="default"></asp:ListItem>
                    <asp:ListItem Text="Ciudad A" Value="CiudadA"></asp:ListItem>
                    <asp:ListItem Text="Ciudad B" Value="CiudadB"></asp:ListItem>
                    <asp:ListItem Text="Ciudad C" Value="CiudadC"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Filtros por Municipio -->
            <div class="form-group mt-3">
                <label for="municipioSelect" class="form-label">Municipio:</label>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select">
                    <asp:ListItem Text="-" Value="default"></asp:ListItem>
                    <asp:ListItem Text="Municipio X" Value="MunicipioX"></asp:ListItem>
                    <asp:ListItem Text="Municipio Y" Value="MunicipioY"></asp:ListItem>
                    <asp:ListItem Text="Municipio Z" Value="MunicipioZ"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Botón de filtro -->
            <asp:Button ID="Button1" runat="server" Text="Aplicar Filtros" CssClass="btn btn-success mt-4 w-100" OnClick="btnFiltrar_Click" />
        </div>
        <div class="container">
            <!-- Descripción de la página -->
            <div class="row mb-4 mt-4">
                <div class="col-12">
                    <div class="card shadow-sm p-4">
                        <p class="lead f-bold">Aquí puedes encontrar todos los<span class="fw-bold"> Centros de Reciclaje Disponibles</span>. Filtra por <span class="fw-bold">Material, Ciudad o Municipio</span> para encontrar el punto de reciclaje más cercano y adecuado para tus necesidades.</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <!-- Contenedor para mostrar los puntos de reciclaje -->
                <div class="col-12">
                    <div class="row" id="PuntoReciclajeContainer" runat="server">
                        <!-- Los puntos de reciclaje se llenarán dinámicamente desde el servidor -->
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
