import { Component, OnInit } from '@angular/core';
import { Customer } from './Models/customer.model';
import { CustomerService } from './customer.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  responseCustomers: Customer;

  constructor(private  customerService: CustomerService) { }

  
  ngOnInit(): void {
    this.GetCustomers();
    
  }
  
  GetCustomers() {
    this.customerService.getCustomers()
    .subscribe(res => this.responseCustomers = res);
  }

  RemoveCustomer(id: string) {    
    this.customerService.RemoveCustomersById(id).subscribe(
      data => {        
        alert("Cliente Removido com sucesso");
        this.GetCustomers();
      },      
      error => {alert(error.error);}
    );
  }
}
