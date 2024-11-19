<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="WebTCP_Grupo7.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Menú lateral fijo (Sticky) -->
            <div class="col-md-2 mb-3 mt-4">
                <div class="card shadow-sm p-4 sticky-top" style="top: 120px; background-color: #f8f9fa;">
                    <h5 class="fw-bold">Filtrar Panel Admin</h5>

                    <!-- Filtros por Material -->
                    <div class="form-group mt-3">
                        <label for="puntoreciclajeSelect" class="form-label">Puntos reciclaje:</label>
                        <asp:DropDownList ID="ddlPuntoReciclaje" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                            <asp:ListItem Text="Sin Validar" Value="Sin Validar"></asp:ListItem>
                            <asp:ListItem Text="Validados" Value="Validados"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Ciudad -->
                    <div class="form-group mt-3">
                        <label for="usuarioSelect" class="form-label">Usuarios:</label>
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                            <asp:ListItem Text="Activos" Value="Activos"></asp:ListItem>
                            <asp:ListItem Text="Bajas" Value="Bajas"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Municipio -->
                    <div class="form-group mt-3">
                        <label for="Select" class="form-label">:</label>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Botón de filtro -->
                    <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" CssClass="btn btn-success mt-4 w-100" OnClick="btnFiltrar_Click" />
                </div>
            </div>

            <!-- Contenido principal -->
            <div class="col-md-9">
                <!-- Descripción de la página -->
                <div class="card shadow-sm p-4 mb-4 mt-4">
                    <p class="lead">
                        Aquí puedes encontrar todos los <span class="fw-bold">Centros de Reciclaje Disponibles</span>.
                    Filtra por <span class="fw-bold">Puntos de Reciclaje, Usuarios </span>
                    </p>
                </div>


                <!-- Contenedor para los puntos de reciclaje -->
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="dgvPanelAdmin" runat="server" OnRowCommand="dgvPanelAdmin_RowCommand" CssClass="table table-dark table-bordered" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="idPuntoReciclaje" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                                <asp:BoundField HeaderText="Provincia" DataField="Provincia" />
                                <asp:BoundField HeaderText="Municipio" DataField="Municipio" />
                                <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
                                
                                <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" HeaderText="Ver" /> 
                                <asp:ButtonField CommandName="Editar" Text="Editar" HeaderText="Editar" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button Text="Aprobar" CssClass="btn btn-primary" ID="btnAprobar" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
