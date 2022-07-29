import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  createProje:NgForm;
  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy,    
    public bsModalRef: BsModalRef,
    
  ) {
    super(injector);
  }

  ngOnInit(){ 
  }
  save(){
    
    this.saving = true;
    var input = new ProjeEkleDto();
    var inputAd = document.getElementById('projeAdi') as HTMLInputElement;
    var inputDesc = document.getElementById('description') as HTMLInputElement;
    var inputId = document.getElementById('musteriId') as HTMLInputElement;

    // var input.musteriAdi= <HTMLInputElement>document.getElementById('type').value
    input.projeAdi = inputAd.value;
    input.description = inputDesc.value;
    input.musteriId=parseInt(inputId.value);
    //console.log(input);

    this._projeServiceProxy
    .projeEkle(input).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
