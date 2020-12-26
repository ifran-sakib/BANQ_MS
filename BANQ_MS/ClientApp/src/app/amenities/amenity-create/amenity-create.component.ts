import { Component, OnInit } from '@angular/core';
import { AmenityService } from '../../shared/amenity.service';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-amenity-create',
  templateUrl: './amenity-create.component.html',
  styleUrls: ['./amenity-create.component.css']
})
export class AmenityCreateComponent implements OnInit {

  constructor(private service: AmenityService, http: HttpClient) { }

  ngOnInit() {
    this.resetForm();
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      id: 0,
      amenityHead: '',
      details: '',
      cost: 0
    }
  }


  onSubmit(form: NgForm) {

    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postAmenityDetail().subscribe(result => {
      this.resetForm(form);

      this.service.getAmenityList();
    }, error => console.error(error));

  }
}
