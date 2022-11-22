import { Component } from '@angular/core';
import { Order } from './Models/Order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'product';
  orders:Order[] = [];
  newOrder: Order;
  ProdID:string = "";
  OrderDate:string = "";
  ShipDate:string = "";
  Quantity:number = 0;
  CustID:string = "";
  ShipMode:string = "";

  constructor(public _orderService:OrdersService){
    this.load()
  }

  load(){
    this._orderService.GetOrders().subscribe(unpackedOrders=> this.orders = unpackedOrders,null,()=>{
      console.log(this.orders)
    });
  }

  addOrder(){
    this.newOrder = {
      CustID: this.CustID,
      ProdID:this.ProdID,
      OrderDate: new Date().toString(),
      ShipDate:this.ShipDate,
      Quantity: this.Quantity,
      ShipMode:this.ShipMode,
    }
    this._orderService.newOrder(this.newOrder).subscribe(null,null,()=>{
      alert("Order has been placed");
      this.load();
    })
  }
}


