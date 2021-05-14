import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Department } from '../../models/Department';
import { JobTitle } from '../../models/JobTitle';
import { Office } from '../../models/Office';
import { DepartmentService } from '../../services/department.service';
import { JobTitleService } from '../../services/jobtitle.service';
import { OfficeService } from '../../services/office.service';
import { Mode } from '../../shared/enums/mode';

@Component({
  selector: 'app-configurations',
  templateUrl: './configurations.component.html',
  styleUrls: ['./configurations.component.css']
})
export class ConfigurationsComponent implements OnInit {
  departmentId: number;
  departmentMode: Mode;
  @ViewChild('departmentContent') modalDepartmentDialogContent;
  officeId: number;
  officeMode: Mode;
  @ViewChild('officeContent') modalOfficeDialogContent;
  jobTitleId: number;
  jobTitleMode: Mode;
  @ViewChild('jobTitleContent') modalJobTitleDialogContent;

  constructor(public readonly departmentService: DepartmentService, public readonly jobTitleService: JobTitleService, public readonly officeService: OfficeService, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.loadConfigurations();
  }

  loadConfigurations(){
    this.departmentService.refreshDepartments();
    this.officeService.refreshOffices();
    this.jobTitleService.refreshJobTitles();
  }
  
  selectDepartment(department: Department) {
    this.departmentId = department.id;
    this.departmentMode = Mode.Edit;
    this.openDepartmentDialog();
  }

  openAddDepartmentDialog() {
    this.departmentMode = Mode.Add;
    this.openDepartmentDialog();
  }



  private openDepartmentDialog() {
    this.modalService.open(this.modalDepartmentDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }

  selectOffice(office: Office) {
    this.officeId = office.id;
    this.officeMode = Mode.Edit;
    this.openOfficeDialog();
  }

  openAddOfficeDialog() {
    this.officeMode = Mode.Add;
    this.openOfficeDialog();
  }

  private openOfficeDialog() {
    this.modalService.open(this.modalOfficeDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }

  selectJobTitle(jobTitle: JobTitle) {
    this.jobTitleId = jobTitle.id;
    this.jobTitleMode = Mode.Edit;
    this.openJobTitleDialog();
  }

  openAddJobTitleDialog() {
    this.jobTitleMode = Mode.Add;
    this.openJobTitleDialog();
  }

  private openJobTitleDialog() {
    this.modalService.open(this.modalJobTitleDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }

  }

