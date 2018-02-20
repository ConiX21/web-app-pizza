<%@ Page EnableSessionState="True" Title="" Language="C#" MasterPageFile="~/PizzaTemplate.Master" Trace="true" AutoEventWireup="true" CodeBehind="Pizzas.aspx.cs" Inherits="web_app_pizza.Pizzas" %>

<%@ Register TagPrefix="nico" Src="~/WebUserControlPizza.ascx" TagName="WebUserCtrlpizza" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="web_app_pizza.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    Nos pizzas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="row">
       
        </div>
        <asp:Repeater ID="RepeaterPizzas" runat="server" OnItemCommand="RepeaterPizzas_ItemCommand">
            <ItemTemplate>
                <nico:WebUserCtrlpizza runat="server" ID="pizzaCtrl"
                    Pizza='<%# Container.DataItem %>'></nico:WebUserCtrlpizza>
            
            </ItemTemplate>
        </asp:Repeater>

</asp:Content>
