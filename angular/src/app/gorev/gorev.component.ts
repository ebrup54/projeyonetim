import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-gorev',
  templateUrl: './gorev.component.html',
  styleUrls: ['./gorev.component.css']
})
export class GorevComponent extends AppComponentBase implements OnInit {

  gorevler: GorevDto []= [];

  constructor(
    injector: Injector,
    private _gorevServiceProxy: GorevServiceProxy
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this._gorevServiceProxy.getGorevList()
    .subscribe((res) => {
      this.gorevler = res;
    })
  }

}
