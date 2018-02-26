import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';
import { PersonService } from '../../service/person.service';
import { Person } from '../../../../models/person';
import 'rxjs/add/operator/retry';

@Component({
    selector: 'persons',
    templateUrl: './persons.component.html'
})

export class PersonsComponent implements OnInit {
    persons: Array<Person> = new Array<Person>();
    fromsearch: string;
    pageTitle = "Contacts";
    sortDirectionFirstName = 'desc';
    sortDirectionLastName = 'desc';

    constructor(private personService: PersonService,
        private router: Router,
        private config: NgbPaginationConfig) { }

    ngOnInit(): void {
        this.getPersons();
    }

    sort(choice: string): void {
        if (choice=='firstName') {
            this.sortDirectionFirstName = this.sortDirectionFirstName === 'asc' ? 'desc' : 'asc';
        }
        else {
            this.sortDirectionLastName = this.sortDirectionLastName === 'asc' ? 'desc' : 'asc';
        }
            this.personService.sortingPersons(choice)
                .subscribe(results => { this.persons = results }, error => { console.log(error) });
    }

    reset(): void {
        this.getPersons();
    }

    search(search: string): void {
        search = this.fromsearch;
        this.personService.searchPersons(search).subscribe(
            results => { this.persons = results }, error => console.log(error));
    }

    filter(choice: string): void {
        this.personService.filterPersons(choice)
            .subscribe(results => this.persons = results, error => console.log(error));
    }

    getPersons(): void {
        this.personService.getPersons().retry(3)
            .subscribe(result => {this.persons = result}, err => { console.log(err) })
    }

    getPerson(contactId: number): void {
        this.router.navigate(['./person-details', contactId]);
    }

    addPerson(): void {
        this.router.navigate(['./person-new']);
    }

    updatePerson(contactId: number): void {
        this.router.navigate(['./person-update', contactId]);
    }

    deletePerson(contactId: number): void {
        this.personService.deletePerson(contactId).
            subscribe(result => { console.log(result); this.persons.splice(this.persons.findIndex(i => i.personId == contactId), 1);
    }, error => console.log(error));
    
    }
}