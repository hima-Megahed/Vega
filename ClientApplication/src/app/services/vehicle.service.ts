import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
}
