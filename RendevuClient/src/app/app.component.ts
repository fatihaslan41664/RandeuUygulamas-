import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientService } from './services/http-services.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  constructor(private httpClientServce : HttpClientService){
  }
  ngOnInit(): void {
    const u = this.httpClientServce.get({
      controller:'User',
    })
    u.subscribe(o=>console.log(o))
  }
  
}
