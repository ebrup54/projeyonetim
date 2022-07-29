import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { GorevDto, GorevServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EkleGorevComponent } from './ekle-gorev/ekle-gorev.component';

@Component({
  selector: 'app-gorev',
  templateUrl: './gorev.component.html',
  styleUrls: ['./gorev.component.css']
})
export class GorevComponent extends AppComponentBase implements OnInit {

  gorevler: GorevDto []= [];

  constructor(
    injector: Injector,
    private _gorevServiceProxy: GorevServiceProxy,
    private _modalService: BsModalService
    ) {
    super(injector)
   }

  ngOnInit(): void {
    this._gorevServiceProxy.getGorevList()
    .subscribe((res) => {
      this.gorevler = res;
    })
  }
  private showEkleOrDüzenleGorev(id?: number): void {
    let ekleOrdüzenleGorev: BsModalRef;
    if (!id) {
      ekleOrdüzenleGorev = this._modalService.show(
        EkleGorevComponent,
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

    ekleOrdüzenleGorev.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  refresh() {
    throw new Error('Method not implemented.');
  }


  createGorev(): void {
    this.showEkleOrDüzenleGorev();
  }

  // editUser(user: UserDto): void {
  //   this.showCreateOrEditUserDialog(user.id);
  // }
}


