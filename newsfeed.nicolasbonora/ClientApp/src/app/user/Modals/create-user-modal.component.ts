import { Component, ElementRef, ViewChild, Input } from '@angular/core';
import { User } from '../../entities/User';
import { UsersService } from '../../services/users.service';
declare var $: any;

@Component({
  selector: 'create-user-modal-component',
  templateUrl: './create-user-modal.component.html'
})
export class CreateUserModalComponent {
  @Input() users: User[];
  public user: User;
  public active: boolean = false;
  public saving: boolean = false;
  public creationIntents: number = 0;
  public requestSuccess: boolean = false;
  public saveButtonText: string = "Create";

  @ViewChild('nameInput') nameInput: ElementRef;

  constructor(private usersService: UsersService) {

  }

  public show(): void {
    this.active = true;
    $('#createUserModal').modal('show');
    this.user = new User();
  }

  public onShown(): void {
    this.nameInput.nativeElement.focus();
  }

  close(): void {
    this.active = false;
    $('#createUserModal').modal('hide');
    this.saveButtonText = "Create";
    this.requestSuccess = false;
    this.creationIntents = 0;
  }

  public save(): void {
    this.saving = true;
    this.saveButtonText = "Creating...";
    this.usersService.post(this.user).subscribe(result => {
      this.users.unshift(result);
      this.requestSuccess = true;
      this.user = new User();
      this.resetForm();
    }, error => {
        console.error(error);
        this.requestSuccess = false;
        this.resetForm();
    });
  }

  resetForm() {
    this.creationIntents++;
    this.saving = false;
    this.saveButtonText = "Create";
    $('#createUserModal').modal('handleUpdate')
  }

}
