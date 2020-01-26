import { Component, OnInit } from '@angular/core';
import {MoviesService} from '../movies.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private moviesService: MoviesService) { }

  ngOnInit() {
  }

  username: string;
  password: string;
  passwordConf: string;

  register(){
    console.log(this.username);
    if(this.password!=this.passwordConf)
    {
        //Toast hasła sie nie zgadzają;
        console.log("Hasła się różnią");
        return;
    }
    else{
      this.moviesService.register(this.username, this.password).subscribe(data =>{
        console.log(data);
      });
    }
}

}
