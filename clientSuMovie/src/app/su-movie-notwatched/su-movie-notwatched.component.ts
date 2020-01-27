import { Component, OnInit, ViewChild} from '@angular/core';

import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

import {MoviesService} from '../movies.service';


export interface Movie {
  Genres: String;
  Id: number;
  MetaScore: number;
  Rate: number;
  ReleaseDate: string;
  Stars: object[];
  Title: string;
}

@Component({
  selector: 'app-su-movie-notwatched',
  templateUrl: './su-movie-notwatched.component.html',
  styleUrls: ['./su-movie-notwatched.component.scss']
})
export class SuMovieNotwatchedComponent implements OnInit {

  
  displayedColumns: string[] = ['Id', 'Title', 'Rate', 'MetaScore', 'Genres', 'Actions'];
  dataSource: MatTableDataSource<Movie>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  Movies: Movie[];

  title = "MovieList";
  userId;

  constructor(private moviesService: MoviesService) { }

  loadMovies(){
    this.moviesService.notWatchedMovies().subscribe(data => {
      this.Movies = <Movie[]>data;

      this.dataSource = new MatTableDataSource(this.Movies)

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      console.log(this.Movies);
    });
  }

  ngOnInit() {

    this.loadMovies();

    this.userId = localStorage.getItem("UserId");

    console.log(this.userId);
  }

  watchedMovie(mId){
    console.log(mId);
    this.moviesService.addWatchedMovieToUser(mId).subscribe(data =>{

      console.log(data);
      
    });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


}
