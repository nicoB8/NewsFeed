import { Component, ViewChild } from '@angular/core';
import { CreateUserModalComponent } from './Modals/create-user-modal.component';
import { UsersListComponent } from './users-list.component';

@Component({
  selector: 'users-index-component',
  templateUrl: './users-index.component.html'
})
export class UsersIndexComponent {
  @ViewChild(CreateUserModalComponent) createUserModal: CreateUserModalComponent;
  @ViewChild(UsersListComponent) usersListComponent: UsersListComponent;
 
}
