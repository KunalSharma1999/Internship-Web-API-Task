export class Department {
  public id: number;
  public name: string;

  constructor(args: any) {
    args = !!args ? args : {};
    this.id = args.id;
    this.name = args.name;
  }
}
