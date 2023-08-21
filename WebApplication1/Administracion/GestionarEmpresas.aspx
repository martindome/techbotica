﻿<%@ Page Title="Gestionar Empresas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarEmpresas.aspx.cs" Inherits="WebApplication1.Administracion.GestionarEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mb-4">Gestión de Empresas</h2>
        
        <asp:TextBox ID="SearchCompanyByNameTextBox" runat="server" CssClass="form-control" Placeholder="Buscar empresas por nombre"></asp:TextBox>
        <asp:TextBox ID="SearchCompanyByDescTextBox" runat="server" CssClass="form-control mt-2" Placeholder="Buscar empresas por descripción"></asp:TextBox>
        <asp:Button ID="SearchCompanyButton" runat="server" Text="Buscar" CssClass="btn btn-primary mt-2 mb-2" />

        <asp:GridView ID="CompaniesGrid" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowDeleting="CompaniesGrid_RowDeleting" OnRowEditing="CompaniesGrid_RowEditing">
            <Columns>
                <asp:BoundField DataField="CompanyName" HeaderText="Nombre de la Empresa" />
                <asp:BoundField DataField="CompanyDesc" HeaderText="Descripción" />
                <asp:BoundField DataField="CompanyEmail" HeaderText="Email" />
                <asp:BoundField DataField="CompanyPhone" HeaderText="Teléfono" />
                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" ID="botoneditar" ButtonType="Button" CommandName="Edit" Text="Editar" ControlStyle-CssClass="btn btn-secondary" OnClick="botoneditar_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button runat="server" id="botoneliminar" ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" OnClick="botoneliminar_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="mt-3">
            <asp:Button ID="NewCompanyButton" runat="server" Text="Nueva Empresa" CssClass="btn btn-success" OnClick="NewCompanyButton_Click" />
        </div>
    </div>
</asp:Content>

