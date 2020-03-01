import { Component, OnInit } from '@angular/core';
import { ContactsService} from './services/contacts.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ContactsService]
})
export class AppComponent implements OnInit{
  contacts:any[];
  statusMessage ="Loading data please wait";
  title = 'AngularApp'; 
  constructor(private _contactsService:ContactsService){
   
  }

  ngOnInit(): void {
    
   }

  }

