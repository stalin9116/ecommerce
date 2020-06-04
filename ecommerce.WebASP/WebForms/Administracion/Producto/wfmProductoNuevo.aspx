﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Administracion.Producto.wfmProductoNuevo" %>

<%@ Register Src="~/UserControl/ucCategoria.ascx" TagName="UC_Categoria" TagPrefix="Uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td colspan="2" style="font-size: large">
                <strong>Producto
            </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px">
                Id
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="lblId"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Categoria
            </td>
            <td>
                <%--<asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>--%>
                <Uc1:UC_Categoria ID="UC_Categoria1" runat="server"></Uc1:UC_Categoria>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Codigo
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Nombre
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Precio de Compra
            </td>
            <td>
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 142px">
                Precio de Venta
            </td>
            <td>
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Imagen
            </td>
            <td>
                <asp:FileUpload ID="FileUploadProducto" runat="server" />
            </td>
        </tr>
         <tr>
            <td style="width: 142px">
                Descripcion
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Stock Mínimo
            </td>
            <td>
                <asp:TextBox ID="txtStockMinimo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Stock Máximo
            </td>
            <td>
                <asp:TextBox ID="txtStockMaximo" runat="server"></asp:TextBox>
            </td>
        </tr>

    </table>

</asp:Content>
