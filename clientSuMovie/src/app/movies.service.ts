import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {SimpleCrypto} from "simple-crypto-js";


@Injectable({
  providedIn: 'root'
})


export class MoviesService {

  constructor(private http: HttpClient) { 


  }
  

  getAllMovies(){
    return this.http.get("https://localhost:5001/ImdbScraper/getAll");
  }

  getMoviesById(){
    let userId = localStorage.getItem("UserId");
    return this.http.get("https://localhost:5001/User/getUser?id="+userId);
  }

  logIn(Username: String, Password: string){
    //CHANGE IT
    return this.http.post("https://localhost:5001/User/Login", { Username: Username, PasswordHash: Password }, { responseType: 'json' });
  }

  addWatchedMovieToUser(movieId: String){
    let userId = localStorage.getItem("UserId");

    return this.http.get(`https://localhost:5001/User/addWatchedMovie?uId=${userId}&mId=${movieId}`);

  }

  register(Username: String, Password: string){
    console.log(JSON.stringify({Username: Username, PasswordHash: Password}))
    return this.http.post("https://localhost:5001/User/Register", { Username: Username, PasswordHash: Password }, { responseType: 'json'});

  }
}
