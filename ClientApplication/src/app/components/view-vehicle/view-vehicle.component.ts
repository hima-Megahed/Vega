import { VehicleService } from './../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle: any;
  vehicleId: number;

  constructor(private route: ActivatedRoute, private router: Router, private toaster: ToastrService, private vehicleService: VehicleService) {
    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
      console.log(this.vehicleId);
      if (isNaN(this.vehicleId) || this.vehicleId <= 0){
        router.navigate(['/vehicles']);
        return;
      }
    });
   }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicleId).subscribe(v => {
      this.vehicle = v;
      console.log(this.vehicle);
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

}
