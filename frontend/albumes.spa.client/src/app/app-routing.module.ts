import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//-- Import Components 
import { AlbumesListComponent } from './components/albumes/albumes-list/albumes-list.component';
import { AlbumCreateComponent } from './components/albumes/album-create/album-create.component';
import { AlbumEditComponent } from './components/albumes/album-edit/album-edit.component';

const routes: Routes = [
  { path: '', redirectTo: 'albumes', pathMatch: 'full' },
  { path: 'albumes', component: AlbumesListComponent },
  { path: 'create', component: AlbumCreateComponent },
  { path: 'edit/:id', component: AlbumEditComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
