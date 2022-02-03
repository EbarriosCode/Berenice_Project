import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CallRestApiServiceService } from 'src/app/services/call-rest-api-service.service';

@Component({
  selector: 'app-albumes-list',
  templateUrl: './albumes-list.component.html',
  styleUrls: ['./albumes-list.component.css']
})
export class AlbumesListComponent implements OnInit {

  public albumes: Array<any> = [];

  constructor(private dataService: CallRestApiServiceService, private router: Router) { }

  ngOnInit(): void 
  {
    this.dataService.sendGetRequestAlbumes().subscribe((data: any) => {
      this.albumes = data;
    });
  }
  
  editAlbum(id: number)
  {
    this.router.navigate(['edit', id]);
  }

  deleteAlbum(id: string)
  {  
    this.dataService.sendDeleteRequestAlbum(id).subscribe(data => {
      console.log(data);
      this.ngOnInit();
    });
  }
}
