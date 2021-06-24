import { Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Filter } from 'src/app/models/Filter';
import { Mode } from 'src/app/shared/enums/mode';
import { EmployeeService } from 'src/app/services/employee.service';
import { JobTitleService } from '../../services/jobtitle.service';
import { EmployeeCard } from 'src/app/models/EmployeeCard';
import { Constants } from 'src/app/shared/constants';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})

export class EmployeesComponent implements OnInit {
  @ViewChild('content') modalDialogContent;
  alphabets = Constants.Alphabets;
  filter: Filter;
  alphabetFilter: string = null;
  searchKeyWord: string = null;
  filterBy: string = '';
  employeeId: number;
  mode: Mode;
  public employees: EmployeeCard[];
  public isUserAdmin: boolean = false;

  constructor(
    private _authService: AuthService, private modalService: NgbModal, public employeeService: EmployeeService, public jobTitleService: JobTitleService, private router: Router) {}

    ngOnInit(): void {
      this.isAdmin();
      this.employeeService.getEmployees();
    }

  filterSelected(filter: Filter) {
    this.filter = filter;
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

  routeToConfigurationsComponent() {
    this.router.navigateByUrl("/configurations");
  }

  routeToPrivacyComponent() {
    this.router.navigateByUrl("/privacy");
  }

  openAddEmployeeDialog() {
    this.mode = Mode.Add;
    this.openEmployeeDialog();
  }

  private openEmployeeDialog() {
    this.modalService.open(this.modalDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => {});
  }

  public isAdmin = () => {
    return this._authService.checkIfUserIsAdmin()
    .then(res => {
      this.isUserAdmin = res;
    })
  }
}
