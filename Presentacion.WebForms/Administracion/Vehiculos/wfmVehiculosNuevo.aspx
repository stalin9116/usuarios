<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmVehiculosNuevo.aspx.cs" Inherits="Presentacion.WebForms.Administracion.Vehiculos.wfmVehiculosNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="2">
                <h3><strong>Vehículo Nuevo</strong></h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="75%" style="height: 35px">
                    <tr>
                        <td>
                            <asp:ImageButton ID="imbNuevo" runat="server" Width="32px" Height="32px" ImageUrl="~/images/icon_nuevo.png"  />
                            <asp:LinkButton ID="lnkNuevo" runat="server" >Nuevo</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbGuardar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/icon_guardar.png"  />
                            <asp:LinkButton ID="lnkGuardar" runat="server" >Guardar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imgRegresar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/regresar.png"  CausesValidation="false"/>
                            <asp:LinkButton ID="lnkRegresar" runat="server"  CausesValidation="false">Vehículos</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="lblIdTitulo" runat="server" Text="Id"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPlacaAnterior" runat="server" Text="Placa Anterior"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtplacaAnterior" runat="server"></asp:TextBox>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPlacaActual" runat="server" Text="Placa Actual"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtplacaActual" runat="server"></asp:TextBox>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblchasis" runat="server" Text="chasis"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtChasis" runat="server"></asp:TextBox>
               
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMotor" runat="server" Text="Motor"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMotor" runat="server"></asp:TextBox>
                
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha Compra"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaCompra" runat="server"></asp:TextBox>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblNpasajeros" runat="server" Text="No. pasajeros"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNpasajeros" runat="server"></asp:TextBox>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCombustible" runat="server" Text="Combustible"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCombustrible" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblTonelaje" runat="server" Text="Tonelaje"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTonelaje" runat="server"></asp:TextBox>
                
            </td>
        </tr>

          <tr>
            <td>
                <asp:Label ID="lblObservacion" runat="server" Text="Obervacion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine"></asp:TextBox>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblYear" runat="server" Text="Año"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlblCilindraje" runat="server"></asp:TextBox>
                
            </td>
        </tr>

      <tr>
            <td>
                <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
            </td>
        </tr>

  
        <tr>
            <td>
                <asp:Label ID="lblcolor" runat="server" Text="Color"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlColor" runat="server"></asp:DropDownList>
                
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList>
                
            </td>
        </tr>


          <tr>
            <td>
                <asp:Label ID="lblPais" runat="server" Text="Pais"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPais" runat="server"></asp:DropDownList>
                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblClase" runat="server" Text="Clase"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlClase" runat="server"></asp:DropDownList>
                
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                
            </td>
        </tr>

    </table>


</asp:Content>
