import { Component, OnInit } from '@angular/core';
import { AmenityService } from '../shared/amenity.service';
import { Amenity } from '../shared/amenity.model';

@Component({
  selector: 'app-amenities',
  templateUrl: './amenities.component.html',
  styleUrls: ['./amenities.component.css']
})
export class AmenitiesComponent implements OnInit {

  constructor(private service: AmenityService) { }

  ngOnInit() {
  }

  populateForm(amenity: Amenity) {
    this.service.formData = Object.assign({}, amenity);
  }
  onDelete(id) {
    this.service.deleteAmenityDetail(id).subscribe(result => {


      this.service.getAmenityList();
    }, error => console.error(error));
  }
}
