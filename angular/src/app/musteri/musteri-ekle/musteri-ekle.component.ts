import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriEkleDto, MusteriServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-musteri-ekle',
  templateUrl: './musteri-ekle.component.html',
  styleUrls: ['./musteri-ekle.component.css']
})
export class MusteriEkleComponent extends AppComponentBase implements OnInit {
  @Output() onSave = new EventEmitter<any>();
  saving = false;
  musteri: MusteriEkleDto;

  constructor(
    injector: Injector,
    private _musteriServiceProxy: MusteriServiceProxy,

    public bsModalRef: BsModalRef
  ) {
    super(injector)
  }

  ngOnInit(): void {
  }
  
  save(){
    this.saving = true;
var input = new MusteriEkleDto();
input.musteriAdi = this.musteri.musteriAdi;
input.aciklama = this.musteri.aciklama;

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
