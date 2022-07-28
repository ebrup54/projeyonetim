import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDto, MusteriServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-musteri',
  templateUrl: './musteri.component.html',
  styleUrls: ['./musteri.component.css']
})
export class MusteriComponent extends AppComponentBase implements OnInit {

  musteriler: MusteriDto []= [];

  constructor(
    injector: Injector,
    private _musteriServiceProxy: MusteriServiceProxy
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this._musteriServiceProxy.getMusteriList()
    .subscribe((res) => {
      this.musteriler = res;
    })
  }

}
