import { Component, OnInit , Input} from '@angular/core';
import { Employee } from 'src/app/models/Employee';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { Mode } from 'src/app/shared/enums/mode';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DepartmentService } from 'src/app/services/department.service';
import { OfficeService } from 'src/app/services/office.service';
import { JobTitleService } from 'src/app/services/jobtitle.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  @Input() employeeId: number;
  @Input() mode: Mode;  
  employeeIdUpdate = null; 
  formTitle: string = "Enter Employee Details";

  constructor(private employeeService: EmployeeService, private modalService: NgbModal, private toastr: ToastrService, public departmentService: DepartmentService, public officeService: OfficeService, public jobTitleService: JobTitleService) {}

  ngOnInit(): void {
    this.loadSelectOptions();
  }

  loadSelectOptions() {
    this.departmentService.refreshDepartments();
    this.officeService.refreshOffices();
    this.jobTitleService.refreshJobTitles();
  }

    employeeForm = new FormGroup({
    firstName: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    lastName: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    preferredName: new FormControl('',Validators.required),
    email: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z0-9\.]+@[a-zA-Z]+\.[a-zA-Z]{2,3}$/)]),
    jobTitle: new FormControl(''),
    office: new FormControl(''),
    department: new FormControl(''),
    phoneNumber: new FormControl('',[Validators.required, Validators.pattern(/^\d{10}$/)]),
    skypeId: new FormControl('',Validators.required),
    departmentId: new FormControl('', Validators.required),
    officeId: new FormControl('', Validators.required),
    jobTitleId: new FormControl('', Validators.required)
    })

  saveEmployee() {   
    const employee = this.employeeForm.value;  
    this.addEmployee(employee);
    this.modalService.dismissAll();  
    this.employeeForm.reset();
    this.employeeService.refreshEmployees();
  } 

  addEmployee(employee:Employee){
    if (this.employeeIdUpdate == null) {
      this.employeeService.addEmployee(employee).subscribe(  
        () => {    
          this.employeeForm.reset();
          this.toastr.success('Submitted successfully', 'Employee Details Register');
        }  
      );
    }
    else
    {
    employee.id = this.employeeIdUpdate;
    this.employeeService.updateEmployee(employee).subscribe(() => {  
      this.employeeIdUpdate = null;
      this.employeeForm.reset();
      this.toastr.success('Updated successfully', 'Employee Details Register');
    });
    }
  }

  loadEmployeeToEdit(employeeId: number) {  
    this.employeeService.getEmployeeById(employeeId).subscribe(employee=> {   
      this.employeeIdUpdate = employee.id;
      this.employeeForm.patchValue(employee);

    });  
  
  } 

  get Modes() {
      return Mode;
  }

  get form() {return this.employeeForm.controls}

  ngOnChanges() {
    if (this.mode === Mode.Edit) {
        this.loadEmployeeToEdit(this.employeeId);
    }
  }

  updatePreferredName() {
    this.employeeForm.get('preferredName').setValue(this.employeeForm.get('firstName').value + ' ' + this.employeeForm.get('lastName').value);
  }
}

