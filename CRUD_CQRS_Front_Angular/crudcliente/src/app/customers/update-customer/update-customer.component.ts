import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { ActivatedRoute, Router }  from '@angular/router';
import { UpdateCustomerRequest } from '../Models/updatecustomer.model';

@Component({
  selector: 'app-update-customer',
  templateUrl: './update-customer.component.html',
  styleUrls: ['./update-customer.component.css']
})
export class UpdateCustomerComponent implements OnInit {

  id: string;

  request: UpdateCustomerRequest;

  errors : any;

  constructor(private customerService: CustomerService, private routeActivated: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = this.routeActivated.snapshot.paramMap.get('id');
    this.customerService.getCustomersById(this.id).subscribe( 
      data => {      
        this.request = {
        id: data.id,
        name: data.name,
        age: data.age,
        cpfcnpj: data.cpfcnpj,
        ie: data.ie,
        ieIsento: data.ieIsento,
        telephone: data.telephone,
        email: data.email,
        cep: data.cep,
        address: data.address,
        number: data.number,
        district: data.district,
        city: data.city,
        state: data.state
  
      }},

      error => {this.errors = error.error});


  }

  Update(form: any) {
    console.log(this.request);
    this.customerService.updateCustomer(this.id, this.request).subscribe(
      data => {
        this.router.navigate(['/customers']);
        alert("Cliente atualizado com sucesso");
      },
      error => {this.errors = error.error}
    );
  }

}
