<%@ Page Title="" Language="C#" MasterPageFile="~/PizzaTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web_app_pizza.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Login ID="Login1" runat="server"></asp:Login>
    <asp:Label ID="LegendStatus" runat="server"></asp:Label>
</asp:Content>
