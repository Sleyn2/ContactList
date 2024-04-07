import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { UserService } from "../../shared/services/users.service";
import { CommonModule, NgIf } from "@angular/common";

export class LoginData {
    email: string = "";
    password: string = "";
}

@Component({
    selector: 'login-dialog',
    templateUrl: 'login-dialog.component.html',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatButtonModule,
        MatDialogTitle,
        MatDialogContent,
        MatDialogActions,
        MatDialogClose,
        NgIf,
        CommonModule
    ],
})
export class LoginDialog {

    public loginData: LoginData = new LoginData()
    public errorFlag: boolean = false

    constructor(
        public dialogRef: MatDialogRef<LoginDialog>,
        private _userService: UserService
    ) { }

    cancel(): void {
        this.dialogRef.close()
    }

    login(): void {
        this.errorFlag = false
        this._userService.login(this.loginData).subscribe(
            res => {
                this._userService.setSession(res)
                this.dialogRef.close()
            },
            err => this.errorFlag = true,
            () => console.log('HTTP request completed.'));
    }
}