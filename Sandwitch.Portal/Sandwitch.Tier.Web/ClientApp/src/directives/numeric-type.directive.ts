import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { ExpressionAppVariants } from './../variants/expression.app.variants';

@Directive({
  selector: 'input[app-numeric-type]'
})
export class NumericTypeDirective {

  @Input('app-numeric-type') numericType: string; // number | decimal

  private regex = {
    number: new RegExp(ExpressionAppVariants.AppNumberExpression),
    decimal: new RegExp(ExpressionAppVariants.AppInfiniteDecimalExpression)
  };

  private specialKeys = {
    number: ['Backspace', 'Tab', 'End', 'Home', 'ArrowLeft', 'ArrowRight'],
    decimal: ['Backspace', 'Tab', 'End', 'Home', 'ArrowLeft', 'ArrowRight'],
  };

  constructor(private elementRef: ElementRef) {
  }

  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent) {

    if (this.specialKeys[this.numericType].indexOf(event.key) !== -1) {
      return;
    }

    // Do not use event.keycode this is deprecated.
    // See: https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
    let current: string = this.elementRef.nativeElement.value;

    let next: string = current.concat(event.key);

    if (next && !String(next).match(this.regex[this.numericType])) {
      event.preventDefault();
    }
  }
}
