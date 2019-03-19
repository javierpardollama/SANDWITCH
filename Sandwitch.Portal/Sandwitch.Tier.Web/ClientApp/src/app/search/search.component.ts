import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { Poblacion } from '../../viewmodels/core/poblacion';
import { Arenal } from '../../viewmodels/core/arenal';
import { PoblacionService } from '../../services/poblacion.service.module';
import { ArenalService } from '../../services/arenal.service.module';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public poblaciones: Poblacion[];
  public filteredPoblaciones: Observable<Poblacion[]>;
  public arenales: Arenal[];

  public poblacionCtrl = new FormControl();

  constructor(private poblacionService: PoblacionService,
    private arenalService: ArenalService) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllPoblacion();
  }

  // Get Data from Service
  public FindAllArenalByPoblacionId(id: number) {
    this.arenalService.FindAllArenalByPoblacionId(id).subscribe(arenales => {
      this.arenales = arenales;      
    });
  }

  // Get Data from Service
  public FindAllPoblacion() {
    this.poblacionService.FindAllPoblacion().subscribe(poblaciones => {
      this.poblaciones = poblaciones;

      this.filteredPoblaciones = this.poblacionCtrl.valueChanges
        .pipe(
          startWith(''),
          map(poblacion => poblacion ? this.filterPoblaciones(poblacion) : this.poblaciones.slice())
        );
    });

  }

  // Filter Data
  public filterPoblaciones(value: string): Poblacion[] {
    const filterValue = value.toLowerCase();

    return this.poblaciones.filter(poblacion => poblacion.Name.toLowerCase().indexOf(filterValue) === 0);
  }

}
