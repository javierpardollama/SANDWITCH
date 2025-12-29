import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Router, RouterModule } from '@angular/router';


@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrl: './unauthorized.component.scss',
  imports: [
    MatTooltipModule,
    MatButtonModule,
    RouterModule
  ]
})
export class UnauthorizedComponent {
  // DI
  private router = inject(Router);

  // Constructor
  constructor() { }

  public Back(): void {
    this.router.navigate([""]);
  }
}
