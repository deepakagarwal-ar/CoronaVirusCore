import { __decorate } from "tslib";
import { Component } from "@angular/core";
var ProductList = /** @class */ (function () {
    function ProductList(data) {
        this.data = data;
        this.products = [];
    }
    ProductList.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadProducts().subscribe(function (success) {
            if (success) {
                _this.products = _this.data.products;
            }
        });
    };
    ProductList.prototype.addProduct = function (product) {
        this.data.createOrder(product);
    };
    ProductList = __decorate([
        Component({
            selector: "product-list",
            templateUrl: "productList.component.html",
            styleUrls: ["productList.component.css"]
        })
    ], ProductList);
    return ProductList;
}());
export { ProductList };
//# sourceMappingURL=productList.component.js.map