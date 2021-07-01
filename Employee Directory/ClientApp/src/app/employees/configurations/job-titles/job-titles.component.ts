import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Department } from '../../../models/Department';
import { JobTitle } from '../../../models/JobTitle';
import { DepartmentService } from '../../../services/department.service';
import { JobTitleService } from '../../../services/jobtitle.service';
import { Mode } from '../../../shared/enums/mode';

@Component({
  selector: 'app-job-titles',
  templateUrl: './job-titles.component.html',
  styleUrls: ['./job-titles.component.css']
})
export class JobTitlesComponent implements OnInit {

  jobTitleIdUpdate = null;
  @Input() jobTitleId: number;
  @Input() jobTitleMode: Mode;
  jobTitleCreatedBy: string;
  jobTitleCreatedOn: Date;

  constructor(public readonly departmentService: DepartmentService, private readonly jobTitleService: JobTitleService, private modalService: NgbModal, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  jobTitleForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]),
    departmentId: new FormControl('', Validators.required)
  })

  get form() { return this.jobTitleForm.controls }

  saveJobTitle() {
    const jobTitle = this.jobTitleForm.value;
    this.addJobTitle(jobTitle);
    this.modalService.dismissAll();
    this.jobTitleForm.reset();
  }

  addJobTitle(jobTitle: JobTitle) {
    if (this.jobTitleIdUpdate == null) {
      this.jobTitleService.addJobTitle(jobTitle).subscribe(
        () => {
          this.jobTitleService.refreshJobTitles();
          this.jobTitleForm.reset();
          this.toastr.success('Submitted successfully', 'JobTitle Details Register');
        })
    }
    else {
      jobTitle.id = this.jobTitleIdUpdate;
      this.jobTitleService.updateJobTitle(jobTitle).subscribe(() => {
        this.jobTitleService.refreshJobTitles();
        this.jobTitleIdUpdate = null;
        this.jobTitleForm.reset();
        this.toastr.success('Updated successfully', 'JobTitle Details Register');
      });
    }
  }
    ngOnChanges() {
      if (this.jobTitleMode === Mode.Edit) {
        this.loadJobTitleToEdit(this.jobTitleId);
      }
    }

  loadJobTitleToEdit(jobTitleId: number) {
      this.jobTitleService.getJobTitleById(jobTitleId).subscribe(jobTitle => {
        this.jobTitleIdUpdate = jobTitle.id;
        this.jobTitleForm.patchValue(jobTitle);

      });
    }

    }

