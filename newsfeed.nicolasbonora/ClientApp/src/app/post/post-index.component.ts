import { Component, Input } from '@angular/core';
import { User } from '../entities/User';
import { PostsService } from '../services/posts.service';
import { Post } from '../entities/Post';

@Component({
  selector: 'post-index-component',
  templateUrl: './post-index.component.html'
})
export class PostIndexComponent {
  @Input() posts: Post[] = [];
  @Input() selectedUser: User;
  @Input() searchText: string = "";
  public post: Post;
  public sendPostButtonText: string = "Send post!";

  constructor(private postsService: PostsService) {
    this.post = new Post();
  }

  sendPost(): void {
    this.sendPostButtonText = "Sending post...";
    this.post.feedId = this.selectedUser.id;
    this.postsService.post(this.post).subscribe(result => {
      this.posts.unshift(result);
      this.post = new Post();
      this.sendPostButtonText = "Send post!";
    }, error => {
      console.error(error);
        this.sendPostButtonText = "Send post!";
    });
  }
}
