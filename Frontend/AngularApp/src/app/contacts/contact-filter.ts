import { PipeTransform, Pipe } from '@angular/core';
@Pipe({
    name: 'contactFilter'
})
export class ContactFilterPipe implements PipeTransform{

    transform(contacts:any[], searchTerm:string): any[]{
        if(!contacts || !searchTerm){
            return contacts;
        }
       return contacts.filter(contact=>
        contact.FirstName.toLowerCase()
                          .indexOf(searchTerm.toLowerCase())!== -1)
    }
}