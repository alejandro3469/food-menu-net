<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hospital.aspx.cs" Inherits="FoodMenu.Hospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvDoctores" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="Id_Doctor,Id_Sexo_Doctor,Id_Intervencion_Doctor,Id_Turno_Doctor" OnRowCancelingEdit="gvDoctores_RowCancelingEdit" OnRowDeleting="gvDoctores_RowDeleting" OnRowEditing="gvDoctores_RowEditing" OnRowUpdating="gvDoctores_RowUpdating" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvDoctores_PageIndexChanging" PageSize="5" OnSorting="gvDoctores_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="[Nombre]">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Nombre_Doctor") %>' ID="txtNombreEIT"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Nombre_Doctor") %>' ID="Label1"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Nombre:
                    <br />
                    <asp:TextBox ID="txtNombreFT" Width="75px" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Paterno]" SortExpression="Paterno_Doctor">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Paterno_Doctor") %>' ID="txtPaternoEIT"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Paterno_Doctor") %>' ID="Label2"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Paterno:
                    <br />
                    <asp:TextBox ID="txtPaternoFT" Width="75px" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Materno]">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Materno_Doctor") %>' ID="txtMaternoEIT"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Materno_Doctor") %>' ID="Label3"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Materno:
                    <br />
                    <asp:TextBox ID="txtMaternoFT" Width="75px" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Fecha]">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Fecha_Naci_Doctor", "{0:dd/MM/yyyy}") %>' ID="txtFechaEIT"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Fecha_Naci_Doctor", "{0:dd/MM/yyyy}") %>' ID="Label4"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Fecha:
                    <br />
                    <asp:TextBox ID="txtFechaFT" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Sexo]">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlSexoEIT"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Sexo.Nombre_Sexo") %>' ID="Label5"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Sexo:
                    <br />
                    <asp:DropDownList ID="ddlSexoFT" Width="75px" runat="server"></asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Intervencion]">
                <EditItemTemplate>
                    <asp:RadioButtonList runat="server" ID="rbInterEIT"></asp:RadioButtonList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Intervencion.Nombre_Intervencion") %>' ID="Label6"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Intervencion:
                    <br />
                    <asp:RadioButtonList ID="rbInterFT" Width="75px" runat="server"></asp:RadioButtonList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Turno]">
                <EditItemTemplate>
                    <asp:CheckBoxList runat="server" ID="chkTurnoEIT"></asp:CheckBoxList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Turno.Nombre_Turno") %>' ID="Label7"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Turno:
                    <br />
                    <asp:CheckBoxList ID="chkTurnoFT" Width="75px" runat="server"></asp:CheckBoxList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Tel&#233;fono]">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Telefono_Doctor") %>' ID="txtTeleEIT"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Telefono_Doctor") %>' ID="Label8"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Teléfono:
                    <br />
                    <asp:TextBox ID="txtTeleFT" Width="75px" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="[Editar]" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="lnkActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click">Agregar</asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="[Borrar]" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBorrar" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

        <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
</asp:Content>
