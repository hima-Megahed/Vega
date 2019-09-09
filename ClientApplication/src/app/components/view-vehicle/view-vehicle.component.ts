import { PhotoService } from './../../services/photo.service';
import { VehicleService } from './../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  @ViewChild('fileInput', {static: false}) fileInput: ElementRef;
  vehicle: any;
  vehicleId: number;
  photos: any[];
  uploadResponse;
  error;

  constructor(private route: ActivatedRoute, private router: Router, private toaster: ToastrService, private vehicleService: VehicleService, private photoService: PhotoService) {
    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
      if (isNaN(this.vehicleId) || this.vehicleId <= 0){
        router.navigate(['/vehicles']);
        return;
      }
    });
   }

  ngOnInit() {
    this.photoService.getPhotos(this.vehicleId).subscribe((photos: any []) => this.photos = photos);

    this.vehicleService.getVehicle(this.vehicleId).subscribe(v => {
      this.vehicle = v;
    }, err => {
      if (err.status == 404) {
        this.router.navigate(['/vehicles']);
        return;
      }
    });
  }

  delete(){
    if(confirm("Are you sure?")){
      this.vehicleService.delete(this.vehicle.id).subscribe(x => {
        this.toaster.info("Vehicle <strong>Deleted</strong> Successfully 👍", "Success", 
        {closeButton: true, enableHtml: true, progressBar: true});
        this.router.navigate(['/']);
      });
    }
  }

  uploadPhoto(){
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    this.photoService.upload(this.vehicleId, nativeElement.files[0]).subscribe(res=> {
      if(res.status === 'progress'){
        console.log("res", res);
        this.uploadResponse = res;
      }
      else if(res.id)
        {
          console.log("res", res);
          this.photos.push(res);
          this.uploadResponse = null;
          this.error = null;
        }
    },
    (err) => this.error = err);

  }

}
