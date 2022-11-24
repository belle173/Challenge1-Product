import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Order } from './Models/Order';
import { Observable } from 'rxjs';
import { Customer } from './Models/Customer';
import { Product } from './Models/Product';



@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  readonly baseUrl:string = "https://diplomachallengeapiisabelle.azurewebsites.net"
  //readonly baseUrl:string = "https://localhost:7085"

  constructor(private _http:HttpClient) { }

  GetOrders(): Observable<Order[]>{
    return this._http.get<Order[]>(this.baseUrl + "/order")
  }
  newOrder(order:Order): Observable<string> {
    const headers = { 'content-type': 'application/json'};
    const body = JSON.stringify(order);
    return this._http.put<string>(this.baseUrl + '/order', body, {'headers': headers})
  }
  GetCustomers(): Observable<Customer[]>{
    return this._http.get<Customer[]>(this.baseUrl + "/customer")
  }
  GetProducts(): Observable<Product[]>{
    return this._http.get<Product[]>(this.baseUrl + "/product")
  }
  deleteOrder(order:Order):Observable<any>{
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(order);
    return this._http.delete<any>(this.baseUrl + '/order', { body: body, 'headers':headers })
  }
}
 

