export class Employee{
    public id:number;
    public firstName: string;
    public lastName: string;
    public preferredName: string;
    public email: string;
    public phoneNumber: string;
    public skypeId: string;
    public departmentId: number;
    public officeId: number;
    public jobTitleId: number;

    constructor(args: any){
        args = !!args ? args : {};
        this.id = args.id;
        this.firstName = args.firstName;
        this.lastName = args.lastName;
        this.preferredName = args.preferredName;
        this.email = args.Email;
        this.phoneNumber = args.phoneNumber;
        this.skypeId = args.skypeId;
        this.departmentId = args.departmentId;
        this.officeId = args.officeId;
        this.jobTitleId = args.jobTitleId;
        
    }
}
