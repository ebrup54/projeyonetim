import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-proje',
  templateUrl: './proje.component.html',
  styleUrls: ['./proje.component.css']
})
export class ProjeComponent extends AppComponentBase implements OnInit {

  projeler: ProjeDto []= [];

  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this._projeServiceProxy.getProjeList()
    .subscribe((res) => {
      this.projeler = res;
    })
  }

}
