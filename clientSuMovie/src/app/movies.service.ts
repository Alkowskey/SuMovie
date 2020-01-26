import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {SimpleCrypto} from "simple-crypto-js";


@Injectable({
  providedIn: 'root'
})


export class MoviesService {

  simpleCrypto: SimpleCrypto;

  constructor(private http: HttpClient) { 
    var _secretKey = "some-QWERTASD-key";
    
    this.simpleCrypto = new SimpleCrypto(_secretKey);


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
    return this.http.get("https://localhost:5001/User/Login?username="+Username+"&passwordHash="+this.simpleCrypto.encrypt(Password));
  }

  addWatchedMovieToUser(movieId: String){
    let userId = localStorage.getItem("UserId");

    return this.http.get(`https://localhost:5001/User/addWatchedMovie?uId=${userId}&mId=${movieId}`);

  }

  register(Username: String, Password: string){
    console.log(JSON.stringify({Username: Username, PasswordHash: this.simpleCrypto.encrypt(Password)}))
    return this.http.post("https://localhost:5001/User/Register", {Username: Username, PasswordHash: this.simpleCrypto.encrypt(Password)}, {responseType: 'text'});

  }
}