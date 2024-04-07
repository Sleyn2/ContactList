import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { LoginDialog } from "../login-dialog/login-dialog.component";
import { UserService } from "../../shared/services/users.service";

@Component({
    selector: 'nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrl: './nav-menu.component.css'
})
export class NavMenuComponent implements OnInit {

    public get signedIn() {
        return !!localStorage.getItem("id_token");
    }

    constructor(
        public dialog: MatDialog,
        public auth: UserService,
        private _userService: UserService
    ) { }

    ngOnInit(): void {
        localStorage.removeItem('id_token')
    }

    openDialog(): void {
        const dialogRef = this.dialog.open(LoginDialog);

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
        });
    }

    logout(): void {
        this._userService.logout();
    }
}