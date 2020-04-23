import { __decorate } from "tslib";
import { Component } from '@angular/core';
var OrderDetail = /** @class */ (function () {
    function OrderDetail(data) {
        this.data = data;
        this.orders = [];
    }
    OrderDetail.prototype.ngOnInit = function () {
        var _this = this;
        this.data.getOrders().subscribe(function (success) {
            if (success) {
                _this.orders = _this.data.orders;
            }
        });
    };
    OrderDetail = __decorate([
        Component({
            selector: "the-orders",
            templateUrl: "orderDetails.component.html"
        })
    ], OrderDetail);
    return OrderDetail;
}());
export { OrderDetail };
//# sourceMappingURL=orderDetails.component.js.map