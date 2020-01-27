import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SuMovieMainComponent} from './su-movie-main/su-movie-main.component';
import {LoginComponent} from './login/login.component';
import {SuMovieWatchedComponent} from './su-movie-watched/su-movie-watched.component';
import {RegisterComponent} from './register/register.component';
import {PredictionsComponent} from './predictions/predictions.component';
import {SuMovieNotwatchedComponent} from './su-movie-notwatched/su-movie-notwatched.component';


const routes: Routes = [
  {path: "", component: SuMovieMainComponent},
  {path: "watchedList", component: SuMovieWatchedComponent},
  {path: "notWatchedList", component: SuMovieNotwatchedComponent},
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "predictions", component: PredictionsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
