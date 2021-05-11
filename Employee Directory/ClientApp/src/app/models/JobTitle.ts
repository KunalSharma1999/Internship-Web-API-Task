export class JobTitle {
  public id: number;
  public name: string;
  public departmentId: number;

  constructor(args: any) {
    args = !!args ? args : {};
    this.id = args.id;
    this.name = args.name;
    this.departmentId = args.departmentId;
  }
}
