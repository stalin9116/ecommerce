<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmDetalleCompra.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Public.wfmDetalleCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <h4>Detalle de Compra</h4>

    <table  Width="95%">
        <tr>
            <td>
                <asp:GridView ID="GdvDetalleCompra" runat="server" Width="95%">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Subtotal: <asp:Label ID="lblSubtotal" runat="server" Text="0.00"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Iva 0%: <asp:Label ID="lblIva0" runat="server" Text="0.00"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                Iva 12%: <asp:Label ID="lblIva12" runat="server" Text="0.00"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                Total compra: <asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>

            </td>
        </tr>
    </table>




</asp:Content>
