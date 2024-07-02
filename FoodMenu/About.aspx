<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FoodMenu.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-3">
        <div class="row row-gap-5">
            <div class="col-6">
                <label>Dish name</label>
                <asp:TextBox
                    ValidationGroup="dish"
                    ID="txtDishName"
                    class="form-control"
                    runat="server" />
                <asp:RequiredFieldValidator
                    Display="Static"
                    CssClass="fa fa-asterisk"
                    Style="color: red"
                    ValidationGroup="dish"
                    ID="txtDishNameValidator"
                    ErrorMessage="This field is required"
                    ControlToValidate="txtDishName"
                    runat="server" />
            </div>
            <div class="col-6">
                <label>Category</label>
                <asp:DropDownList
                    AppendDataBoundItems="true"
                    ValidationGroup="dish"
                    ID="ddlCatCategories"
                    class="form-select"
                    aria-label="Default select example"
                    runat="server">
                    <asp:ListItem Text="Select category" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    Display="Static"
                    CssClass="fa fa-asterisk"
                    Style="color: red"
                    ValidationGroup="dish"
                    ID="ddlCatCategoriesValidator"
                    ErrorMessage="This field is required"
                    ControlToValidate="ddlCatCategories"
                    runat="server" />
            </div>
            <div class="col-6">
                <div class="form-check">
                    <asp:CheckBox
                        class="form-check-input"
                        ID="cbAvailability"
                        runat="server" />
                    <label class="form-check-label" for="flexCheckDefault">
                        Available
                    </label>
                </div>
                
            </div>
            <div class="col-6">
                <label>Description</label>
                <asp:TextBox ID="txtDescription" type="text" class="form-control" runat="server" />
            </div>
            <div class="col-6">
                <label>Price</label>
                <asp:TextBox ID="txtPrice" type="text" class="form-control" runat="server" />
                <asp:RequiredFieldValidator
                    Display="Static"
                    CssClass="fa fa-asterisk"
                    Style="color: red;"
                    ValidationGroup="dish"
                    ID="txtPriceValidator"
                    ErrorMessage="This field is required"
                    ControlToValidate="txtPrice"
                    runat="server" />
            </div>
            <div class="col-6">
                <label>Imagen</label>
                <asp:FileUpload
                    class="form-control"
                    ID="imbDishImageFile"
                    runat="server" />
            </div>
            <div class="col-6"></div>
            <div class="col-6 text-center">
                <asp:Button
                    ValidationGroup="dish"
                    Text="Send"
                    class="btn btn-primary col-3"
                    ID="SendDishData"
                    runat="server"
                    Style="width: 60%;" />
            </div>
        </div>
    </div>
</asp:Content>
