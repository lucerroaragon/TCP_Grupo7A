<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="WebTCP_Grupo7.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid d-flex flex-column min-vh-100" >
        <div class="row">
            <!-- Menú lateral fijo (Sticky) -->
            <div class="col-md-2 mt-4">
                <div class="card shadow-sm p-4 sticky-top" style="top: 120px; background-color: #f8f9fa;">
                    <h5 class="fw-bold">Filtrar Panel Admin</h5>

                    <!-- Filtros por Seleccion -->
                    <div class="form-group mt-3">
                        <label for="seleccionarSelect" class="form-label">Seleccionar:</label>
                        <asp:DropDownList ID="ddlSeleccionar" runat="server" CssClass="form-select" AutoPostBack="true"  OnSelectedIndexChanged="ddlSeleccionar_SelectedIndexChanged">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Puntos reciclaje" Value="Puntos reciclaje"></asp:ListItem>
                            <asp:ListItem Text="Usuarios" Value="Usuarios"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Usuario -->
                    <div id="filtrosUsuarios" runat="server" class="form-group mt-3" visible="false">
                        <label for="usuarioSelect" class="form-label">Usuarios:</label>
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Activos" Value="Activos"></asp:ListItem>
                            <asp:ListItem Text="Bajas" Value="Bajas"></asp:ListItem>
                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtros por Puntos reciclaje -->
                    <div id="filtrosPuntos" runat="server" class="form-group mt-3" visible="false">
                        <label for="Select" class="form-label">Puntos reciclaje:</label>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select">
                            <asp:ListItem Text="-" Value="default"></asp:ListItem>
                            <asp:ListItem Text="Sin Validar" Value="Sin Validar"></asp:ListItem>
                            <asp:ListItem Text="Validados" Value="Validados"></asp:ListItem>
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
                        Aquí busca los <span class="fw-bold">Centros de Reciclaje y Usuarios</span>.
                    Filtra por <span class="fw-bold">Puntos de Reciclaje, Usuarios </span>
                    </p>
                </div>

                <!-- Contenedor para los usuarios -->
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="dgvUsuarios" runat="server" Visible="false" DataKeyNames="idUsuario" OnRowCommand="dgvUsuarios_RowCommand" CssClass="table table-bordered border-primary" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" /> 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="ID" DataField="idUsuario" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                                <asp:BoundField HeaderText="Administrador" DataField="Administrador" />

                                <asp:ButtonField CommandName="EditarUser" Text="​​​🛠️​​" HeaderText="Editar" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button Text="Dar de baja" CssClass="btn btn-primary" ID="btnDarBaja" runat="server"  Visible="false" />
                        <asp:Label ID="lblMensaje1" runat="server" CssClass="text-success mt-3 d-block" />
                    </div>

                <!-- Contenedor para los puntos de reciclaje -->
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="dgvPanelAdmin" runat="server" Visible="false" DataKeyNames="idPuntoReciclaje,Estado" OnRowCommand="dgvPanelAdmin_RowCommand" CssClass="table table-bordered border-primary" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="ID" DataField="idPuntoReciclaje" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                                <asp:BoundField HeaderText="Provincia" DataField="Provincia" />
                                <asp:BoundField HeaderText="Municipio" DataField="Municipio" />
                                <asp:BoundField HeaderText="Localidad" DataField="Localidad" />

                                <asp:ButtonField CommandName="Seleccionar" Text="​👁️​​" HeaderText="Ver" />
                                <asp:ButtonField CommandName="Editar" Text="​​​🛠️​​" HeaderText="Editar" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button Text="Aprobar" CssClass="btn btn-primary" ID="btnAprobar" runat="server" OnClick="btnAprobar_Click"  Visible="false" />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success mt-3 d-block" />
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
