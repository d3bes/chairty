import { Component, OnInit } from '@angular/core';
import { Observable, Subscribable } from 'rxjs';
import { LoadingService } from '../services/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {

  isLoading: boolean;
constructor(public loader:LoadingService) {
  this.isLoading = true;
}
  ngOnInit(): void {

setTimeout(() => {
  this.isLoading =false;
}, 3000);

  }





}
