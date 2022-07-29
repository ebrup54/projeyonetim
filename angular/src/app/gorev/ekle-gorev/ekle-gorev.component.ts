import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevEkleDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-ekle-gorev',
  templateUrl: './ekle-gorev.component.html',
  styleUrls: ['./ekle-gorev.component.css']
})
export class EkleGorevComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  gorev: GorevEkleDto;

  constructor(
    injector: Injector,
    private _gorevServiceProxy: GorevServiceProxy,

    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
  save(){
    this.saving = true;
var input = new GorevEkleDto();
input.gorevTanimi = this.gorev.gorevTanimi;
input.durum = this.gorev.durum;

    // this._projeServiceProxy
    // .create(input).subscribe(
    //   () => {
    //     this.notify.info(this.l('SavedSuccessfully'));
    //     this.bsModalRef.hide();
    //     this.onSave.emit();
    //   },
    //   () => {
    //     this.saving = false;
    //   }
    // );
  }

}
