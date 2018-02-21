/// <reference path="../typings/index.d.ts"/>
var CartController = (function () {
    function CartController() {
        this.registerEvents();
    }
    CartController.prototype.registerEvents = function () {
        var _this = this;
        $("button.detail").click(function (evt) {
            var id = $(evt).attr("data-id");
            $.ajax({
                url: "detail.aspx/id=" + id,
                method: 'get'
            }).done(_this.onClickDetail);
        });
    };
    CartController.prototype.onClickDetail = function (data) {
        console.log(data);
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