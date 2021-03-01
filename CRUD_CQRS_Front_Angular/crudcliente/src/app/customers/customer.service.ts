import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders, HttpRequest} from '@angular/common/http';
import { Customer } from './Models/customer.model';
import { CreateCustomerRequest, CreateCustomerResponse } from './Models/createcustomer.model';
import { UpdateCustomerRequest, UpdateCustomerResponse } from './Models/updatecustomer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private url = "https://localhost:5001/customer";

  public Errors: string[];

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer> {
    return this.http.get<Customer>(this.url);
  }

  getCustomersById(id: string): Observable<Customer> {
    const _url = `${this.url}/${id}`;
    console.log(_url)
    return this.http.get<Customer>(_url);
  }


  createCustomer(request: CreateCustomerRequest) : Observable<CreateCustomerResponse> {

    return this.http.post<CreateCustomerResponse>(this.url, request);
  }

  updateCustomer(id: string, request: UpdateCustomerRequest) : Observable<UpdateCustomerResponse> {
    const _url = `${this.url}/${id}`;

    return this.http.put<UpdateCustomerResponse>(_url, request);
  }

  RemoveCustomersById(id: string): Observable<string> {
    const _url = `${this.url}/${id}`;
    console.log(_url)
    return this.http.delete<string>(_url);
  }
}
