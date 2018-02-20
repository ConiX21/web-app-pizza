<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlPizza.ascx.cs" Inherits="web_app_pizza.WebUserControlPizza" %>

<div class="col-sm-6 col-md-4">
    <div class="thumbnail">
        <img src="<%# Eval("Image")%>">
        <div class="caption">
            <h3><%# Eval("Name")%></h3>
            <p><%# Eval("Description")%></p>
            <label><%# Eval("Price")%></label>
            <asp:Button runat="server" CommandArgument='<%# Eval("IDPizza") %>' CssClass="btn btn-primary"/>
        </div>
    </div>
</div>
