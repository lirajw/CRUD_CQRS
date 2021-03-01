import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from '../customer.service';
import { CreateCustomerRequest, CreateCustomerResponse } from '../Models/createcustomer.model';

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrls: ['./create-customer.component.css']
})
export class CreateCustomerComponent implements OnInit {

  request : CreateCustomerRequest = {
    name: '',    
    cpfcnpj: '',
    ie: '',
    ieIsento: false,
    telephone: '',
    email: '',
    cep: '',
    address: '',
    number: 0,
    district: '',
    city: '',
    state: ''
  };

  response : CreateCustomerResponse;

  errors : any;

  constructor(private customerServer: CustomerService, private router: Router) { }

  ngOnInit(): void {
  }

  Save(form: any) {
    console.log(this.request);
    this.customerServer.createCustomer(this.request).subscribe(
      data => {this.router.navigate(['/customers'])},
      error => {this.errors = error.error}
    );
  }
}
