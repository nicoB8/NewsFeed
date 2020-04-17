import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateUserModalComponent } from './user/Modals/create-user-modal.component';
import { UsersService } from './services/users.service';
import { FeedIndexComponent } from './feed/feed-index.component';
import { UserFeedComponent } from './feed/user-feed.component';
import { PostsService } from './services/posts.service';
import { PostIndexComponent } from './post/post-index.component';
import { PostComponent } from './post/post.component';
import { UsersIndexComponent } from './user/users-index.component';
import { UsersListComponent } from './user/users-list.component';
import { FilterPipe } from './pipes/filter.pipe';
import { FeedsService } from './services/feeds.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FeedIndexComponent,
    UsersIndexComponent,
    CreateUserModalComponent,
    UserFeedComponent,
    PostIndexComponent,
    PostComponent,
    UsersListComponent,
    FilterPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'feeds', component: FeedIndexComponent },
      { path: 'users', component: UsersIndexComponent },
    ])
  ],
  providers: [UsersService, PostsService, FeedsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
