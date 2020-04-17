import { Component } from '@angular/core';
import { User } from '../entities/User';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'feed-index-component',
  templateUrl: './feed-index.component.html'
})
export class FeedIndexComponent {
  public users: User[];
  public selectedLeftUser: User = null;
  public selectedRightUser: User = null;

  constructor(usersService: UsersService) {
    usersService.get().subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}
