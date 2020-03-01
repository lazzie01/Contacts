import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../services/contacts.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './list-contacts.component.html',
  styleUrls: ['./list-contacts.component.css']
})
export class ListContactsComponent implements OnInit {
  contacts:any[];
  statusMessage:string = "Loading please wait...";
  searchTerm:string;
  constructor(private _contactsService:ContactsService,private _router:Router) { }

  ngOnInit(): void {
    this._contactsService.list()
         .subscribe(c =>this.contacts = c,
                  error=>{
                    console.error(error);
                  });
  }
  editContact(id:number):void{
   this._router.navigate(['/edit',id]);  
  }

  deleteContact(id:number):void{
    this._contactsService.delete(id)
        .subscribe(
         response =>console.log('Success!',response),
         error =>console.log('Error!',error)
      );   
     window.location.reload();
   }

}
