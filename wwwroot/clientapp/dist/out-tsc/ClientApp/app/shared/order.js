import * as _ from "lodash";
var Order = /** @class */ (function () {
    function Order() {
        this.orderDate = new Date();
        this.orderItems = new Array();
    }
    Object.defineProperty(Order.prototype, "totalAmount", {
        get: function () {
            return _.sum(_.map(this.orderItems, function (i) { return i.unitPrice * i.quantity; }));
        },
        enumerable: true,
        configurable: true
    });
    ;
    return Order;
}());
export { Order };
var OrderItem = /** @class */ (function () {
    function OrderItem() {
    }
    return OrderItem;
}());
export { OrderItem };
//# sourceMappingURL=order.js.map