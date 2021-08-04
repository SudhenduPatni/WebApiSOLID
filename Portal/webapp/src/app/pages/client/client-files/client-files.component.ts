import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Files } from 'src/app/shared/model/Files';
import { ClientService } from 'src/app/shared/service/client.service';
import { faFileDownload } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-client-files',
  templateUrl: './client-files.component.html',
  styleUrls: ['./client-files.component.scss']
})
export class ClientFilesComponent implements OnInit {

  files: Files[] | undefined;
  faFileDownload = faFileDownload;

  constructor(private router: Router, private clientService: ClientService) { }

  ngOnInit(): void {
    this.getFiles();
  }

  public onChange(event: any) {
    this.clientService.saveFile(event.files)
      .subscribe((response: any) => {
      }, error => {
      }, () => {
      });
  }
  
  public getFiles() {
    this.clientService.getAllFilesByClient('', 1)
      .subscribe((response: any) => {
        this.files = response;
      }, error => {
      }, () => {
      });
  }

  public getFile(file: Files): void {
    this.clientService.getFileById(file.fileGlobalId, 1)
      .subscribe((response: any) => {
      }, error => {
      }, () => {
      });
  }
}
