import { Component, OnInit, Inject } from '@angular/core';
import { BanqProgramAmenity } from '../../shared/banq-program-amenity.model';
import { BanqProgramService } from '../../shared/banq-program.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AmenityService } from '../../shared/amenity.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-banq-program-amenity',
  templateUrl: './banq-program-amenity.component.html',
  styleUrls: ['./banq-program-amenity.component.css']
})
export class BanqProgramAmenityComponent implements OnInit {

  formData: BanqProgramAmenity;
  isValid: boolean = true;

  constructor(@Inject(MAT_DIALOG_DATA) public data, public dialogRef: MatDialogRef<BanqProgramAmenityComponent>, private service: AmenityService, private programService: BanqProgramService) { }

  ngOnInit() {
    this.service.getAmenityList();

    if (this.data.orderItemIndex == null)
      this.formData = {
        id: 0,
        banqProId: this.data.id,
        amenityId: 0,
        amenityHead: '',
        cost: 0,
        quantity: 0,
        total: 0
      }
    else {
      this.formData = Object.assign({}, this.programService.amenityItem[this.data.orderItemIndex]);
    }
  }


  onSubmit(form: NgForm) {

    if (this.validateForm(form.value)) {
      this.formData.amenityId = this.convertToInt(this.formData.amenityId);
      if (this.data.orderItemIndex == null)
        
        this.programService.amenityItem.push(form.value);
      else
        this.programService.amenityItem[this.data.orderItemIndex] = form.value;
      this.dialogRef.close();
    }
  }

  updatePrice(ctrl) {
    if (ctrl.selectedIndex == 0) {
      this.formData.cost = 0;
      this.formData.amenityHead = '';

    } else {
      this.formData.cost = this.service.amenitylist[ctrl.selectedIndex - 1].cost;
      this.formData.amenityHead = this.service.amenitylist[ctrl.selectedIndex - 1].amenityHead;
      this.formData.amenityId = this.convertToInt(this.service.amenitylist[ctrl.selectedIndex - 1].id);
      //this.formData.itemId = this.convertToInt(this.service.list[ctrl.selectedIndex - 1].itemId);
    }
    this.updateTotal()
  }

  updateTotal() {
    this.formData.total = parseFloat((this.formData.quantity * this.formData.cost).toFixed(2));
  }

  validateForm(formdata: BanqProgramAmenity) {
    this.isValid = true;
    if (formdata.amenityId == 0)
      this.isValid = false;

    else if (formdata.quantity == 0)
      this.isValid = false;
    return this.isValid;
  }


  convertToInt(val) {
    return parseInt(val, 10);
  }

}
