import { Component, OnInit, ViewChild } from '@angular/core';

import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

import {MoviesService} from '../movies.service';

import { ToastrService } from 'ngx-toastr';

export interface Movie {
  Id: number;
  Genres: object[];
  MetaScore: number;
  Rate: number;
  ReleaseDate: string;
  Stars: object[];
  Title: string;
}


@Component({
  selector: 'app-predictions',
  templateUrl: './predictions.component.html',
  styleUrls: ['./predictions.component.scss']
})
export class PredictionsComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Title', 'Rate', 'MetaScore', 'Genre', 'Actions'];
  dataSource: MatTableDataSource<Movie>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  Movies: Movie[];

  title = "PredictionList";
  userId;

  constructor(private moviesService: MoviesService, private toastr: ToastrService) { }

  loadPredictions(){
    this.moviesService.getAllPredictions().subscribe(data => {
      if(data!==null && data!==undefined)
        this.toastr.info("Załadowano polecane filmy","Polecane")
      this.Movies = <Movie[]>data;

      this.dataSource = new MatTableDataSource(this.Movies)

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  ngOnInit() {

    this.loadPredictions();

    this.userId = localStorage.getItem("UserId");

    console.log(this.userId);
  }

  deleteRow(row){
      this.moviesService.addWatchedMovieToUser(row.id).subscribe(data => {
        console.log(data);
      })

      this.dataSource.data.splice(this.dataSource.data.indexOf(row), 1);
      this.dataSource._updateChangeSubscription();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  

}


