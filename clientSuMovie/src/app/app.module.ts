import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import { HeaderComponent } from './header/header.component';
import { MaterialModule } from './material.module';
import { SuMovieMainComponent } from './su-movie-main/su-movie-main.component';
import { LoginComponent } from './login/login.component';
import { SuMovieWatchedComponent } from './su-movie-watched/su-movie-watched.component';
import { RegisterComponent } from './register/register.component';
import { PredictionsComponent } from './predictions/predictions.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SuMovieMainComponent,
    LoginComponent,
    SuMovieWatchedComponent,
    RegisterComponent,
    PredictionsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule);