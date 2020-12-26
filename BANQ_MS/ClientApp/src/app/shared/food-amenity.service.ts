import { Injectable } from '@angular/core';
import { Food } from './food.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FoodAmenityService {
  formData: Food;

  foodlist: Food[];

  constructor(private http: HttpClient) {

  }

  postFoodDetail() {
    return this.http.post(environment.baseUrl + '/Food', this.formData);
  }

  deleteFoodDetail(id) {
    return this.http.delete(environment.baseUrl + '/Food/' + id);
  }


  getFoodList() {
    this.http.get(environment.baseUrl + '/Food')
      .toPromise()
      .then(result => this.foodlist = result as Food[]);
  }
}
