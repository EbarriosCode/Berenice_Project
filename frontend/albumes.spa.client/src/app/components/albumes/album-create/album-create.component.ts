import { Component, OnInit } from '@angular/core';
import { CallRestApiServiceService } from 'src/app/services/call-rest-api-service.service';
import { AlbumModel } from '../../../models/album.interface';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-album-create',
  templateUrl: './album-create.component.html',
  styleUrls: ['./album-create.component.css']
})
export class AlbumCreateComponent implements OnInit {

  public artists: Array<any> = [];

  albumForm = new FormGroup({
    title : new FormControl(''),
    artistID: new FormControl(''),
    price : new FormControl(''),
    date: new FormControl(''),
    availableToPurchase : new FormControl('')
  });

  constructor(private dataService: CallRestApiServiceService,
              private router: Router) { }

  ngOnInit(): void 
  {  
    this.dataService.sendGetRequestArtists().subscribe((data: any) => {
      this.artists = data;
    });
  }

  onCreateAlbum(album: AlbumModel)
  {    
    this.dataService.sendPostRequestAlbumes(album).subscribe(data =>{
      console.log(data)
    });

    this.router.navigate(['albumes']);
  }
}
