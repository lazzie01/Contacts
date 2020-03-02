import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { ContactsService } from '../services/contacts.service';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {

  constructor(private _activatedRoute:ActivatedRoute,private _contactsService:ContactsService,private _fb: FormBuilder) { }
  id:number;
  contact:any;
  editForm: FormGroup;
  ngOnInit(): void {
    this.id = parseInt(this._activatedRoute.snapshot.paramMap.get('id'));
    this._contactsService.get(this.id)
    .subscribe(
      data=>{
        this.editForm = this._fb.group({
          firstName: [data.FirstName, Validators.required],
          lastName: [data.LastName,Validators.required],
          emails: this._fb.array([]),
          phones: this._fb.array([])
         });
         (data.Emails as any[]).map(e=>this.emails.push(this._fb.control(e.Address,Validators.email)));
         (data.PhoneNumbers as any[]).map(p=>this.phones.push(this._fb.control(p.Number,Validators.pattern(/^\d+$/))));
      },
      error =>console.log('Error!',error)                                 
      );
                                      
  }

  get emails(){
    return this.editForm.get('emails') as FormArray;
  }

  addEmails(){
    this.emails.push(this._fb.control('',Validators.email));
  }

  get phones(){
    return this.editForm.get('phones') as FormArray;
  }

  addPhones(){
    this.phones.push(this._fb.control('',Validators.pattern(/^\d+$/)));
  }

  editContact(): void{
    this.contact={
       FirstName : this.editForm.get('firstName').value,
       LastName : this.editForm.get('lastName').value,
       Emails :(this.editForm.get('emails').value as any[])
                                .map(function(e){return {Address:e}}),
       PhoneNumbers: (this.editForm.get('phones').value as any[])
                                      .map(function(p){return {Number:p}})
    }
    // this.contact.Emails.push({Address:this.createForm.get('email').value});
    // this.contact.PhoneNumbers.push({Number:this.createForm.get('phone').value});
    this._contactsService.edit(this.id,this.contact)
                         .subscribe(
                                response =>console.log('Success!',response),
                                error =>console.log('Error!',error)
                                );
    window.location.href='/list';                        
  }

}
