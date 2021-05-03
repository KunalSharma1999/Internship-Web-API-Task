import { Component, OnInit , Input} from '@angular/core';
import { Employee } from 'src/app/models/Employee';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/shared/services/employee.service';
import { Mode } from 'src/app/shared/enums/mode';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LookupService } from 'src/app/shared/services/lookup.service';

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
  constructor(private employeeService : EmployeeService,  private modalService: NgbModal, public lookupService: LookupService) { }

  ngOnInit(): void {  
  }

    employeeForm = new FormGroup({
    FirstName: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    LastName: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    PreferredName: new FormControl('',Validators.required),
    Email: new FormControl('',[Validators.required, Validators.pattern(/^[a-zA-Z0-9\.]+@[a-zA-Z]+\.[a-zA-Z]{2,3}$/)]),
    JobTitle: new FormControl('', Validators.required),
    Office: new FormControl('', Validators.required),
    Department: new FormControl('', Validators.required),
    PhoneNumber: new FormControl('',[Validators.required, Validators.pattern(/^\d{10}$/)]),
    SkypeId: new FormControl('',Validators.required)
    })

  saveEmployee() {   
    const employee = this.employeeForm.value;  
    this.addEmployee(employee);
    this.modalService.dismissAll();  
    this.employeeForm.reset();  
  } 

  addEmployee(employee:Employee){
    if (this.employeeIdUpdate == null) { 
      this.employeeService.addEmployee(employee).subscribe(  
        () => {    
          this.employeeForm.reset();  
        }  
      );
    }
    else
    {
    employee.Id = this.employeeIdUpdate;
    this.employeeService.updateEmployee(employee).subscribe(() => {  
      this.employeeIdUpdate = null;
      this.employeeForm.reset();  
    });
    }
  }

  loadEmployeeToEdit(employeeId: number) {  
    this.employeeService.getEmployeeById(employeeId).subscribe(employee=> {   
      this.employeeIdUpdate = employee.Id;
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
    this.employeeForm.get('PreferredName').setValue(this.employeeForm.get('FirstName').value + ' ' + this.employeeForm.get('LastName').value);
  }

  dismissModal() {
    this.modalService.dismissAll();
  }
}

