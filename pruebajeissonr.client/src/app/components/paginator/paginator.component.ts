import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrl: './paginator.component.css'
})
export class PaginatorComponent {
  @Input() currentPage = 1;
  @Input() totalPages = 10;
  @Input() totalRecords = 1;
  @Input() pageSize = 1;
  @Output() pageChange = new EventEmitter<number>();

  onPageChange(newPage: number) {
    this.pageChange.emit(newPage);
  }
}
