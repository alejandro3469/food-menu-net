<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FoodMenu.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row row-gap-3 col-6 m-auto align-middle mt-auto">
    
        <asp:FileUpload class="form-control"  ID="imbDishImageFile" runat="server" />

        <div class="col-6">
            <label>Dish name</label>
            <asp:TextBox type="text" class="form-control" runat="server" />
        </div>
        <div class="col-6">
            <label>Category</label>
            <asp:DropDownList ID="Listbox1" class="form-select" aria-label="Default select example" runat="server">
                <asp:ListItem Value="null" Selected="True">Category</asp:ListItem>
                <asp:ListItem Value="null">Entradas</asp:ListItem>
                <asp:ListItem Value="null">Tacos</asp:ListItem>
                <asp:ListItem Value="null">Pizzas</asp:ListItem>
            </asp:DropDownList>
        </div>


        <div class="row col-6">
            <div class="form-check">
                <asp:CheckBox class="form-check-input" ID="flexCheckDefault" runat="server" />
                <label class="form-check-label" for="flexCheckDefault">
                    Available
                </label>
            </div>
        </div>

        <div class="col-6">
            <label>Description</label>
            <asp:TextBox type="text" class="form-control" runat="server" />
        </div>
        <div class="col-6">
            <label>Price</label>
            <asp:TextBox type="text" class="form-control" runat="server" />
        </div>



    </div>
    <asp:Button Text="Send" class="btn btn-primary col-3" ID="MyButton" runat="server" />


</asp:Content>
