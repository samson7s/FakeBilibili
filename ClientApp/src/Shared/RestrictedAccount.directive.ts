import { AbstractControl, ValidatorFn, ValidationErrors, Validators } from '@angular/forms';
export function restrictedAccountValidator(control:AbstractControl): ValidationErrors|null {
    var validateEmail=/^[a-z_A-Z\d]+@/.test(control.value);
    var validateId=/^\d+$/.test(control.value);
    var validateUserName=/^[a-zA-Z]+[a-zA-Z\d]*$/.test(control.value);
    return validateEmail||validateId||validateUserName?null:{'RestrictedAccount':control.value};
  }