import { Component, OnInit } from '@angular/core';
import { FoodAmenityService } from '../../shared/food-amenity.service';
import { Food } from '../../shared/food.model';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  styleUrls: ['./food-list.component.css']
})
export class FoodListComponent implements OnInit {

  constructor(private service: FoodAmenityService) { }

  ngOnInit() {
    this.service.getFoodList();
  }

  populateForm(food: Food) {
    this.service.formData = Object.assign({}, food);
  }
  onDelete(id) {
    this.service.deleteFoodDetail(id).subscribe(result => {

      
      this.service.getFoodList();
    }, error => console.error(error));
  }
}
