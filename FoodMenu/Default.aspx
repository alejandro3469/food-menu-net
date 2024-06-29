<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FoodMenu._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
