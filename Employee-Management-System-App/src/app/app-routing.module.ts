import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeAddEditComponent } from './components/employee-add-edit/employee-add-edit.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // Default route
  { path: 'employees', component: EmployeeListComponent, canActivate: [AuthGuard] },
  { path: 'add-employee', component: EmployeeAddEditComponent, canActivate: [AuthGuard] },
  { path: 'edit-employee/:id', component: EmployeeAddEditComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent } // Login route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
