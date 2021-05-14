import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Office } from '../../../models/Office';
import { OfficeService } from '../../../services/office.service';
import { Mode } from '../../../shared/enums/mode';

@Component({
  selector: 'app-offices',
  templateUrl: './offices.component.html',
  styleUrls: ['./offices.component.css']
})
export class OfficesComponent implements OnInit {
  officeIdUpdate = null;
  offices: Office[] = [];
  @Input() officeId: number;
  @Input() officeMode: Mode;

  constructor(private readonly officeService: OfficeService, private modalService: NgbModal, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadOffices();
  }

  loadOffices() {
    this.officeService.getOffices().subscribe(offices => this.offices = offices);
  }

  officeForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)])
  })

  get form() { return this.officeForm.controls }

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
          this.toastr.success('Submitted successfully', 'Office Details Register');
        })
    }
    else {
      office.id = this.officeIdUpdate;
      this.officeService.updateOffice(office).subscribe(() => {
        this.officeIdUpdate = null;
        this.officeForm.reset();
        this.toastr.success('Updated successfully', 'Office Details Register');
      });
    }
  }
  ngOnChanges() {
    if (this.officeMode === Mode.Edit) {
      this.loadOfficeToEdit(this.officeId);
    }
  }

  loadOfficeToEdit(officeId: number) {
    this.officeService.getOfficeById(officeId).subscribe(office => {
      this.officeIdUpdate = office.id;
      this.officeForm.patchValue(office);

    });
  }
}
