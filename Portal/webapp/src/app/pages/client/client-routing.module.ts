import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Client } from 'src/app/shared/model/client';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { ClientFilesComponent } from './client-files/client-files.component';
import { ClientInfoComponent } from './client-info/client-info.component';
import { ClientSubscriptionComponent } from './client-subscription/client-subscription.component';
import { ClientComponent } from './client.component';

const routes: Routes = [
  { path: '', component: ClientComponent },
  { path: 'clients', component: Client },
  { path: 'client-details', component: ClientDetailsComponent },
  { path: 'client-info', component: ClientInfoComponent },
  { path: 'client-subscription', component: ClientSubscriptionComponent },
  { path: 'client-files', component: ClientFilesComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }