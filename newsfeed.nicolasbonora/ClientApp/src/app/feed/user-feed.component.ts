import { Component, Input } from '@angular/core';
import { User } from '../entities/User';
import { PostsService } from '../services/posts.service';
import { Post } from '../entities/Post';

@Component({
  selector: 'user-feed-component',
  templateUrl: './user-feed.component.html'
})
export class UserFeedComponent {
  @Input() users: User[];
  public selectedUser: User = null;
  public posts: Post[] = [];
  public instanceId: number;

  constructor(private postsService: PostsService) {
    this.instanceId = Math.floor(Math.random() * (+1000 - +0)) + +0;
  }

  refreshFeed(): void {
    if (this.selectedUser != null) {
      this.onSelectUser();
    }
  }
  
  onSelectUser(): void {
    console.log("Selected user: ", this.selectedUser);
    this.postsService.getByUserId(this.selectedUser.id).subscribe(result => {
      this.posts = result;
    }, error => console.error(error));
  }
}
