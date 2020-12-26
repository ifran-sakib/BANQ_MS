import { Injectable } from '@angular/core';
import { EventManager } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventmanagerService {
  list: EventManager[];

  constructor(private http: HttpClient) {
  }

  getEvenetManagerList() {
    this.http.get(environment.baseUrl + '/BanqEvntMngr')
      .toPromise()
      .then(result => this.list = result as EventManager[]);
  }
}
