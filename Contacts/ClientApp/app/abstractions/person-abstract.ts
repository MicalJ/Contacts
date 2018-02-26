import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Person } from "../models/person";


@Injectable()
export abstract class PersonAbstract {
    abstract getPersons(): Observable<Person[]>;

    abstract getPerson(contactId: number): Observable<Person>;

    abstract addPerson(personRequest: Person): Observable<Person>;

    abstract updatePerson(contactId: number, personRequest: Person): Observable<Person>;

    abstract deletePerson(contactId: number): Observable<Person>;

    abstract searching(search: string): Observable<Person[]>;

    abstract filtering(choice: string): Observable<Person[]>;

    abstract sorting(choice: string): Observable<Person[]>;
}