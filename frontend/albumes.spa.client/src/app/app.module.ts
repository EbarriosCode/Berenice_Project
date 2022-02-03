import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AlbumesListComponent } from './components/albumes/albumes-list/albumes-list.component';
import { AlbumCreateComponent } from './components/albumes/album-create/album-create.component';
import { AlbumEditComponent } from './components/albumes/album-edit/album-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    AlbumesListComponent,
    AlbumCreateComponent,
    AlbumEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
