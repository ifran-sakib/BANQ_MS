import { Component, OnInit } from '@angular/core';
import { FoodAmenityService } from '../../shared/food-amenity.service';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-food-create',
  templateUrl: './food-create.component.html',
  styleUrls: ['./food-create.component.css']
})
export class FoodCreateComponent implements OnInit {

  constructor(private service: FoodAmenityService, http: HttpClient) { }

  ngOnInit() {
    this.resetForm();
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      id: 0,
      foodName: '',
      foodNo: '',
      description: '',
      price:0
    }
  }


  onSubmit(form: NgForm) {

    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postFoodDetail().subscribe(result => {
      this.resetForm(form);
     
      this.service.getFoodList();
    }, error => console.error(error));

  }



  //onSubmit(form: NgForm) {
  //  console.log(form);


  //}
}
