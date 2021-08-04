import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-client-subscription',
  templateUrl: './client-subscription.component.html',
  styleUrls: ['./client-subscription.component.scss']
})
export class ClientSubscriptionComponent implements OnInit {
  fromModel?: NgbDateStruct;
  toModel?: NgbDateStruct;
  
  constructor() { }

  ngOnInit(): void {
  }

  saveSubscription() {
    
  }
}
