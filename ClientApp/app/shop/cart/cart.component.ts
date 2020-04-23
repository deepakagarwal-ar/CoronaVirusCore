import { Component } from '@angular/core';
import { DataService } from '../../shared/dataService';
import { Router } from '@angular/router';

@Component({
    selector: "the-cart",
    templateUrl: "cart.component.html",
    styleUrls: []
})
export class Cart {
    constructor(public data: DataService, private router: Router) {

    }

    onCheckOut() {
        if (this.data.loginRequired) {
            // Navigate to login
            this.router.navigate(["login"]);
        }
        else {
            this.router.navigate(["checkout"]);
        }
    }

}