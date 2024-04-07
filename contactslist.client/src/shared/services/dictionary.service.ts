import { Observable, of } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Subcategory } from "../models/subcategory";

@Injectable({
    providedIn: 'root'
})
export class DictionaryService {
    constructor(private http: HttpClient) { }
    readonly baseUrl = 'https://localhost:7215/api/Dictionary'

    getCategoryDict() : Observable<any> {
        return this.http.get(this.baseUrl + '/Categories');
    }

    getSubcategoryDict() : Observable<any> {
        return this.http.get(this.baseUrl + '/Subcategories');
    }

    addSubcategory(body: Subcategory) : Observable<any> {
        const idToken = localStorage.getItem("id_token");
        const headers = new HttpHeaders().set('Authorization', `Bearer ${idToken}`)
        if (!!idToken)
            return this.http.post(this.baseUrl, body, {headers})
        else
            return of("Not logged in")
    }
}