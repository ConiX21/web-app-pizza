/// <reference path="../typings/index.d.ts"/>


class CartController {

    constructor() {
        this.registerEvents();
    }

    registerEvents() {

        $("button.detail").click((evt) => {

            let id = $(evt.currentTarget).attr("data-id");

            $.ajax({
                url: `detail.aspx?id=${id}`,
                method: 'get'
            }).done(this.onClickDetail);
        });
        $("#modalDetail").on('show.bs.modal', this.onBeforeModalShow);
    }

    onClickDetail(data) {
        $("#modalDetail").data("data", data);
        $("#modalDetail").modal('show');
    }

    onBeforeModalShow(evt) {
        
        let data = $(evt.currentTarget).data("data");
        $(".result").html(data);
    }

    detail(evt) {

        let id = $(evt).attr("data-id");

        $.ajax({
            url: `detail.aspx/id=${id}`,
            method: 'get'
        }).done(this.onClickDetail);

    }

}

var cartCtrl = new CartController(); 
