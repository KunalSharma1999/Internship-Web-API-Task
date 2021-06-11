import { Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Filter } from 'src/app/models/Filter';
import { Alphabets } from 'src/app/shared/constants/constants';
import { Mode } from 'src/app/shared/enums/mode';
import { EmployeeService } from 'src/app/services/employee.service';
import { JobTitleService } from '../../services/jobtitle.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { EmployeeCard } from 'src/app/models/EmployeeCard';

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
  public employees: EmployeeCard[];

  constructor(
    private repository: RepositoryService, private modalService: NgbModal, public employeeService: EmployeeService, public jobTitleService: JobTitleService, private router: Router) {}

  ngOnInit(){
    this.getEmployees();
  }

  filterSelected(filter: Filter) {
    this.filter = filter;
  }

  public getEmployees = () => {
    const apiAddress: string = "api/Employees";
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.employees = res as EmployeeCard[];
    })
  }

  clearSearch() {
    this.searchKeyWord = '';
    this.alphabetFilter = '';
    this.filter = null;
  }

  selectEmployee(id: number) {
    this.employeeId = id;
    this.mode = Mode.Edit;
    this.openEmployeeDialog();
  }

  btnClick() {
    this.router.navigateByUrl("/configurations");
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
