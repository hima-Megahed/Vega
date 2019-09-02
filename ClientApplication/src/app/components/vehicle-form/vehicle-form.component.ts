import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { SaveVehicle, Vehicle } from 'src/app/Models/vehicle';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  manufacturers: any[];
  models: any[];
  vehicle: SaveVehicle = {
    id: 0,
    modelId: 0,
    manufacturerId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: ''
    }
  };
  features: any;

  constructor(private vehicleService: VehicleService, private router: Router, private toaster: ToastrService ,route: ActivatedRoute) {
    route.params.subscribe(p => {
      this.vehicle.id = +p['id'] ? +p['id'] : 0;
    })
  }

  ngOnInit() {
    var sources = [
      this.vehicleService.getManufacturers(),
      this.vehicleService.getFeatures()
    ];

    if(this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    forkJoin(sources)
      .subscribe((data: any[]) => {
        this.manufacturers = data[0];
        this.features = data[1];
        
        if(this.vehicle.id){
          this.setVehicle(data[2]);
          this.populateModels();
        }
      });
  }

  onManufacturerChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    if(this.vehicle.id){
      this.vehicleService.update(this.vehicle).subscribe(x => 
        this.toaster.success("Vehicle <strong>Updated</strong> Successfully 👍", "Success", 
        {closeButton: true, enableHtml: true, progressBar: true}));
    }
    else{
      this.vehicleService.create(this.vehicle).subscribe(x =>
        this.toaster.success("Vehicle <strong>Created</strong> Successfully 😃", "Success",
        {closeButton: true, enableHtml: true, progressBar: true}));
    }
      
    
  }

  delete(){
    if(confirm("Are you sure?")){
      this.vehicleService.delete(this.vehicle.id).subscribe(x => {
        this.toaster.info("Vehicle <strong>Deleted</strong> Successfully 👍", "Success", 
        {closeButton: true, enableHtml: true, progressBar: true}).onHidden.subscribe(t => this.router.navigate(['/']));
      });
    }
  }
  private populateModels(){
    const selectedManufacturer = this.manufacturers.find(m => m.id == this.vehicle.manufacturerId);
    this.models = selectedManufacturer ? selectedManufacturer.models : [];
  }

  private setVehicle(vehicle: Vehicle){
    this.vehicle.id = vehicle.id;
    this.vehicle.modelId = vehicle.model.id;
    this.vehicle.manufacturerId = vehicle.manufacturer.id;
    this.vehicle.isRegistered = vehicle.isRegistered;
    this.vehicle.features = vehicle.features.map(feature => feature.id );
    this.vehicle.contact = vehicle.contact
  }
}
