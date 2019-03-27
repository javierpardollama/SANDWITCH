import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Bandera } from '../../../../../viewmodels/core/bandera';

import { BanderaService } from '../../../../../services/bandera.service.module';

@Component({
  selector: 'app-bandera-update-modal',
  templateUrl: './bandera-update-modal.component.html',
  styleUrls: ['./bandera-update-modal.component.css']
})
export class BanderaUpdateModalComponent implements OnInit {

  constructor(private banderaService: BanderaService,
    public dialogRef: MatDialogRef<BanderaUpdateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Bandera) { }

  ngOnInit() {
  }

}
