import { Component, OnInit } from '@angular/core';
import { AmenityService } from '../../shared/amenity.service';
import { Amenity } from '../../shared/amenity.model';

@Component({
  selector: 'app-amenity-list',
  templateUrl: './amenity-list.component.html',
  styleUrls: ['./amenity-list.component.css']
})
export class AmenityListComponent implements OnInit {

  constructor(private service: AmenityService) { }

  ngOnInit() {
    this.service.getAmenityList();
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
