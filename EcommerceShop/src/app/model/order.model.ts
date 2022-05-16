import { OrderDetail } from "./orderDetail.model"
import { User } from "./user.model"


export interface Order{  
    userId: number,
    orderDate: string,
    totalPrice: number,
    transacStatus: number,
    paymentId: number,
    orderDetails:OrderDetail[],
    fullName? : string;
    phone?:string;
    address?:string;
    orderCode?:string;
    email?:string;
    totalCost?:number
}

export interface OrderVms{
    orderDate: string,
    transacStatus: number,
    orderCode?:string;
    totalCost?:number
}