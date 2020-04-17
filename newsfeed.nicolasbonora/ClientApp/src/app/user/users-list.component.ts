import { Component, Input} from '@angular/core';
import { User } from '../entities/User';
import { UsersService } from '../services/users.service';
import { FeedsService } from '../services/feeds.service';

@Component({
  selector: 'users-list-component',
  templateUrl: './users-list.component.html'
})
export class UsersListComponent {
  @Input() showDetailedList: boolean = false;
  @Input() showActions: boolean = false;
  @Input() selectedUser: User = null;
  public users: User[];

  constructor(usersService: UsersService, private feedsService: FeedsService) {
    usersService.get().subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  public onClickingFollow(user: User) {
    this.feedsService.subscribeToFeed(user.id, this.selectedUser.id).subscribe(result => {
      this.selectedUser.followingFeeds.push(user.id);
    })
  }

  public getUserList(): User[] {
    var usersList = !!this.selectedUser ? this.users.filter(u => u.id != this.selectedUser.id) : this.users;
    return usersList;
  }

  public isFollowing(user): boolean {
    return !!this.selectedUser.followingFeeds.find(u => u == user.id);
  }
}
