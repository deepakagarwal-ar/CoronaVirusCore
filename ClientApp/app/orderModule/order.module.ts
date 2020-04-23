import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetail } from './order/orderDetails.component';



@NgModule({
    declarations: [OrderDetail],
    imports: [
        CommonModule
    ],
    exports: [OrderDetail]
})
export class OrderModule {
}
