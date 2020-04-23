import { __decorate } from "tslib";
import { Component } from '@angular/core';
var Login = /** @class */ (function () {
    function Login(data, router) {
        this.data = data;
        this.router = router;
        this.cred = {
            UserName: "",
            Password: ""
        };
        this.errorMessage = "";
    }
    Login.prototype.onLogin = function () {
        var _this = this;
        this.data.login(this.cred).subscribe(function (success) {
            if (success) {
                if (_this.data.order.orderItems.length > 0) {
                    _this.router.navigate([""]);
                }
                else {
                    _this.router.navigate(["checkout"]);
                }
            }
        }, function () { return _this.errorMessage = "Failed to login"; });
    };
    Login = __decorate([
        Component({
            selector: "login",
            templateUrl: "login.component.html"
        })
    ], Login);
    return Login;
}());
export { Login };
//# sourceMappingURL=login.component.js.map