import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetail } from './order/orderDetails.component';
var OrderModule = /** @class */ (function () {
    function OrderModule() {
    }
    OrderModule = __decorate([
        NgModule({
            declarations: [OrderDetail],
            imports: [
                CommonModule
            ],
            exports: [OrderDetail],
            bootstrap: [OrderDetail]
        })
    ], OrderModule);
    return OrderModule;
}());
export { OrderModule };
//# sourceMappingURL=order.module.js.map