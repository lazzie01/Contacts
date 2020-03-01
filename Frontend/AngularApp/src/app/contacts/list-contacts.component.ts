import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactsService } from '../services/contacts.service';

@Component({
  templateUrl: './list-contacts.component.html',
  styleUrls: ['./list-contacts.component.css']
})
export class ListContactsComponent implements OnInit {
  contacts:any[];
  statusMessage:string = "Loading please wait...";
  constructor(private _contactsService:ContactsService) { }

  ngOnInit(): void {
    this._contactsService.list()
         .subscribe(c =>this.contacts = c,
                  error=>{
                    console.error(error);
                  });
  }

}
