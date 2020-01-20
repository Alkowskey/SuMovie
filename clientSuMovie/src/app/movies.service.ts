import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(private http: HttpClient) { }

  getAllMovies(){
    return this.http.get("https://localhost:5001/ImdbScraper/getAll");
  }

  getMoviesById(){
    let userId = localStorage.getItem("UserId");
    return this.http.get("https://localhost:5001/User/getUser?id="+userId);
  }

  logIn(Username: String, PasswordHash: String){
    //CHANGE IT
    return this.http.get("https://localhost:5001/User/Login?username="+Username+"&passwordHash="+PasswordHash);
  }

  addWatchedMovieToUser(movieId: String){
    let userId = localStorage.getItem("UserId");

    console.log(userId);
    console.log(movieId);

    //https://localhost:5001/User/addWatchedMovie?uId=1&mId=3

    return this.http.get(`https://localhost:5001/User/addWatchedMovie?uId=${userId}&mId=${movieId}`);

  }
}