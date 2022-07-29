import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeEkleDto, ProjeServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-proje-ekle',
  templateUrl: './proje-ekle.component.html',
  styleUrls: ['./proje-ekle.component.css']
})
export class ProjeEkleComponent extends AppComponentBase implements OnInit {

  @Output() onSave = new EventEmitter<any>();
  saving = false;
  proje: ProjeEkleDto;

  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy,

    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
  save(){
    this.saving = true;
var input = new ProjeEkleDto();
input.projeAdi = this.proje.projeAdi;
input.description = this.proje.description;

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
