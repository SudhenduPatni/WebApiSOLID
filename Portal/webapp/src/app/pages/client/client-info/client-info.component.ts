import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Client } from 'src/app/shared/model/client';
import { ClientService } from 'src/app/shared/service/client.service';
import { CloudProvider } from 'src/app/shared/utils/util';

@Component({
  selector: 'app-client-info',
  templateUrl: './client-info.component.html',
  styleUrls: ['./client-info.component.scss']
})
export class ClientInfoComponent implements OnInit {
  clientName: string = '';
  cloudProvider: string = 'Cloud Provider';
  selectedCloudProvider: number | undefined;
  cloudProviderEnum: typeof CloudProvider = CloudProvider;

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
  }

  addClient() {
    let client = new Client();
    client.name = this.clientName;
    client.cloudProviderId = this.selectedCloudProvider;
    
    this.clientService.addClient(client)
      .subscribe((response: any) => {
        
      }, error => {
      }, () => {
      });
  }

  cloudProviderChange(cloudProvider: any) {
    this.selectedCloudProvider = cloudProvider;
    this.cloudProvider = CloudProvider[cloudProvider].toString();
  }
}
