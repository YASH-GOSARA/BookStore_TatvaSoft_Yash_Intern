export class LoginModel {
  email!: string;
  password!: string;

  constructor() {
    this.email = "";
    this.password="";
  }
}

export class CreateUserModel {
  id?: number;
  firstname!: string;
  lastname!: string;
  email!: string;
  roleId?: number;
  password!: string;
  confirmPassword?: string;

  constructor() {
    this.id = 0;
    this.firstname = "";
    this.lastname = "";
    this.email = "";
    this.roleId = 0;
    this.password = "";
    this.confirmPassword = "";
  }
}
