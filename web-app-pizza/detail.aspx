<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="web_app_pizza.Detail" %>

<div class="panel panel-default">
  <div class="panel-body">
      <div class="row">
          <div class="col-md-4">
              <img src="<%= Pizza.Image %>" alt="Alternate Text" class="img-responsive" />
          </div>
          <div class="col-md-8">
              <div class="form-group">
                  <label class="col-sm-2 control-label" for="form-group-input">Nom</label>
                  <div class="col-sm-10">
                      <input disabled type="text" class="form-control" value="<%= Pizza.Name %>">
                  </div>
              </div>
              <div class="form-group">
                  <label class="col-sm-2 control-label" for="form-group-input">Description</label>
                  <div class="col-sm-10">
                      <textarea disabled class="form-control"><%= Pizza.Description %></textarea>
                  </div>
              </div>
              <div class="form-group">
                  <label class="col-sm-2 control-label" for="form-group-input">Nom</label>
                  <div class="col-sm-10">
                      <input disabled type="text" class="form-control" value="<%= Pizza.Price %>">
                  </div>
              </div>
          </div>
      </div>
  </div>
</div>