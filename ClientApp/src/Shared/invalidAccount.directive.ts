import { AbstractControl, ValidatorFn, ValidationErrors, Validators } from '@angular/forms';
export function invalidAccountValidator(control: AbstractControl): ValidationErrors | null {
  var validateEmail = /^[a-z_A-Z\d]+@/.test(control.value);
  var validateId = /^\d+$/.test(control.value);
  var validateUserName = /^[a-zA-Z]+[a-zA-Z\d]*$/.test(control.value);
  return validateEmail || validateId || validateUserName ? null : { 'invalidAccount': { message: "请输入正确的账号" } };
}

// export function invalidAccountValidator(): ValidatorFn {
//   return (control: AbstractControl): { [key: string]: any } | null => {
//     var validateEmail = /^[a-z_A-Z\d]+@/.test(control.value);
//     var validateId = /^\d+$/.test(control.value);
//     var validateUserName = /^[a-zA-Z]+[a-zA-Z\d]*$/.test(control.value);
//     return validateEmail || validateId || validateUserName ?  null:{ 'invalidAccount': { message: "请输入正确的账号" } } ;
//   }
// }

export function forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    const forbidden = nameRe.test(control.value);
    return forbidden ? {'forbiddenName': {value: control.value}} : null;
  };
}