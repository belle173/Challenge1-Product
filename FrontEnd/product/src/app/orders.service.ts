import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Order } from './Models/Order';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  readonly baseUrl:string = "https://localhost:7085"

  constructor(private _http:HttpClient) { }

  GetOrders(): Observable<Order[]>{
    return this._http.get<Order[]>(this.baseUrl + "/order")
  }
  newOrder(order:Order): Observable<string> {
    const headers = { 'content-type': 'application/json'};
    const body = JSON.stringify(order);
    return this._http.put<string>(this.baseUrl + '/order', body, {'headers': headers})
  }
}
