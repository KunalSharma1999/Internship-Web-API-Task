export class Employee{
    public Id:number;
    public FirstName: string
    public LastName: string
    public PreferredName: string
    public Email: string
    public JobTitle: string
    public Office: string
    public Department: string
    public PhoneNumber: string
    public SkypeId: string

    constructor(args: any){
        args = !!args ? args : {};
        this.Id = args.Id;
        this.FirstName = args.FirstName;
        this.LastName = args.LastName;
        this.PreferredName = args.PreferredName;
        this.Email = args.Email;
        this.JobTitle = args.JobTitle;
        this.Office = args.Office;
        this.Department = args.Department;
        this.PhoneNumber = args.PhoneNumber;
        this.SkypeId = args.SkypeId;
    }
}