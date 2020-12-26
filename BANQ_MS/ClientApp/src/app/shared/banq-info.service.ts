import { Injectable } from '@angular/core';
import { BanqInfo } from './banq-info.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BanqInfoService {
  list: BanqInfo[];

  constructor(private http: HttpClient) { }

  getBanqList() {
    this.http.get(environment.baseUrl + '/Banq')
      .toPromise()
      .then(result => this.list = result as BanqInfo[]);
  }
}
