import { Component } from '@angular/core';
import { Post } from '../entities/Post';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public posts: Post[] = [];
  public searchText: string = '';

  constructor(private postsService: PostsService) {
    this.refreshFeed();
  }

  refreshFeed(): void {
    this.postsService.get().subscribe(result => {
      this.posts = result;
    }, error => console.error(error));
  }

}
