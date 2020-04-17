import { Component, Input } from '@angular/core';
import { Post } from '../entities/Post';

@Component({
  selector: 'post-component',
  templateUrl: './post.component.html'
})
export class PostComponent {
  @Input() post: Post;
}
