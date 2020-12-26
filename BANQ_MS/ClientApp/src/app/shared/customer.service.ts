import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './customer.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  list: Customer[];

  constructor(private http: HttpClient) { }

  getCustomerList() {
    this.http.get(environment.baseUrl + '/Customer')
      .toPromise()
      .then(result => this.list = result as Customer[]);
  }
}
