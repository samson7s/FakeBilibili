import { AbstractControl, ValidatorFn, ValidationErrors, Validators } from '@angular/forms';
export function RestrictedAccountValidator(control:AbstractControl): ValidationErrors|null {
    var required=Validators.required(control);
    if(required){
      return required;
    }

    var validateEmail=Validators.email(control);
    var validateId=/\d+/.test(control.value);
    var validateUserName=/\w+[\d\w]*/.test(control.value);
    return validateEmail||validateId||validateUserName?{'RestrictedAccount':control.value}:null;
  }