import { Injectable } from '@angular/core';
import { BanqProgram } from './banq-program.model';
import { Food } from './food.model';
import { Amenity } from './amenity.model';
import { BanqProgramFood } from './banq-program-food.model';
import { BanqProgramAmenity } from './banq-program-amenity.model';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BanqProgramService {
  formData: BanqProgram;
  foodItem: BanqProgramFood[];
  amenityItem: BanqProgramAmenity[];
   
  constructor(private http: HttpClient) { }


  saveOrUpdatProgram() {

    for (let entry of this.foodItem) {
      entry.id = this.convertToInt(entry.id);
      entry.foodId = this.convertToInt(entry.foodId);// 1, "string", false
      
    }
    for (let entry of this.amenityItem) {
      entry.id = this.convertToInt(entry.id);
      entry.amenityId = this.convertToInt(entry.amenityId);// 1, "string", false
    }

    var body = {
      ...this.formData,
      banqProgramFood: this.foodItem,
      banqProgramAmenity: this.amenityItem
    };

    console.log(body);
    return this.http.post(environment.baseUrl + '/banqProgram', body);
    
}


  convertToInt(val) {
    return parseInt(val, 10);
  }


  getProgramList() {
    return this.http.get(environment.baseUrl + '/banqProgram').toPromise();
    
  }

  getProgramById(id: number): any {
    return this.http.get(environment.baseUrl + '/banqProgram/' + id).toPromise();
  }

  onDeleteProgram(id: number) {
    return this.http.delete(environment.baseUrl + '/banqProgram/' + id).toPromise();
  }
}
