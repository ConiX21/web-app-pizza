<%@ Page Title="" Language="C#" MasterPageFile="~/PizzaTemplate.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="web_app_pizza.Cart" %>

<%@ Import Namespace="web_app_pizza.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    Panier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <asp:Repeater runat="server" ID="PizzaCartRepeater" OnItemCommand="PizzaCartRepeater_ItemCommand" >
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
                                <asp:Button ID="ButtonPlus" runat="server" Text="+" CssClass="btn btn-success" />
                                <asp:Button ID="ButtonMinus" runat="server" Text="--" CssClass="btn btn-success" />
                            </div>
                            
                            <asp:Button ID="ButtonRemove" runat="server" Text="Remove" CssClass="btn btn-danger" />
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
</asp:Content>

