import { __decorate } from "tslib";
import { Component } from "@angular/core";
var Checkout = /** @class */ (function () {
    function Checkout(data, route) {
        this.data = data;
        this.route = route;
    }
    Checkout.prototype.onPurchase = function () {
        var _this = this;
        this.data.completeOrder().subscribe(function (success) {
            if (success) {
                _this.route.navigate(["orders"]);
            }
        }, function (err) { return _this.errorMessage = " Failed to save the order ! "; });
    };
    Checkout = __decorate([
        Component({
            selector: "checkout",
            templateUrl: "checkout.component.html",
            styleUrls: ['checkout.component.css']
        })
    ], Checkout);
    return Checkout;
}());
export { Checkout };
//# sourceMappingURL=checkout.component.js.map