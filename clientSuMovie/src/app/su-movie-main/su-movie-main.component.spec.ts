import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuMovieMainComponent } from './su-movie-main.component';

describe('SuMovieMainComponent', () => {
  let component: SuMovieMainComponent;
  let fixture: ComponentFixture<SuMovieMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuMovieMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuMovieMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
