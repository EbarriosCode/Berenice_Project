import { Component, OnInit } from '@angular/core';
import { CallRestApiServiceService } from 'src/app/services/call-rest-api-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlbumModel } from 'src/app/models/album.interface';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-album-edit',
  templateUrl: './album-edit.component.html',
  styleUrls: ['./album-edit.component.css']
})
export class AlbumEditComponent implements OnInit {

  albumData: AlbumModel = {
    albumID: 0,
    title: '',
    artistID: 0,
    price: 0,
    date: new Date,
    availableToPurchase: false
  }

  albumForm = new FormGroup({
    albumID : new FormControl(''),
    title : new FormControl(''),
    artistID: new FormControl(''),
    price : new FormControl(''),
    date: new FormControl(''),
    availableToPurchase : new FormControl('')
  });

  public artists: Array<any> = [];

  constructor(private activatedRoute: ActivatedRoute, 
              private router: Router, 
              private dataService: CallRestApiServiceService) 
  { }  

  ngOnInit(): void
  {
    this.dataService.sendGetRequestArtists().subscribe((data: any) => {
      this.artists = data;
    });

    let albumId = this.activatedRoute.snapshot.paramMap.get('id');

    this.dataService.sendGetRequestGetAlbumById(albumId).subscribe((data : any) =>{  
      this.albumData = data;    
      
      this.albumForm.setValue({
        'albumID': this.albumData.albumID,
        'title' : this.albumData.title,
        'artistID' : this.albumData.artistID,
        'price' : this.albumData.price,
        'date' : this.albumData.date,
        'availableToPurchase' : this.albumData.availableToPurchase
      });
    });
  }

  onEditAlbum(album: AlbumModel)
  {    
    console.log(album)
    this.dataService.sendPutRequestAlbum(album).subscribe(data =>{
      console.log(data)
    });

    this.router.navigate(['albumes']);
  }
}
