import { Component, OnInit } from '@angular/core';
import {MoviesService} from '../movies.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private moviesService: MoviesService) { }

  username: string;
  password: string;

  ngOnInit() {
  }

  login(){
      console.log(this.username);
      this.moviesService.logIn(this.username, this.password).subscribe(data =>{
        console.log(data);

        localStorage.setItem("UserId", data['id']);
      })
  }

}
