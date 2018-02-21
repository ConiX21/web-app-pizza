<%@ Page Title="" Language="C#" MasterPageFile="~/PizzaTemplate.Master" AutoEventWireup="true" CodeBehind="AddPizza.aspx.cs" Inherits="web_app_pizza.AddPizza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
     
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="web_app_pizza.Models.Pizza" InsertMethod="Add" SelectMethod="Read" TypeName="web_app_pizza.Models.PizzaRepository"></asp:ObjectDataSource>
    
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert" CssClass="table" >
        <InsertItemTemplate>
            <div class="alert alert-warning alert-dismissible" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" />
                </label>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Nom</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" runat="server" ID="Name" Text='<%# Bind("Name") %>' />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Description</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" runat="server" ID="Description" Text='<%# Bind("Description") %>' />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Prix</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control" runat="server" ID="Price" Text='<%# Bind("Price") %>' />
                </div>
            </div>

            <asp:RegularExpressionValidator ControlToValidate="Name" ValidationExpression="^[A-Z]{1,35}$" ID="RegularExpressionValidatorName" runat="server" ErrorMessage="Le format n'est pas valide"></asp:RegularExpressionValidator>
            <br />
            <asp:RegularExpressionValidator ControlToValidate="Description" ValidationExpression="^[A-Z]{1}[\-\ \.\,éèàa-zA-Z]+" ID="RegularExpressionValidatorDescription" runat="server" ErrorMessage="Le format n'est pas valide"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ControlToValidate="Price" ID="RequiredFieldValidatorprice" runat="server" ErrorMessage="Veuillez saisir le prix"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ControlToValidate="Description" ID="RequiredFieldValidatorDescription" runat="server" ErrorMessage="Veuillez saisir la description"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator Text="*" ControlToValidate="Name" ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Veuillez saisir le nom de la pizza"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="InsertButton" CssClass="btn btn-primary" runat="server" CausesValidation="True" CommandName="Insert" Text="Ajouter" />

        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>

