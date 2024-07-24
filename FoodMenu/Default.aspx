<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FoodMenu._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Carousel Start -->
    <div class="header-carousel owl-carousel">
        <div class="header-carousel-item">
            <img src="img/carousel-1.jpg" class="img-fluid w-100" alt="Image">
            <div class="carousel-caption">
                <div class="carousel-caption-content p-3">
                    <h5 class="text-white text-uppercase fw-bold mb-4" style="letter-spacing: 3px;">Comida Mexicana</h5>
                    <h1 class="display-1 text-capitalize text-white mb-4">Los mejores platillos regionales</h1>
                    <p class="mb-5 fs-5">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
                    </p>
                    <a class="btn btn-primary rounded-pill text-white py-3 px-5" href="#">Book Appointment</a>
                </div>
            </div>
        </div>
        <div class="header-carousel-item">
            <img src="img/carousel-2.jpg" class="img-fluid w-100" alt="Image">
            <div class="carousel-caption">
                <div class="carousel-caption-content p-3">
                    <h5 class="text-white text-uppercase fw-bold mb-4" style="letter-spacing: 3px;">Gastronimia Internacional</h5>
                    <h1 class="display-1 text-capitalize text-white mb-4">Disfruta de comida intenacional</h1>
                    <p class="mb-5 fs-5 animated slideInDown">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                    </p>
                    <a class="btn btn-primary rounded-pill text-white py-3 px-5" href="#">Book Appointment</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Carousel End -->
    <hr />

    <div class="row">
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div class="navbar-nav">
                        <a class="nav-link" aria-current="page" href="#entradas">Entradas</a>
                        <a class="nav-link" aria-current="page" href="#tacos">Tacos</a>
                        <a class="nav-link" aria-current="page" href="#pizzas">Pizzas</a>
                        <a class="nav-link" aria-current="page" href="#">A la parrilla</a>
                        <a class="nav-link" aria-current="page" href="#">Hamburquesas</a>
                        <a class="nav-link" aria-current="page" href="#">Hot dogs</a>
                        <a class="nav-link" aria-current="page" href="#">Alitas</a>
                        <a class="nav-link" aria-current="page" href="#">Costillas</a>
                        <a class="nav-link" aria-current="page" href="#">Ensaladas</a>
                        <a class="nav-link" aria-current="page" href="#">Postres</a>
                    </div>
                </div>
            </div>
        </nav>
    </div>


    <div class="container row">
        <asp:GridView ID="gvDishes" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowFooter="True" AutoGenerateColumns="False"
            DataKeyNames="Id, Category"
            OnRowEditing="gvDoctores_RowEditing"
            OnRowUpdating="gvDishes_RowRowUpdating"
            OnRowCancelingEdit="gvDishes_RowCancelingEdit"
            OnRowDeleting="gvDishes_RowDeleting" 
            AllowPaging="True"
            AllowSorting="True"
            PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Name") %>' ID="txtNombreEIT"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="Label1"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Name:
                    <br />
                        <asp:TextBox ID="txtDishNameFT" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Paterno_Doctor">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Description") %>' ID="txtDescriptionEIT"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Description") %>' ID="Label2"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Description:
                    <br />
                        <asp:TextBox ID="txtDescriptionFT" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Availability">
                    <EditItemTemplate>
                        <asp:CheckBox runat="server" Checked='<%# Bind("Availability") %>' ID="txtAvailabilityEIT"></asp:CheckBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox Enabled="false" runat="server" Checked='<%# Bind("Availability") %>' ID="cbAvailability"></asp:CheckBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        Availability:
                    <br />
                        <asp:CheckBox ID="cbAvailabilityFT" Width="75px" runat="server"></asp:CheckBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Price") %>' ID="txtPriceEIT"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Price") %>' ID="Label4"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Price:
                    <br />
                        <asp:TextBox ID="txtPriceFT" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Image") %>' ID="txtImageEIT"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Image") %>' ID="lblImage"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Image:
                    <br />
                        <asp:TextBox ID="txtImageFT" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlCatCategoriesEIT"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("Category") %>' ID="lblCategory"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Category:
                    <br />
                        <asp:DropDownList ID="ddlCatCategoriesFT" Width="75px" runat="server"></asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EDIT" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="UPDATE"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="CANCEL"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="EDIT"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click">ADD</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DELETE" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBorrar" runat="server"
                            OnClientClick="return confirm('Are you sure you want to delete this item');"
                            CausesValidation="False"
                            CommandName="Delete"
                            Text="DELETE"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
