import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { PersonService } from './components/person/service/person.service';
import { PersonAbstract } from './abstractions/person-abstract';
import { HttpPersonService } from './services/http-person.service';
import { PersonsComponent } from './components/person/components/allpersons/persons.component';
import { CrudpersonComponent } from './components/person/components/crudperson/crudperson.component';
import { LoginComponent } from './components/login/login.component';

import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';


//import { InputGroupDemo } from './inputgroupdemo';
//import { InputGroupDemoRoutingModule } from 'primeng/';
//import { TabViewModule } from 'primeng/tabview';
//import { CodeHighlighterModule } from 'primeng/codehighlighter';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        PersonsComponent,
        CrudpersonComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        NgbModule,
        BrowserModule,
        BrowserAnimationsModule,
        ProgressSpinnerModule,
        ButtonModule,
        InputTextModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'persons', pathMatch: 'full' },
            { path: 'persons', component: PersonsComponent },
            { path: 'person-new', component: CrudpersonComponent },
            { path: 'person-details/:id', component: CrudpersonComponent },
            { path: 'person-update/:id', component: CrudpersonComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'persons' }
        ])
    ],
    providers: [
        NgbPaginationConfig,
        PersonService,
        { provide: PersonAbstract, useClass: HttpPersonService}
    ]
})
export class AppModuleShared {
}
