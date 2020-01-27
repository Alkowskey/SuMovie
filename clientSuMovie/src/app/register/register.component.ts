import { Component, OnInit } from '@angular/core';
import {MoviesService} from '../movies.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private moviesService: MoviesService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  username: string;
  password: string;
  passwordConf: string;

  register(){
    console.log(this.username);
    if(this.password!=this.passwordConf)
    {
        this.toastr.error("Hasła nie są takie same", "Rejestracja")
        return;
    }
    else{
      this.moviesService.register(this.username, this.password).subscribe(data =>{
        if(data!==null && data!==undefined)
          this.toastr.success("Zarejestrowano!", "Rejestarcja");
      });
    }
}

}
