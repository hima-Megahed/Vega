import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveVehicle } from '../Models/vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  
  constructor(private http: HttpClient) { }

  getFeatures() {
    return this.http.get('api/Features');
  }

  getManufacturers() {
    return this.http.get('api/Manufacturers');
  }

  getVehicle(id) {
    return this.http.get('/api/Vehicles/' + id);
  }

  create(vehicle) {
    return this.http.post('/api/Vehicles', vehicle);
  }

  update(vehicle: SaveVehicle) {
    return this.http.put('/api/Vehicles/' + vehicle.id, vehicle);
  }

  delete(id: number) {
    return this.http.delete('/api/vehicles/' + id);
  }
}
