import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        NgbModule.forRoot(),
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
