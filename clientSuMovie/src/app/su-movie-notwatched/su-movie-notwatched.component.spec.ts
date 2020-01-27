import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuMovieNotwatchedComponent } from './su-movie-notwatched.component';

describe('SuMovieNotwatchedComponent', () => {
  let component: SuMovieNotwatchedComponent;
  let fixture: ComponentFixture<SuMovieNotwatchedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuMovieNotwatchedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuMovieNotwatchedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
