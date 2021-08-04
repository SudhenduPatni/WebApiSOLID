import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Client } from 'src/app/shared/model/client';
import { ClientService } from 'src/app/shared/service/client.service';
import { faUserCog } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  clients: Client[] | undefined;
  faUserCog = faUserCog;
  closeResult = '';

  constructor(private router: Router, private modalService: NgbModal, private clientService: ClientService) { }

  ngOnInit(): void {
    this.getClients();
  }

  public getClients() {
    this.clientService.getAllClients()
      .subscribe((response: any) => {
        this.clients = response;
      }, error => {
      }, () => {
      });
  }

  public getClientDetails(client: Client) {
    this.router.navigate(['client-details', { 'clientGlobalId': client.clientGlobalId, 'cloudProviderId': client.cloudProviderId }]);
  }

  open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
