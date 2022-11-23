import { Component } from '@angular/core';
import { Customer } from './Models/Customer';
import { Order } from './Models/Order';
import { Product } from './Models/Product';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'product';
  orders:Order[] = [];
  customer:Customer[] = [];
  product:Product[] = [];
  selectedOrderToDelete:Order;
  selectedOrderToEdit:Order;
  editedOrder:Order;
  selectedProduct:Product;
  selectedCustomer:string;
  selectedShipMode:string;
  newOrder: Order;
  OrderDate:string = "";
  ShipDate:string = "";
  Quantity:number = 0;
  
  
  

  constructor(public _orderService:OrdersService){
    this.load()
  }

  load(){
    this._orderService.GetOrders().subscribe(unpackedOrders=> this.orders = unpackedOrders,null,()=>{
      console.log(this.orders)
      this._orderService.GetCustomers().subscribe(unpackedOrders=> this.customer = unpackedOrders,null,()=>{
        console.log(this.customer)
        this._orderService.GetProducts().subscribe(unpackedOrders=> this.product = unpackedOrders,null,()=>{
        console.log(this.product)
        this.selectedOrderToEdit = this.orders[0]
        this.changedEdit()
      });
      });
    });
  }

  addOrder(){
    console.log(this.selectedCustomer)
    this.newOrder = {
      custID: this.selectedCustomer,
      prodID:this.selectedProduct.prodID,
      orderDate: new Date().toString(),
      shipDate:this.ShipDate,
      quantity: this.Quantity,
      shipMode:this.selectedShipMode,
    }
    this._orderService.newOrder(this.newOrder).subscribe(null,null,()=>{
      alert("Order has been placed");
      this.load();
    })
  }

  deleteOrder(){
      this._orderService.deleteOrder(this.selectedOrderToDelete).subscribe(null,null,()=>{
        alert("Order has been Deleted");
        this.load ();
      })
    }

    // editOrder function same as delete order but different this._orderService.xxxxxx(xxxxxxx)
    editOrder(){
      this._orderService.deleteOrder(this.selectedOrderToEdit).subscribe(null,null,()=>{
        this._orderService.newOrder(this.editedOrder).subscribe(null,null,()=>{
          alert("Order has been edited");
          this.load();
        })
      })
    }

    // this will be used later don't touch
    changedEdit(){
      this.editedOrder = {...this.selectedOrderToEdit}
    }
  


}



