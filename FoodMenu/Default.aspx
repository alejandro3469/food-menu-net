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


    <div class="container mt-5">
        <div class="container row">
            <asp:GridView runat="server" ID="gvDishes" AutoGenerateColumns="true">

            </asp:GridView>
        </div>

        <div class="container row">
            <ul>
                <li>Id:
                    <asp:Label ID="lblId" runat="server" /></li>
                <li>Name:
                    <asp:Label ID="lblName" runat="server" /></li>
                <li>Description:
                    <asp:Label ID="lblDesc" runat="server" /></li>
                <li>Availability:
                    <asp:CheckBox ID="chkAvail" runat="server" /></li>
                <li>Price:
                    <asp:Label ID="lblPrice" runat="server" /></li>
                <li>Image:
                    <asp:Image ID="imgImage" runat="server"  Width="200px"/></li>
                <li>Date:
                    <asp:Label ID="lblDate" runat="server" /></li>
            </ul>
        </div>

        <div class="container row" id="entradas">
            <h3>Entradas</h3>
            <div class="card col-12">

                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Tablón de quesos</h5>
                            <p class="card-text"></p>
                            <p class="card-text">Queso panela, de cabra o manchego, focaccia, aceitunas negras, aceitunas verdes, arandanos y fruta de temporada</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$20.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container row" id="tacos">
            <h3>Tacos</h3>
            <div class="card col-12">
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Arrachera</h5>
                            <p class="card-text"></p>
                            <p class="card-text">-</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$20.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card col-12">
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Pollo</h5>
                            <p class="card-text"></p>
                            <p class="card-text">-</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$20.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card col-12">
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Choirizo</h5>
                            <p class="card-text"></p>
                            <p class="card-text">-</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$20.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card col-12">
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Bistec</h5>
                            <p class="card-text"></p>
                            <p class="card-text">-</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$20.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>


        </div>
        <div class="container row" id="pizzas">
            <h3>Pizzas</h3>
            <div class="card col-12">
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <img src="https://cdn.sortiraparis.com/images/80/100789/834071-too-restaurant-too-hotel-paris-photos-menu-entrees.jpg" class="img-thumbnail rounded " alt="...">
                        </div>
                        <div class="col-8">
                            <h5 class="card-title">Margarita</h5>
                            <p class="card-text"></p>
                            <p class="card-text">Albaca, tomate, cherry y queso mozarella</p>
                        </div>
                        <div class="col-2">
                            <p class="card-text fw-bold">$209.00</p>
                            <p class="fs-6">Available</p>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
