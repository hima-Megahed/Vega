import { VehicleService } from './../services/vehicle.service';
import { Vehicle, KeyValuePair } from './../Models/vehicle';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  private readonly PAGE_SIZE = 3;
  queryResult: any = {};
  manufacturers: KeyValuePair[];
  query: any = {sortBy: "", isSortAscending: false, PageSize: this.PAGE_SIZE, Page: 1};
  columns = [
    {title: 'Id'},
    {title: 'Manufacturer', key: 'manufacturer', isSortable: true},
    {title: 'Model', key: 'model', isSortable: true},
    {title: 'Contact Name', key: 'contactName', isSortable: true},
    {},
  ];
  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getManufacturers().subscribe((manufacturers: KeyValuePair[]) => this.manufacturers = manufacturers)
    this.populateVehicles();
  }

  onFilterChange() {
    this.query.Page = 1;
    this.populateVehicles();
  }

  sortBy(columName) {
    if (this.query.sortBy === columName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columName;
      this.query.isSortAscending = true;
    }

    this.populateVehicles();
  }

  resetFilter() {
    this.query = {sortBy: "", isSortAscending: false, PageSize: this.PAGE_SIZE, Page: 1};
    this.populateVehicles();
  }

  onPageChange(page){
    this.query.Page = page;
    this.populateVehicles();
  }

  private populateVehicles() {
    this.vehicleService.getVehicles(this.query).subscribe((query: any) => this.queryResult = query);
  }

}
