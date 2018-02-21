/// <reference path="../typings/index.d.ts"/>
var CartController = (function () {
    function CartController() {
        this.registerEvents();
    }
    CartController.prototype.registerEvents = function () {
        var _this = this;
        $("button.detail").click(function (evt) {
            var id = $(evt.currentTarget).attr("data-id");
            $.ajax({
                url: "detail.aspx?id=" + id,
                method: 'get'
            }).done(_this.onClickDetail);
        });
        $("#modalDetail").on('show.bs.modal', this.onBeforeModalShow);
    };
    CartController.prototype.onClickDetail = function (data) {
        $("#modalDetail").data("data", data);
        $("#modalDetail").modal('show');
    };
    CartController.prototype.onBeforeModalShow = function (evt) {
        var data = $(evt.currentTarget).data("data");
        $(".result").html(data);
    };
    CartController.prototype.detail = function (evt) {
        var id = $(evt).attr("data-id");
        $.ajax({
            url: "detail.aspx/id=" + id,
            method: 'get'
        }).done(this.onClickDetail);
    };
    return CartController;
}());
var cartCtrl = new CartController();
//# sourceMappingURL=CartController.js.map