import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";

export const StrongPasswordRegx: RegExp =
    /^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\D*\d).{8,}$/;

@Injectable({
    providedIn: 'root'
})
export class UserService {
    readonly baseUrl = 'https://localhost:7215/api/Account'
    constructor(private fb: FormBuilder, private http: HttpClient) { }

    formModel = this.fb.group({
        UserName: ['', Validators.required],
        Email: ['', Validators.email],
        FullName: [''],
        Password: ['', [Validators.required, Validators.pattern(StrongPasswordRegx)]],
    });

    login(formData: any) {
        return this.http.post(this.baseUrl + '/Login', formData);
    }

    setSession(authResult: any) {
        localStorage.setItem('id_token', authResult.token);
    }  

    logout() {
        localStorage.removeItem("id_token");
    }
}