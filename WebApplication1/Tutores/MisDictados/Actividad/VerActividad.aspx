﻿<%@ Page Title="Ver Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerActividad.aspx.cs" Inherits="WebApplication1.Tutores.MisDictados.Actividad.VerActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
        <h2 class="mt-4">Ver Actividad</h2>

        <div class="row">
            <div class="col-md-8">
                <!-- Nombre del Material -->     
                <asp:Label ID="actividadNameLable" runat="server" CssClass="form-control-plaintext"></asp:Label>
                <br />
                <hr />
                <asp:Label ID="actividadFechaLabel" runat="server" CssClass="form-control-plaintext"></asp:Label>
                <br />
                <hr />
                <h3>Documento</h3>
                <!-- Visualizador de PDF -->
                <asp:Literal ID="pdfViewer" runat="server"></asp:Literal>
                <br />
                <!-- Botón de Descarga -->
                <asp:Button ID="btnDownload" CssClass="btn btn-primary" Text="Descargar" runat="server" OnClick="btnDownload_Click"/>
                <!-- Lista de Entregas -->
                <h3 class="mt-4">Entregas</h3>
                <asp:GridView ID="deliveriesGrid" CssClass="table mt-4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="Estudiante">
                            <ItemTemplate>
                                <%# Eval("Estudiante.Email") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnViewDelivery" CssClass="btn btn-secondary" Text="Ver" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="btnViewDelivery_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-secondary" Text="Atrás" runat="server" onclick="btnBack_Click"/>
    </div>
</asp:Content>
