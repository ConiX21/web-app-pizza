<%@ Page Title="" Trace="true" Language="C#" MasterPageFile="~/PizzaTemplate.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="web_app_pizza.Cart" %>

<%@ Import Namespace="web_app_pizza.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    Panier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <asp:Repeater runat="server" ID="PizzaCartRepeater" OnItemCommand="PizzaCartRepeater_ItemCommand" OnItemDataBound="PizzaCartRepeater_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Name</th>
                                <th>Price</th>
                                <th>Quantity</th>
                                <th>Total</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Pizza.Image")%>' CssClass="img-thumbnail" />
                        </td>
                        <td><%# Eval("Pizza.Name") %></td>
                        <td><%# Eval("Pizza.Price") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td>
                            <asp:Label runat="server" Text='<%# String.Format("{0:C2}",((PizzaCart)Container.DataItem).TotalRow()) %>'></asp:Label>
                        </td>
                        <td>
                            <div class="btn-group" role="group" aria-label="...">
                                <asp:Button ID="ButtonPlus" runat="server" Text="+" CssClass="btn btn-success" CommandArgument='<%# Eval("Pizza.IDpizza") %>' />
                                <asp:Button ID="ButtonMinus" runat="server" Text="--" CssClass="btn btn-success" CommandArgument='<%# Eval("Pizza.IDpizza") %>' />
                            </div>
                            <div class="btn-group" role="group" aria-label="...">
                                <button type="button" data-id='<%# Eval("Pizza.IDpizza") %>' class="btn btn-primary detail">Details</button>
                                <asp:Button    ID="ButtonRemove" runat="server" Text="Remove" CssClass="btn btn-danger" CommandArgument='<%# Eval("Pizza.IDpizza") %>' />
                            </div>
                        </td>
                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>

            </asp:Repeater>

        </div>
        
    </div>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="col-md-2 text-left">
                <asp:Button Enabled="false" OnClick="checkout_Click" ID="checkout" runat="server" Text="Commander" CssClass="btn btn-success" />
            </div>
            <div class="col-md-8 col-md-offset-2 text-right">
                <asp:Label runat="server" ID="TotalPrice" CssClass="price"></asp:Label>
            </div>
        </div>
    </div>


    <div class="modal fade animated rollIn" id="modalDetail" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModal-label">Détail de la pizza</h4>
                </div>
                <div class="modal-body result">
                    
                </div>
            </div>
        </div>
    </div>
    <script src="scripts/CartController.js"></script>
</asp:Content>

