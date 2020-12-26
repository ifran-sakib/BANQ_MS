import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Amenity } from './amenity.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AmenityService {
  formData: Amenity;
  amenitylist: Amenity[];

  constructor(private http: HttpClient) {

  }

  postAmenityDetail() {
    return this.http.post(environment.baseUrl + '/Amenity', this.formData);
  }

  deleteAmenityDetail(id) {
    return this.http.delete(environment.baseUrl + '/Amenity/' + id);
  }

  getAmenityList() {
    this.http.get(environment.baseUrl + '/Amenity')
      .toPromise()
      .then(result => this.amenitylist = result as Amenity[]);
  }
}
