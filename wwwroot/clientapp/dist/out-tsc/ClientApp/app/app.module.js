import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { DataService } from './shared/dataService';
import { Cart } from './shop/cart/cart.component';
import { Shop } from './shop/shop.component';
import { Checkout } from './shop/checkout/checkout.component';
import { RouterModule } from '@angular/router';
import { Login } from './shop/login/login.component';
//import { OrderModule } from './orderModule/order.module';
import { OrderDetail } from './orderModule/order/orderDetails.component';
var routes = [
    { path: "", component: Shop },
    { path: "checkout", component: Checkout },
    { path: "login", component: Login },
    { path: "orders", component: OrderDetail }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                ProductList,
                Cart,
                Shop,
                Checkout,
                Login
            ],
            imports: [
                BrowserModule,
                HttpClientModule,
                FormsModule,
                //OrderModule,
                RouterModule.forRoot(routes, {
                    useHash: true,
                    enableTracing: false // for debugging the routing 
                })
            ],
            providers: [
                DataService
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map