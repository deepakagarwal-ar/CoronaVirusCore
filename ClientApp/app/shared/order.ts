import * as _ from "lodash";

export class Order {
    orderId: number;
    orderNumber: string;
    orderDate: Date = new Date();
    orderItems: Array<OrderItem> = new Array<OrderItem>();

    get totalAmount(): number {
        return _.sum(_.map(this.orderItems, i => i.unitPrice * i.quantity));
    };
}


export class OrderItem {
    id: number;
    quantity: number;
    unitPrice: number;
    productId: number;
    productCategory: string;
    productPrice: number;
    productTitle: string;
    productArtId: string;
}