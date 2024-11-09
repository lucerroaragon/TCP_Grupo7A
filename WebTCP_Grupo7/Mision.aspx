<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mision.aspx.cs" Inherits="WebTCP_Grupo7.Mision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-md-10 text-center">
                <h2 class="display-4">Nuestra Misión</h2>
                <p class="lead mb-4">
                    En DaleRecicla, nuestra misión es promover una cultura de reciclaje y sostenibilidad
                    en la comunidad, facilitando el acceso a centros de reciclaje y educando a la
                    población sobre la importancia del cuidado del medio ambiente.
                </p>
                <img src="/img/banner.jpg" alt="Misión" class="img-fluid rounded mb-4" />
            </div>
        </div>

        <div class="row justify-content-center my-5">
            <div class="col-md-10 text-center">
                <h2 class="display-4">Nuestros Valores</h2>

                <div class="row">
                    <!-- Card 1 - Sostenibilidad -->
                    <div class="col-md-4">
                        <div class="card card-value">
                            <div class="card-body">
                                <h5 class="card-title">Sostenibilidad</h5>
                                <p>Promovemos la conservación de recursos naturales y la reducción de residuos para preservar el medio ambiente a largo plazo. Nos comprometemos a fomentar un futuro sostenible para las próximas generaciones.</p>
                            </div>
                        </div>
                    </div>

                    <!-- Card 2 - Colaboración -->
                    <div class="col-md-4">
                        <div class="card card-value">
                            <div class="card-body">
                                <h5 class="card-title">Colaboración</h5>
                                <p>Creemos que el trabajo conjunto es fundamental para lograr el éxito. Fomentamos la colaboración entre comunidades, empresas y gobiernos para impulsar proyectos de reciclaje y sostenibilidad.</p>
                            </div>
                        </div>
                    </div>

                    <!-- Card 3 - Educación -->
                    <div class="col-md-4">
                        <div class="card card-value">
                            <div class="card-body">
                                <h5 class="card-title">Educación</h5>
                                <p>Nos enfocamos en educar a las personas sobre la importancia del reciclaje y la reducción de desechos. Creemos que la educación es clave para crear una cultura ambientalmente responsable.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
