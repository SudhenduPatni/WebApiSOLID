import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../model/client';
import { Files } from '../model/Files';
import { Subscription } from '../model/subscription';
import { Util } from '../utils/util';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private httpClient: HttpClient) { }

	public addClient(client: Client) {
		return this.httpClient.post<Client>(Util.API_URL + Util.CLIENT_API, client)
			.pipe(response => response);
	}

  public getAllClients(): Observable<Response> {
    return this.httpClient.get<any>(Util.API_URL + Util.CLIENT_API)
    .pipe(response => response);
  }

  public getClientById(clientGlobalId?: string, cloudProviderId?: number): Observable<Client> {
    return this.httpClient.get<Client>(Util.API_URL + Util.CLIENT_API + clientGlobalId + '/' + cloudProviderId)
    .pipe(response => response);
  }

  public saveFile(file: Files) {
		return this.httpClient.post<Client>(Util.API_URL + Util.FILE_API, file)
			.pipe(response => response);
	}

  public getAllFiles(): Observable<Response> {
    return this.httpClient.get<any>(Util.API_URL + Util.FILES_API)
    .pipe(response => response);
  }

  public getAllFilesByClient(clientGlobalId?: string, cloudProviderId?: number): Observable<any> {
    return this.httpClient.get<any>(Util.API_URL + Util.FILES_API + clientGlobalId + '/' + cloudProviderId)
    .pipe(response => response);
  }

  public getFileById(fileGlobalId?: string, cloudProviderId?: number): Observable<any> {
    return this.httpClient.get<any>(Util.API_URL + Util.FILES_API + fileGlobalId + '/' + cloudProviderId)
    .pipe(response => response);
  }

	public addSubscription(subscription: Subscription) {
		return this.httpClient.post<Client>(Util.API_URL + Util.SUBSCRIPTION_API, subscription)
			.pipe(response => response);
	}

  public getAllSubscription(): Observable<Response> {
    return this.httpClient.get<any>(Util.API_URL + Util.SUBSCRIPTION_API)
    .pipe(response => response);
  }

  public getSubscriptionById(clientGlobalId?: string, cloudProviderId?: number): Observable<Subscription> {
    return this.httpClient.get<Subscription>(Util.API_URL + Util.SUBSCRIPTION_API + clientGlobalId + '/' + cloudProviderId)
    .pipe(response => response);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
  }
}
