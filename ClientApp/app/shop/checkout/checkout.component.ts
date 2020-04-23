import { Component } from "@angular/core";
import { DataService } from '../../shared/dataService';
import { Router } from '@angular/router';

@Component({
    selector: "checkout",
    templateUrl: "checkout.component.html",
    styleUrls: ['checkout.component.css']
})
export class Checkout {

    public errorMessage: string;

    constructor(public data: DataService, private route: Router) {
    }

    onPurchase() {
        this.data.completeOrder().subscribe(success => {
            if (success) {
                this.route.navigate(["orders"]);
            }
        }, err => this.errorMessage = " Failed to save the order ! ");
    }
}