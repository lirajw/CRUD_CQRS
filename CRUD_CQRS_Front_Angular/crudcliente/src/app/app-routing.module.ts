import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCustomerComponent } from './customers/create-customer/create-customer.component';
import { CustomersComponent } from './customers/customers.component';
import { UpdateCustomerComponent } from './customers/update-customer/update-customer.component';

const routes: Routes = [
  {path: 'customers', component: CustomersComponent},
  {path: 'customers/create', component: CreateCustomerComponent},
  {path: 'customers/update/:id', component: UpdateCustomerComponent},
  { path: '', redirectTo: '/customers', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
