﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebTCP_Grupo7.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4"><%: Title %></h2>
        
        <div class="row">
            <div class="col-md-6">
                <h3 class="mb-4">Información de Contacto</h3>
                <address>
                    <strong>Dirección:</strong><br />
                    One Microsoft Way<br />
                    Redmond, WA 98052-6399<br />
                    <abbr title="Teléfono">P:</abbr>
                    425.555.0100
                </address>

                <h4 class="mt-4">Soporte:</h4>
                <p>
                    <a href="mailto:Support@example.com">Support@example.com</a>
                </p>
                
                <h4>Marketing:</h4>
                <p>
                    <a href="mailto:Marketing@example.com">Marketing@example.com</a>
                </p>
            </div>

            <div class="col-md-6">
                <h3 class="mb-4">Formulario de Contacto</h3>
                <asp:Panel ID="pnlContactForm" runat="server">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <div class="mb-3">
                        <asp:Label ID="lblName" runat="server" Text="Nombre:" AssociatedControlID="txtName" />
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblMessageSubject" runat="server" Text="Mensaje:" AssociatedControlID="txtMessage" />
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                    </div>
                   <%-- <asp:Button ID="btnSend" runat="server" Text="Enviar Mensaje" CssClass="btn btn-primary" OnClick="btnSend_Click" />--%>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
