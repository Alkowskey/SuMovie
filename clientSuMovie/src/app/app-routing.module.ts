import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SuMovieMainComponent} from './su-movie-main/su-movie-main.component';
import {LoginComponent} from './login/login.component';
import {SuMovieWatchedComponent} from './su-movie-watched/su-movie-watched.component';
import {RegisterComponent} from './register/register.component';


const routes: Routes = [
  {path: "", component: SuMovieMainComponent},
  {path: "watchedList", component: SuMovieWatchedComponent},
  {path: "notWatchedList", component: SuMovieMainComponent},
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
