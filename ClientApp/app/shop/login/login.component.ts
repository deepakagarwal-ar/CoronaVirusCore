import { Component } from '@angular/core';
import { DataService } from '../../shared/dataService';
import { Router } from '@angular/router';

@Component({
    selector: "login",
    templateUrl: "login.component.html"
})
export class Login {

    constructor(private data: DataService, private router: Router) {

    }

    public cred = {
        UserName: "",
        Password: ""
    };

    errorMessage = "";

    onLogin() {

        this.data.login(this.cred).subscribe(success => {
            if (success) {
                if (this.data.order.orderItems.length > 0) {
                    this.router.navigate([""]);
                } else {
                    this.router.navigate(["checkout"]);
                }
            }
        }, () => this.errorMessage = "Failed to login"
        );

    }

}