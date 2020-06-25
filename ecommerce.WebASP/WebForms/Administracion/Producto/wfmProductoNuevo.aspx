<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Administracion.Producto.wfmProductoNuevo" %>

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
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imbNuevo" runat="server" ImageUrl="~/icons/icon_nuevo.png" Width="32px" Height="32px" OnClick="imbNuevo_Click" CausesValidation="false"/>
                            <asp:LinkButton ID="lnkNuevo" runat="server" OnClick="lnkNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbGuardar" runat="server" ImageUrl="~/icons/icon_guardar.png" Width="32px" Height="32px" OnClick="imbGuardar_Click"/>
                            <asp:LinkButton ID="lnkGuardar" runat="server" OnClick="lnkGuardar_Click">Guardar</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Id
            </td>
            <td>
                <asp:Label ID="lblId" runat="server"></asp:Label>
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
                <strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Codigo campo Requerido" ControlToValidate="txtCodigo" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Nombre
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre campo Requerido" ControlToValidate="txtNombre" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Precio de Compra
            </td>
            <td>
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precio compra campo Requerido" ControlToValidate="txtPrecioCompra" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 142px">
                Precio de Venta
            </td>
            <td>
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Precio venta campo Requerido" ControlToValidate="txtPrecioVenta" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Stock mínimo campo Requerido" ControlToValidate="txtStockMinimo" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Stock Máximo
            </td>
            <td>
                <asp:TextBox ID="txtStockMaximo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Stock máximo campo Requerido" ControlToValidate="txtStockMaximo" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 142px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td style="width: 142px">
                Mensaje</td>
            <td>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="#CC3300"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
            </td>
        </tr>

    </table>

</asp:Content>
