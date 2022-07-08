export class AddOrEditUserModel {
	id?: number;
	email!: string;
	firstname!: string;
	lastname!: string;
	roleId!: number;
	name?: string;
	password?: string;
}

export class UpdateProfileModel {
	email!: string;
	firstname!: string;
	lastname!: string;
	newPassword?: string;
	confirmPassword?: string;
}

export default class UserModel {
	id?: number;
	firstname!: string;
	lastname!: string;
	email!: string;
	roleId!: number;
	role?: string;
	password?: string;
}
