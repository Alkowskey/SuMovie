import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SuMovieMainComponent} from './su-movie-main/su-movie-main.component';


const routes: Routes = [
  {path: "", component: SuMovieMainComponent},
  {path: "watchedList", component: SuMovieMainComponent},
  {path: "notWatchedList", component: SuMovieMainComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
