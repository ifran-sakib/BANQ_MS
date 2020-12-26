import { Component, OnInit } from '@angular/core';
import { BanqProgramService } from '../../shared/banq-program.service';
import { CustomerService } from '../../shared/customer.service';
import { BanqInfoService } from '../../shared/banq-info.service';
import { strict } from 'assert';
import { NgForm } from '@angular/forms';
import { BanqInfo } from '../../shared/banq-info.model';
import { EventmanagerService } from '../../shared/eventmanager.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { BanqProgramFood } from '../../shared/banq-program-food.model';
import { Router, ActivatedRoute } from '@angular/router';
import { BanqProgramFoodComponent } from '../banq-program-food/banq-program-food.component';
import { BanqProgramAmenityComponent } from '../banq-program-amenity/banq-program-amenity.component';

@Component({
  selector: 'app-banq-program',
  templateUrl: './banq-program.component.html',
  styleUrls: ['./banq-program.component.css']
})
export class BanqProgramComponent implements OnInit {

  isValid: boolean = true;
  banqInfo: BanqInfo;
  rent: number;
  minimumGuest: number;
  maximumGuest: number;
  vatPer: number;
  scPer: number;


  constructor(private service: BanqProgramService,
    private customerService: CustomerService,
    private banqService: BanqInfoService,
    private eventManagerService: EventmanagerService,
    private dialog: MatDialog,
    private router: Router,
    private currentRoute: ActivatedRoute
  ) { }

  ngOnInit() {

    this.customerService.getCustomerList();
    this.banqService.getBanqList();
    this.eventManagerService.getEvenetManagerList();

    let id = this.currentRoute.snapshot.paramMap.get('id');
    console.log(id);
    if (id == null)
      this.resetForm();
    else {
      this.service.getProgramById(parseInt(id)).then(res => {
        this.service.formData = res.banqProgram;
        this.service.foodItem = res.foodItem;
        this.service.amenityItem = res.amenityItem;
        this.banqInfo = res.banqInfo;

        this.minimumGuest = this.banqInfo.minimumGuest;
        this.maximumGuest = this.banqInfo.maximumGuest;
        this.vatPer = this.banqInfo.vatPer;
        this.scPer = this.banqInfo.scPer;
       
      });
    }

   

  }

  resetForm(form?: NgForm) {

    rent: 0;
    minimumGuest: 0;
    maximumGuest: 0;
    vatPer: 0;
    scPer: 0;

    this.service.formData = {


      id: 0,
      banqId: 0,
      customerId: 0,
      eventMngrId: 0,
      programName: '',
      programDate: '',
      startTime: '',
      noOfPerson: 0,
      foodAmount: 0,
      amenityAmount: 0,
      hallRent: 0,
      totalAmount: 0,
      totalVat: 0,
      totalServiceCharge: 0,
      totalPayable: 0,
      totalPaid: 0,
      dueAmount: 0,
      note: '',
      status: '',
      deletedFoodItemIds: '',
      deletedAmenityItemIds: ''
    };

    this.service.foodItem = [];
    this.service.amenityItem = [];
  }

  onSubmit(form: NgForm) {
    if (this.validateForm()) {

      this.service.formData.customerId = this.convertToInt(this.service.formData.customerId);
      this.service.formData.eventMngrId = this.convertToInt(this.service.formData.eventMngrId);
      this.service.formData.banqId = this.convertToInt(this.service.formData.banqId);
      this.service.formData.noOfPerson = this.convertToInt(this.service.formData.noOfPerson);
     

      this.service.saveOrUpdatProgram().subscribe(res => {
        this.resetForm();
        this.router.navigate(['/banq-programs']);
      })
    }
  }

  validateForm() {
    this.isValid = true;
    if (this.service.formData.customerId == 0)
      this.isValid = false;
    else if (this.service.formData.banqId == 0)
      this.isValid = false;
    else if (this.service.foodItem.length == 0)
      this.isValid = false;
    else if (this.service.amenityItem.length == 0)
      this.isValid = false;
    else if (this.service.formData.noOfPerson == 0)
      this.isValid = false;
    else if (this.service.formData.totalPaid == 0)
      this.isValid = false;
    else if (this.service.formData.programName == '')
      this.isValid = false;
    else if (this.service.formData.programDate == '')
      this.isValid = false;
    return this.isValid;
  }

  convertToInt(val) {
    return parseInt(val, 10);
  }

  AddOrEditFoodItem(orderItemIndex, id) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = { orderItemIndex, id };
    this.dialog.open(BanqProgramFoodComponent, dialogConfig).afterClosed().subscribe(res => {
      
      this.updatFoodTotal();
      this.updatgrandTotal();
    }); 
  }

  AddOrEditAmenity(orderItemIndex, id) {
    console.log(orderItemIndex);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = { orderItemIndex, id };
    this.dialog.open(BanqProgramAmenityComponent, dialogConfig).afterClosed().subscribe(res => {

      this.updatAmenityTotal();
      this.updatgrandTotal();
    });
  }


  onDeleteFoodItem(foodId: number, i: number) {
    if (foodId != null)
      this.service.formData.deletedFoodItemIds += foodId + ",";


    this.service.foodItem.splice(i, 1);
    this.updatFoodTotal();
    
  }

  onDeleteAmenity(amenityId: number, i: number) {
    if (amenityId != null)
      this.service.formData.deletedFoodItemIds += amenityId + ",";


    this.service.amenityItem.splice(i, 1);
    this.updatAmenityTotal();
  }

  updateInfo(ctrl) {
    if (ctrl.selectedIndex == 0) {
      this.service.formData.hallRent = 0;
      this.minimumGuest = 0;
      this.maximumGuest = 0;
      this.vatPer= 0;
      this.scPer= 0;

    } else {
      this.service.formData.hallRent = this.banqService.list[ctrl.selectedIndex - 1].rent;
      this.rent = this.banqService.list[ctrl.selectedIndex - 1].rent;
      this.minimumGuest = this.banqService.list[ctrl.selectedIndex - 1].minimumGuest;
      this.maximumGuest = this.banqService.list[ctrl.selectedIndex - 1].maximumGuest;
      this.vatPer = this.banqService.list[ctrl.selectedIndex - 1].vatPer;
      this.scPer = this.banqService.list[ctrl.selectedIndex - 1].scPer;

      this.updatgrandTotal();
    }
  }


  updatFoodTotal() {
    this.service.formData.foodAmount = this.service.foodItem.reduce((prev, curr) => {
      return prev + curr.total;
    }, 0);

    this.service.formData.foodAmount = parseFloat(this.service.formData.foodAmount.toFixed(2));
  }

  updatAmenityTotal() {
    this.service.formData.amenityAmount = this.service.amenityItem.reduce((prev, curr) => {
      return prev + curr.total;
    }, 0);

    this.service.formData.amenityAmount = parseFloat(this.service.formData.amenityAmount.toFixed(2));
  }



  updatgrandTotal() {
    this.service.formData.totalAmount = this.rent + this.service.formData.foodAmount + this.service.formData.amenityAmount;
    this.service.formData.totalVat = this.service.formData.totalAmount * (this.vatPer / 100);
    this.service.formData.totalServiceCharge = this.service.formData.totalAmount * (this.scPer / 100);
    this.service.formData.totalPayable = this.service.formData.totalAmount + this.service.formData.totalVat + this.service.formData.totalServiceCharge;

    if (this.service.formData.totalPaid > 0) {
      this.service.formData.dueAmount = this.service.formData.totalPayable - this.service.formData.totalPaid;
    }

  }

  updateFinalTotal() {
    this.updatgrandTotal();

  }

}
