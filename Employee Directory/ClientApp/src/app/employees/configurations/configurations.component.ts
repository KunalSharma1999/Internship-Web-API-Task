import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Department } from '../../models/Department';
import { JobTitle } from '../../models/JobTitle';
import { Office } from '../../models/Office';
import { DepartmentService } from '../../services/department.service';
import { JobTitleService } from '../../services/jobtitle.service';
import { OfficeService } from '../../services/office.service';

@Component({
  selector: 'app-configurations',
  templateUrl: './configurations.component.html',
  styleUrls: ['./configurations.component.css']
})
export class ConfigurationsComponent implements OnInit {

  departments: Department[] = [];
  offices: Office[] = [];
  jobTitles: JobTitle[] = [];

  constructor(private readonly departmentService: DepartmentService, private readonly officeService: OfficeService, private readonly jobTitleService: JobTitleService, private modalService: NgbModal,) {
  }

  ngOnInit() {
    this.departmentService.getDepartments().subscribe(departments => this.departments = departments);
    this.officeService.getOffices().subscribe(offices => this.offices = offices);
    this.jobTitleService.getJobTitles().subscribe(jobTitles => this.jobTitles = jobTitles);
  }

  //department

  selectDepartment(department: Department) {
    this.openAddDepartmentDialog();
    this.departmentForm.patchValue(department);
    this.departmentIdUpdate = department.id;
  }

  departmentIdUpdate = null;

  departmentForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)])
  })

  get dForm() { return this.departmentForm.controls }

  openAddDepartmentDialog() {
    this.departmentForm.reset();
    this.openDepartmentDialog();
  }

  @ViewChild('departmentContent') modalDepartmentDialogContent;

  private openDepartmentDialog() {
    this.modalService.open(this.modalDepartmentDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }

  saveDepartment() {
    const department = this.departmentForm.value;
    this.addDepartment(department);
    this.modalService.dismissAll();
    this.departmentForm.reset();
    this.departmentService.getDepartments();
  }

  addDepartment(department) {
    if (this.departmentIdUpdate == null) {
      this.departmentService.addDepartment(department).subscribe(
        () => {
          this.departmentForm.reset();
        })
    }
    else {
      department.id = this.departmentIdUpdate;
      this.departmentService.updateDepartment(department).subscribe(() => {
        this.departmentIdUpdate = null;
        this.departmentForm.reset();
      });
    }
  }

  // office

  selectOffice(office: Office) {
    this.openAddOfficeDialog();
    this.officeForm.patchValue(office);
    this.officeIdUpdate = office.id;
  }

  officeIdUpdate = null;

  officeForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)])
  })

  get oForm() { return this.officeForm.controls }

  openAddOfficeDialog() {
    this.officeForm.reset();
    this.openOfficeDialog();
  }

  @ViewChild('officeContent') modalOfficeDialogContent;

  private openOfficeDialog() {
    this.modalService.open(this.modalOfficeDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }


  saveOffice() {
    const office = this.officeForm.value;
    this.addOffice(office);
    this.modalService.dismissAll();
    this.officeForm.reset();
    this.officeService.getOffices();
  }

  addOffice(office: Office) {
    if (this.officeIdUpdate == null) {
      this.officeService.addOffice(office).subscribe(
        () => {
          this.officeForm.reset();
        })
    }
    else {
      office.id = this.officeIdUpdate;
      this.officeService.updateOffice(office).subscribe(() => {
        this.officeIdUpdate = null;
        this.officeForm.reset();
      });
    }
  }

  // job title

  selectJobTitle(jobTitle: JobTitle) {
    this.openAddJobTitleDialog();
    this.jobTitleForm.patchValue(jobTitle);
    this.jobTitleIdUpdate = jobTitle.id;
  }

  jobTitleIdUpdate = null;

  jobTitleForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    departmentId: new FormControl('', Validators.required)
  })

  get jForm() { return this.jobTitleForm.controls }

  openAddJobTitleDialog() {
    this.jobTitleForm.reset();
    this.openJobTitleDialog();
  }

  @ViewChild('jobTitleContent') modalJobTitleDialogContent;

  private openJobTitleDialog() {
    this.modalService.open(this.modalJobTitleDialogContent, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }).catch(() => { });
  }

  saveJobTitle() {
    const jobTitle = this.jobTitleForm.value;
    this.addJobTitle(jobTitle);
    this.modalService.dismissAll();
    this.jobTitleForm.reset();
    this.jobTitleService.getJobTitles();
  }

  addJobTitle(jobTitle: JobTitle) {
    if (this.jobTitleIdUpdate == null) {
      this.jobTitleService.addJobTitle(jobTitle).subscribe(
        () => {
          this.jobTitleForm.reset();
        })
    }
    else {
      jobTitle.id = this.jobTitleIdUpdate;
      this.jobTitleService.updateJobTitle(jobTitle).subscribe(() => {
        this.jobTitleIdUpdate = null;
        this.jobTitleForm.reset();
      });
    }
  }

}
