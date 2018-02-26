import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../service/person.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Person } from '../../../../models/person';

@Component({
    templateUrl: './crudperson.component.html'
})

export class CrudpersonComponent implements OnInit {
    constructor(private personService: PersonService,
        private activatedRoute: ActivatedRoute,
        private router: Router,
    private location: Location) { }

    pageTitle: string;
    urlParam: number;
    isInEditMode: boolean = true;
    person: Person = new Person();
    errors: string[];

    ngOnInit(): void {
        this.DetectUrlParam();

        this.errors = [];

        if (this.location.isCurrentPathEqualTo("/person-new")) {
            this.pageTitle = "New Person";
            
        }
        else if (this.location.isCurrentPathEqualTo("/person-update/" + this.urlParam)) {
            this.pageTitle = "Update Person";
            this.getPerson();
        }
        else {
            this.pageTitle = "Details Person";
            this.isInEditMode = false;
            this.getPerson();
        }
    }

    getPerson(): void {
        this.personService.getPerson(this.urlParam).subscribe(person => {
            this.person = person;
        },
            error => { console.log(error); }
        )
    }

    onSubmit(personObj: Person): void {
        if (this.location.isCurrentPathEqualTo("/person-new")) {
            personObj.categoryPersonId = 1;
            this.personService.addPerson(personObj)
                .subscribe(onSuccess => { console.log(onSuccess); this.backToContacts(); },
                err => {
                    if (err.status === 400) {
                        // handle validation error
                        this.errors = [];
                        let validationErrorDictionary = JSON.parse(err.text());
                        for (var fieldName in validationErrorDictionary) {
                            if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                                this.errors.push(validationErrorDictionary[fieldName]);
                            }
                        }
                    } else {
                        this.errors.push("something went wrong!");
                    }; console.log(err) });
            
        }
        else {
            this.personService.updatePerson(this.urlParam, personObj)
                .subscribe(success => { console.log(success); this.backToContacts(); },
                error => { this.errors = error; })
        }
    }

    DetectUrlParam(): void {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.urlParam = params['id'];
        })
    }

    backToContacts(): void {
        this.router.navigate(['/persons']);
    }

    goBack(): void {
        this.location.back();
    }
}