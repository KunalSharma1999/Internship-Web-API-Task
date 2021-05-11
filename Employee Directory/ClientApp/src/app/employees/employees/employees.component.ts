import { Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from 'src/app/models/Employee';
import { Filter } from 'src/app/models/Filter';
import { Alphabets } from 'src/app/shared/constants/constants';
import { Mode } from 'src/app/shared/enums/mode';
import { EmployeeService } from 'src/app/shared/services/employee.service';
import { JobTitle } from '../../models/JobTitle';
import { JobTitleService } from '../../shared/services/jobtitle.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})

export class EmployeesComponent implements OnInit {
  @ViewChild('content') modalDialogContent;
  alphabets = Alphabets;
  filter: Filter;
  alphabetFilter: string = null;
  searchKeyWord: string = null;
  filterBy: string = '';
  employeeId: number;
  mode: Mode;

  constructor(
    private modalService: NgbModal,
    public employeeService: EmployeeService,
    public jobTitleService: JobTitleService,
    private router: Router 
  ) {
  }

  ngOnInit(){
    this.employeeService.refreshEmployees();
  }

  filterSelected(filter: Filter) {
    this.filter = filter;
  }

  clearSearch() {
    this.searchKeyWord = '';
    this.alphabetFilter = '';
    this.filter = null;
  }

  selectEmployee(employee: Employee) {
    this.employeeId = employee.id;
    this.mode = Mode.Edit;
    this.openEmployeeDialog();
  }

  btnClick() {
    this.router.navigateByUrl("/configurations-component");
  }

  openAddEmployeeDialog() {
    this.mode = Mode.Add;
    this.openEmployeeDialog();
  }

  private openEmployeeDialog() {
    this.modalService.open(this.modalDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => {});
  }
}
