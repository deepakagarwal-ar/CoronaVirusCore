import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'
import { Product } from './product'
import { map } from 'rxjs/operators'
import { Order, OrderItem } from './order';

@Injectable()
export class DataService {
    constructor(private http: HttpClient) {

    }

    public order: Order = new Order();
    public products: Product[] = [];
    public orders: Order[] = [];

    private token = "";
    private tokenExpiration: Date = null;


    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products").pipe(
            map((data: Product[]) => {
                this.products = data;
                return true;
            })
        );
    }

    public get loginRequired(): boolean {
        return this.token.length === 0 || this.tokenExpiration === null || this.tokenExpiration > new Date();
    }

    login(creds): Observable<boolean> {

        return this.http.post("/account/CreateToken", creds).pipe(
            map((data: any) => {
                this.token = data.token;
                this.tokenExpiration = data.expires;
                return true;
            }));

    }

    createOrder(newproduct: Product) {

        let orderItem: OrderItem = this.order.orderItems.find(i => i.productId === newproduct.id);

        if (orderItem) {
            orderItem.quantity++;
        } else {

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
    }

    completeOrder() {
        if (!this.order.orderNumber) {
            this.order.orderNumber =
                new Date().getDate().toString() +
                this.order.orderDate.getFullYear().toString();
        }
        return this.http.post("/api/Orders", this.order, {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(
            map(() => {
                this.order = new Order();
                return true;
            }));
    }

    getOrders(): Observable<boolean> {
        return this.http.get("/api/orders", {
            headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)
        }).pipe(
            map((data: any) => {
                this.orders = data;
                return true;
            })
        );
    }
}