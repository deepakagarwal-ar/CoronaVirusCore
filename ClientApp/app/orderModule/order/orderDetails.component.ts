import { Component, OnInit } from '@angular/core';
import { DataService } from '../../shared/dataService';
import { Order } from '../../shared/order';

@Component({
    selector: "the-orders",
    templateUrl:"orderDetails.component.html"
})
export class OrderDetail implements OnInit {

    constructor(private data: DataService) {

    }

    public orders: Order[] = [];

    ngOnInit(): void {
        this.data.getOrders().subscribe(success => {
            if (success) {
                this.orders = this.data.orders;
            }
        });
    }
}