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
    email?:string;
    totalCost?:number
}

export interface OrderVms{
    oderId: number,
    userId: number,
    orderDate: string,
    totalPrice: number,
    status: number,
    payment: boolean,
    fullName: string,
    address: string
}