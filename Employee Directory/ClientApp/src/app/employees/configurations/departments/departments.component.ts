import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Department } from '../../../models/Department';
import { DepartmentService } from '../../../services/department.service';
import { Mode } from '../../../shared/enums/mode';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent implements OnInit {
  departmentIdUpdate = null;
  departments: Department[] = [];
  @Input() departmentId: number;
  @Input() departmentMode: Mode;

  constructor(private readonly departmentService: DepartmentService, private modalService: NgbModal, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  departmentForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)])
  })

  get form() { return this.departmentForm.controls }

  saveDepartment() {
    const department = this.departmentForm.value;
    this.addDepartment(department);
    this.modalService.dismissAll();
    this.departmentForm.reset();
    this.departmentService.refreshDepartments();
  }

  addDepartment(department: Department) {
    if (this.departmentIdUpdate == null) {
      this.departmentService.addDepartment(department).subscribe(
        () => {
          this.departmentForm.reset();
          this.toastr.success('Submitted successfully', 'Department Details Register');
        })
    }
    else {
      department.id = this.departmentIdUpdate;
      this.departmentService.updateDepartment(department).subscribe(() => {
        this.departmentIdUpdate = null;
        this.departmentForm.reset();
        this.toastr.success('Updated successfully', 'Department Details Register');
      });
    }
  }
  ngOnChanges() {
    if (this.departmentMode === Mode.Edit) {
      this.loadDepartmentToEdit(this.departmentId);
    }
  }

  loadDepartmentToEdit(departmentId: number) {
    this.departmentService.getDepartmentById(departmentId).subscribe(department => {
      this.departmentIdUpdate = department.id;
      this.departmentForm.patchValue(department);

    });
  }

}
