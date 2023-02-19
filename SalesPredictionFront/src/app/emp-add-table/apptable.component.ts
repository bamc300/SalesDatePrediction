import { Component, OnInit,Inject, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpAddEditComponent } from '../emp-add-edit/emp-add-edit.component';
import { EmployeeService } from '../services/employee.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from '../core/core.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';



@Component({
  selector: 'app-root',
  templateUrl: './apptable.component.html',
  styleUrls: ['./app.component.scss'],
})
export class ApptableComponent implements OnInit {
  empForm: FormGroup;
  displayedColumns: string[] = [
      'orderid',
      'requireddate',
      'shippeddate',
      'shipname',
      'shipaddress',
      'shipcity',
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _fb: FormBuilder,
    private _dialogRef: MatDialogRef<EmpAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _dialog: MatDialog,
    private _empService: EmployeeService,
    private _coreService: CoreService
  ) {
    this.empForm = this._fb.group({
      custid: '',
    });
  }

  ngOnInit(): void {
    this.empForm.patchValue(this.data);
    this.getUserList();
  }




  getUserList() {
    console.log(this.data)
    this._empService.getUserList(this.data).subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res.response);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
