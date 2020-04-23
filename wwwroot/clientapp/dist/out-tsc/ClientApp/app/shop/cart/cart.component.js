import { __decorate } from "tslib";
import { Component } from '@angular/core';
var Cart = /** @class */ (function () {
    function Cart(data, router) {
        this.data = data;
        this.router = router;
    }
    Cart.prototype.onCheckOut = function () {
        if (this.data.loginRequired) {
            // Navigate to login
            this.router.navigate(["login"]);
        }
        else {
            this.router.navigate(["checkout"]);
        }
    };
    Cart = __decorate([
        Component({
            selector: "the-cart",
            templateUrl: "cart.component.html",
            styleUrls: []
        })
    ], Cart);
    return Cart;
}());
export { Cart };
//# sourceMappingURL=cart.component.js.map