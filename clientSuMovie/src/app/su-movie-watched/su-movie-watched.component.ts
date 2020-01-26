import { Component, OnInit, ViewChild} from '@angular/core';

import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

import {MoviesService} from '../movies.service';


export interface Movie {
  Id: number;
  Genres: Object[];
  MetaScore: number;
  Rate: number;
  ReleaseDate: string;
  Stars: object[];
  Title: string;
}

@Component({
  selector: 'app-su-movie-watched',
  templateUrl: './su-movie-watched.component.html',
  styleUrls: ['./su-movie-watched.component.scss']
})
export class SuMovieWatchedComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Title', 'Stars', 'ReleaseDate', 'Rate', 'MetaScore', 'Genres'];
  dataSource: MatTableDataSource<Movie>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  Movies: Movie[];

  title = "MovieList";
  userId;
  

  constructor(private moviesService: MoviesService) { }

  loadMovies(){
    this.moviesService.getMoviesById().subscribe(data => {
      console.log(data);
      this.Movies = <Movie[]>data['watchedMovies'];

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

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
