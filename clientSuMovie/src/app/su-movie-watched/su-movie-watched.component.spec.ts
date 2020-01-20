import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuMovieWatchedComponent } from './su-movie-watched.component';

describe('SuMovieWatchedComponent', () => {
  let component: SuMovieWatchedComponent;
  let fixture: ComponentFixture<SuMovieWatchedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuMovieWatchedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuMovieWatchedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
