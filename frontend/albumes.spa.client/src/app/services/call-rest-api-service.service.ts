import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
import { AlbumModel } from '../models/album.interface';

@Injectable({
  providedIn: 'root'
})

export class CallRestApiServiceService {
  private REST_API_SERVER_ALBUMES = "https://localhost:5001/api/Albumes";
  private REST_API_SERVER_ARTISTS = "https://localhost:5001/api/Artists";

  constructor(private httpClient: HttpClient) { }

  public sendGetRequestAlbumes()
  {
    return this.httpClient.get(this.REST_API_SERVER_ALBUMES);
  }

  public sendPostRequestAlbumes(album: AlbumModel)
  {  
    var json = JSON.stringify(album);
    console.log('Json:'+json);

    return this.httpClient.post<any>(this.REST_API_SERVER_ALBUMES, album);
  }

  public sendGetRequestGetAlbumById(id: string | null) : Observable<AlbumModel>
  {
    return this.httpClient.get<AlbumModel>(this.REST_API_SERVER_ALBUMES+"/"+id);
  }

  public sendPutRequestAlbum(album: AlbumModel)
  {
    return this.httpClient.put<any>(this.REST_API_SERVER_ALBUMES, album);
  }

  public sendDeleteRequestAlbum(id: string | null) 
  {
    return this.httpClient.delete(this.REST_API_SERVER_ALBUMES+"/"+id);
  }

  public sendGetRequestArtists()
  {
    return this.httpClient.get(this.REST_API_SERVER_ARTISTS);
  }
}
