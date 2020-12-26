import { Component, OnInit } from '@angular/core';
import { BanqProgramService } from '../shared/banq-program.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-banq-programs',
  templateUrl: './banq-programs.component.html',
  styleUrls: ['./banq-programs.component.css']
})
export class BanqProgramsComponent implements OnInit {

  programList;

  constructor(private service: BanqProgramService,
    private router: Router) { }

  ngOnInit() {
    this.resfreshList();
  }


  resfreshList() {
    this.service.getProgramList().then(res => this.programList = res);

  }

  openForEdit(programId: number) {
   
    this.router.navigate(['/banq-program/edit/' + programId]);
  }

  onOrderDelete(id: number) {
    this.service.onDeleteProgram(id).then(res => {
      this.resfreshList();
    });
  }
}
