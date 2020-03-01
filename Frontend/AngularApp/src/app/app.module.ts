import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListContactsComponent } from './contacts/list-contacts.component';
import { CreateContactComponent } from './contacts/create-contact.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ContactsService } from './services/contacts.service';

const appRoutes: Routes =[
  { path:'list', component:ListContactsComponent },
  { path:'create', component:CreateContactComponent },
  { path:'', redirectTo:'/list', pathMatch:'full' }
]
@NgModule({
  declarations: [
    AppComponent,
    ListContactsComponent,
    CreateContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)   
  ],
  providers: [FormBuilder,ContactsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
