import { Injectable } from '@angular/core';
import { PersonAbstract } from '../abstractions/person-abstract';
import { Observable } from 'rxjs/Observable';
import { Person } from '../models/person';
import { RequestOptions, Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpPersonService extends PersonAbstract {
    private getPersonsUrl: string = "api/contact/getall";
    private getPersonUrl: string = "api/contact/getbyid/";
    private addPersonUrl: string = "api/contact/postcontact";
    private updatePersonUrl: string = "api/contact/putcontact/";
    private deletePersonUrl: string = "api/contact/deletecontact/";
    private searchingPersonUrl: string = "api/contact/search/";
    private filteringPersonsUrl: string = "api/contact/filtercategory/";
    private sortingPersonsUrl: string = "api/contact/sort/";

    private jsonContentOptions: RequestOptions;
    constructor(private http: Http) {
        super();
        let headersJson: Headers = new Headers({
            "Content-Type": "application/json"
        });
        this.jsonContentOptions = new RequestOptions({ headers: headersJson });
    }

    getPersons(): Observable<Person[]> {
        return this.http.get(this.getPersonsUrl, this.jsonContentOptions)
            .map(response => response.json());
    }
    getPerson(contactId: number): Observable<Person> {
        return this.http.get(this.getPersonUrl + contactId, this.jsonContentOptions)
            .map(response => response.json());
    }
    addPerson(personRequest: Person): Observable<Person> {
        return this.http.post(this.addPersonUrl, JSON.stringify(personRequest), this.jsonContentOptions)
            .map(response => response.json() as Person);
    }
    updatePerson(contactId: number, personRequest: Person): Observable<Person> {
        return this.http.put(this.updatePersonUrl + contactId, JSON.stringify(personRequest), this.jsonContentOptions)
            .map(response => response.json() as Person);
    }
    deletePerson(contactId: number): Observable<Person> {
        return this.http.delete(this.deletePersonUrl + contactId, this.jsonContentOptions)
            .map(response => response.json());
    }

    searching(search: string): Observable<Person[]> {
        return this.http.patch(this.searchingPersonUrl + search, JSON.stringify(search), this.jsonContentOptions).
            map(response => response.json());
    }

    filtering(choice: string): Observable<Person[]> {
        return this.http.get(this.filteringPersonsUrl + choice, this.jsonContentOptions)
            .map(response => response.json());
    }

    sorting(choice: string): Observable<Person[]> {
        return this.http.get(this.sortingPersonsUrl + choice, this.jsonContentOptions)
            .map(response => response.json());
    }
}