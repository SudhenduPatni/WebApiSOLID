import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { ClientComponent } from './client.component';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { ClientRoutingModule } from './client-routing.module';
import { ClientFilesComponent } from './client-files/client-files.component';
import { ClientSubscriptionComponent } from './client-subscription/client-subscription.component';
import { ClientInfoComponent } from './client-info/client-info.component';


@NgModule({
    declarations: [
        ClientComponent,
        ClientDetailsComponent,
        ClientFilesComponent,
        ClientSubscriptionComponent,
        ClientInfoComponent,
    ],
    imports: [
        CommonModule,
        NgbModule,
        FormsModule,
        FontAwesomeModule,
        ClientRoutingModule
    ]
})
export class ClientModule { }