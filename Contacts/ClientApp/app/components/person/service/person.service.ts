import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Person } from '../../../models/person';
import { PersonAbstract } from '../../../abstractions/person-abstract';

@Injectable()
export class PersonService {
    constructor(private personService: PersonAbstract) { }

    getPersons(): Observable<Person[]> {
        return this.personService.getPersons();
    }

    getPerson(contactId: number): Observable<Person> {
        return this.personService.getPerson(contactId);
    }

    addPerson(personRequest: Person): Observable<Person> {
        return this.personService.addPerson(personRequest);
    }

    updatePerson(contactId: number, personRequest: Person): Observable<Person> {
        return this.personService.updatePerson(contactId, personRequest);
    }

    deletePerson(contactId: number): Observable<Person> {
        return this.personService.deletePerson(contactId);
    }

    searchPersons(search: string): Observable<Person[]> {
        return this.personService.searching(search);
    }

    filterPersons(choice: string): Observable<Person[]> {
        return this.personService.filtering(choice);
    }

    sortingPersons(choice: string): Observable<Person[]> {
        return this.personService.sorting(choice);
    }
}