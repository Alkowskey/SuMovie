import { Component, OnInit, ViewChild} from '@angular/core';

import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

import {MoviesService} from '../movies.service';


export interface Movie {
  Id: number;
  Language: string;
  MetaScore: number;
  Rate: number;
  ReleaseDate: string;
  Stars: object[];
  Title: string;
}

@Component({
  selector: 'app-su-movie-main',
  templateUrl: './su-movie-main.component.html',
  styleUrls: ['./su-movie-main.component.scss']
})
export class SuMovieMainComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Title', 'Stars', 'ReleaseDate', 'Rate', 'MetaScore', 'Language'];
  dataSource: MatTableDataSource<Movie>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  Movies: Movie[];

  title = "MovieList";
  

  constructor(private moviesService: MoviesService) { }

  loadMovies(){
    this.moviesService.getAllMovies().subscribe(data => {
      this.Movies = <Movie[]>data;

      this.dataSource = new MatTableDataSource(this.Movies)

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      console.log(this.Movies);
    });
  }

  ngOnInit() {

    this.loadMovies();

  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
