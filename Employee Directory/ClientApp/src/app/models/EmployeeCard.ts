export class EmployeeCard {
  public id: number;
  public preferredName: string;
  public email: string;
  public department: number;
  public office: number;
  public jobTitle: number;

  constructor(args: any) {
    args = !!args ? args : {};
    this.id = args.id;
    this.preferredName = args.preferredName;
    this.email = args.Email;
    this.department = args.department;
    this.office = args.office;
    this.jobTitle = args.jobTitle;
  }
}
