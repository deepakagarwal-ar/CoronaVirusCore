import { __decorate } from "tslib";
import { HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order, OrderItem } from './order';
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.order = new Order();
        this.products = [];
        this.orders = [];
        this.token = "";
        this.tokenExpiration = null;
    }
    DataService.prototype.loadProducts = function () {
        var _this = this;
        return this.http.get("/api/products").pipe(map(function (data) {
            _this.products = data;
            return true;
        }));
    };
    Object.defineProperty(DataService.prototype, "loginRequired", {
        get: function () {
            return this.token.length === 0 || this.tokenExpiration === null || this.tokenExpiration > new Date();
        },
        enumerable: true,
        configurable: true
    });
    DataService.prototype.login = function (creds) {
        var _this = this;
        return this.http.post("/account/CreateToken", creds).pipe(map(function (data) {
            _this.token = data.token;
            _this.tokenExpiration = data.expires;
            return true;
        }));
    };
    DataService.prototype.createOrder = function (newproduct) {
        var orderItem = this.order.orderItems.find(function (i) { return i.productId === newproduct.id; });
        if (orderItem) {
            orderItem.quantity++;
        }
        else {
            orderItem = new OrderItem();
            orderItem.productId = newproduct.id;
            orderItem.productArtId = newproduct.artId;
            orderItem.productCategory = newproduct.category;
            orderItem.productPrice = newproduct.price;
            orderItem.productTitle = newproduct.title;
            orderItem.unitPrice = newproduct.price;
            this.order.orderItems.push(orderItem);
            orderItem.quantity = 1;
        }
    };
    DataService.prototype.completeOrder = function () {
        var _this = this;
        if (!this.order.orderNumber) {
            this.order.orderNumber =
                new Date().getDate().toString() +
                    this.order.orderDate.getFullYear().toString();
        }
        return this.http.post("/api/Orders", this.order, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(map(function () {
            _this.order = new Order();
            return true;
        }));
    };
    DataService.prototype.getOrders = function () {
        var _this = this;
        return this.http.get("/api/orders", {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(map(function (data) {
            _this.orders = data;
            return true;
        }));
    };
    DataService = __decorate([
        Injectable()
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=dataService.js.map