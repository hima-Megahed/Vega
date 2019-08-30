import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  manufacturers: any[];
  models: any[];
  vehicle: any = {};
  features;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getManufacturers().subscribe((manufacturers: any[]) => this.manufacturers = manufacturers);
    this.vehicleService.getFeatures().subscribe(features => this.features = features);
  }

  onManufacturerChange() {
    var selectedManufacturer = this.manufacturers.find(m => m.id == this.vehicle.manufacturerId);
    this.models = selectedManufacturer ? selectedManufacturer.models : [];
  }
}
