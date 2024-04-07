import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { Person } from "../models/person";

@Injectable({
    providedIn: 'root'
})
export class ContactsService {
    constructor(private http: HttpClient) { }
    readonly baseUrl = 'https://localhost:7215/api/Account'

    getAllPersons(): Observable<any> {
        return this.http.get(this.baseUrl);
    }

    addPerson(body: Person): Observable<any> {
        const idToken = localStorage.getItem("id_token");
        const headers = new HttpHeaders().set('Authorization', `Bearer ${idToken}`)

        if (!!idToken)
            return this.http.post(this.baseUrl, body, { headers })
        else
            return of("Not logged in")
    }

    editPerson(body: Person): Observable<any> {
        const idToken = localStorage.getItem("id_token");
        const headers = new HttpHeaders().set('Authorization', `Bearer ${idToken}`)

        if (!!idToken)
            return this.http.put(this.baseUrl, body, { headers })
        else
            return of("Not logged in")
    }

    removePerson(body: Person): Observable<any> {
        const idToken = localStorage.getItem("id_token");
        const headers = new HttpHeaders().set('Authorization', `Bearer ${idToken}`).set('Content-Type', 'application/json')
        const options = {
            headers: headers,
            body: body
        }

        if (!!idToken)
            return this.http.delete(this.baseUrl, options)
        else
            return of("Not logged in")
    }
}