import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MusteriDto, MusteriServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MusteriEkleComponent } from './musteri-ekle/musteri-ekle.component';

@Component({
  selector: 'app-musteri',
  templateUrl: './musteri.component.html',
  styleUrls: ['./musteri.component.css']
})
export class MusteriComponent extends AppComponentBase implements OnInit {

  musteriler: MusteriDto []= [];

  constructor(
    injector: Injector,
    private _musteriServiceProxy: MusteriServiceProxy,
    private _modalService: BsModalService
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this._musteriServiceProxy.getMusteriList()
    .subscribe((res) => {
      this.musteriler = res;
    })
  }
  private showEkleOrDüzenleMusteri(id?: number): void {
    let ekleOrdüzenleMusteri: BsModalRef;
    if (!id) {
      ekleOrdüzenleMusteri = this._modalService.show(
        MusteriEkleComponent,
        {
          class: 'modal-lg',
        }
      );
    // } else {
    //   createOrEditUserDialog = this._modalService.show(
    //     EditUserDialogComponent,
    //     {
    //       class: 'modal-lg',
    //       initialState: {
    //         id: id,
    //       },
    //     }
      // );
    }

    ekleOrdüzenleMusteri.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  refresh() {
    throw new Error('Method not implemented.');
  }

  createMusteri(): void {
    this.showEkleOrDüzenleMusteri();
  }

  // editUser(user: UserDto): void {
  //   this.showCreateOrEditUserDialog(user.id);
  // }

}
