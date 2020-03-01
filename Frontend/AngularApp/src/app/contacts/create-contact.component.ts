import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {FormBuilder, Validators, FormGroup, FormArray } from '@angular/forms';
import { Contact } from '../models/contact.model';
import { ContactsService } from '../services/contacts.service';
@Component({
  selector: 'app-create-contact',
  templateUrl: './create-contact.component.html',
  styleUrls: ['./create-contact.component.css']
})
export class CreateContactComponent implements OnInit {

  constructor(private _fb: FormBuilder,private _contactsService:ContactsService) { }
  createForm: FormGroup;
  ngOnInit(): void {

    this.createForm = this._fb.group({
     firstName: ['', Validators.required],
     lastName: ['',Validators.required],
     email: ['',Validators.email],
     phone: ['',Validators.pattern(/^\d+$/)],
     alternateEmails: this._fb.array([]),
     alternatePhones: this._fb.array([])
    });
  }

  get alternateEmails(){
    return this.createForm.get('alternateEmails') as FormArray;
  }

  addAlternateEmails(){
    this.alternateEmails.push(this._fb.control('',Validators.email));
  }

  get alternatePhones(){
    return this.createForm.get('alternatePhones') as FormArray;
  }

  addAlternatePhones(){
    this.alternatePhones.push(this._fb.control('',Validators.pattern(/^\d+$/)));
  }
  contact:any;
  saveContact(): void{
    this.contact={
       firstName : this.createForm.get('firstName').value,
       lastName : this.createForm.get('lastName').value,
       emails :this.createForm.get('alternateEmails').value,
       phoneNumbers: this.createForm.get('alternatePhones').value
    }
    this.contact.emails.push(this.createForm.get('email').value);
    this.contact.phoneNumbers.push(this.createForm.get('phone').value);
    this._contactsService.create(this.contact)
                        .subscribe(
                                response =>console.log('Success!',response),
                                error =>console.log('Error!',error)
                                );
    
  }
}
