import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { BanqProgramFood } from '../../shared/banq-program-food.model';
import { BanqProgramService } from '../../shared/banq-program.service';
import { NgForm } from '@angular/forms';
import { FoodAmenityService } from '../../shared/food-amenity.service';

@Component({
  selector: 'app-banq-program-food',
  templateUrl: './banq-program-food.component.html',
  styleUrls: ['./banq-program-food.component.css']
})
export class BanqProgramFoodComponent implements OnInit {

  formData: BanqProgramFood;
  isValid: boolean = true;

  constructor(@Inject(MAT_DIALOG_DATA) public data, public dialogRef: MatDialogRef<BanqProgramFoodComponent>, private service: FoodAmenityService, private programService: BanqProgramService) { }

  ngOnInit() {
    this.service.getFoodList();

    if (this.data.orderItemIndex == null)
      this.formData = {
        id: 0,
        banqProId: this.data.id,
        foodId: 0,
        foodName: '',
        price: 0,
        quantity: 0,
        total: 0
      }
    else {
      this.formData = Object.assign({}, this.programService.foodItem[this.data.orderItemIndex]);
    }
  }


  onSubmit(form: NgForm) {
   
    if (this.validateForm(form.value)) {
      //this.formData.foodId = this.convertToInt(this.formData.foodId);
      if (this.data.orderItemIndex == null)
        this.programService.foodItem.push(form.value);
      else
        this.programService.foodItem[this.data.orderItemIndex] = form.value;
      this.dialogRef.close();
    }
  }

  updatePrice(ctrl) {
    if (ctrl.selectedIndex == 0) {
      this.formData.price = 0;
      this.formData.foodName = '';

    } else {
      this.formData.price = this.service.foodlist[ctrl.selectedIndex - 1].price;
      this.formData.foodName = this.service.foodlist[ctrl.selectedIndex - 1].foodName;
      this.formData.foodId = this.convertToInt(this.service.foodlist[ctrl.selectedIndex - 1].id);

      console.log(this.service.foodlist[ctrl.selectedIndex - 1].id);

     
    }
    this.updateTotal()
  }

  updateTotal() {
    this.formData.total = parseFloat((this.formData.quantity * this.formData.price).toFixed(2));
  }

  validateForm(formdata: BanqProgramFood) {
    this.isValid = true;
    if (formdata.foodId == 0)
      this.isValid = false;

    else if (formdata.quantity == 0)
      this.isValid = false;
    return this.isValid;
  }


  convertToInt(val) {
    return parseInt(val, 10);
  }

}
