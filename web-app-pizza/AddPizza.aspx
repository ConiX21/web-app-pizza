<%@ Page Title="" Language="C#" MasterPageFile="~/PizzaTemplate.Master" AutoEventWireup="true" CodeBehind="AddPizza.aspx.cs" Inherits="web_app_pizza.AddPizza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <form class="form form-horizontal" method="post" runat="server">
        <div class="row">
            <div class="alert alert-warning alert-dismissible" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <label><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" /></label>
           
                </div>
        </div>
        <div class="row">
            <div class="form-group">
                <label class="col-sm-2 control-label">Nom</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" runat="server" ID="txtNme"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <label class="col-sm-2 control-label">Description</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" runat="server" id="txtDescription">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <label class="col-sm-2 control-label">Prix</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" runat="server" id="txtPrice">
                </div>
            </div>
        </div>
        <asp:RegularExpressionValidator  ControlToValidate="txtNme" ValidationExpression="^[A-Z]{1,35}$" ID="RegularExpressionValidatorName" runat="server" ErrorMessage="Le format n'est pas valide"></asp:RegularExpressionValidator>
        <br />
        <asp:RegularExpressionValidator  ControlToValidate="txtDescription" ValidationExpression="^[A-Z]{1}[\-\ \.\,éèàa-zA-Z]+" ID="RegularExpressionValidatorDescription" runat="server" ErrorMessage="Le format n'est pas valide"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator  ControlToValidate="txtPrice" ID="RequiredFieldValidatorprice" runat="server" ErrorMessage="Veuillez saisir le prix"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator  ControlToValidate="txtDescription" ID="RequiredFieldValidatorDescription" runat="server" ErrorMessage="Veuillez saisir la description"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator Text="*" ControlToValidate="txtNme" ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Veuillez saisir le nom de la pizza"></asp:RequiredFieldValidator>
        <br />
        <asp:Button runat="server" Text="Ajouter" CssClass="btn btn-primary" />
    </form>
</asp:Content>

