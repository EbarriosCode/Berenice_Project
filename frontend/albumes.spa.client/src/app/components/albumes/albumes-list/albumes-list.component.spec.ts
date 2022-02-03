import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumesListComponent } from './albumes-list.component';

describe('AlbumesListComponent', () => {
  let component: AlbumesListComponent;
  let fixture: ComponentFixture<AlbumesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlbumesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
