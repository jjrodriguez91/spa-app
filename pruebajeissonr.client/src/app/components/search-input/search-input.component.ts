import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  standalone: false,
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrl: './search-input.component.css'
})
export class SearchInputComponent {
  @Input() searchControl = new FormControl('');
  @Input() placeholder: string = "";
  @Input() useAppFlatIconBackground: boolean = false;
  @Output() searchQuery = new EventEmitter<string>();

  constructor() {
    this.searchControl.valueChanges.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    ).subscribe(query => {
      this.searchQuery.emit(query ?? '');
    });
  }
}
