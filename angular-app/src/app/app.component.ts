import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'angular-app';
  isLoading: boolean=true;

  ngOnInit(): void {

    setTimeout(() => {
      this.isLoading =false;
    }, 3000);
    
      }
}
