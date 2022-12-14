import { Component, InjectDecorator, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ProjeDto, ProjeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { pipe } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ProjeEkleComponent } from './proje-ekle/proje-ekle.component';

@Component({
  selector: 'app-proje',
  templateUrl: './proje.component.html',
  styleUrls: ['./proje.component.css']
})
export class ProjeComponent extends AppComponentBase implements OnInit {
    ;

  projeler: ProjeDto[] = [];

  constructor(
    injector: Injector,
    private _projeServiceProxy: ProjeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector)
  }

  ngOnInit(): void {
    this._projeServiceProxy.getProjeList()
      .subscribe((res) => {
        this.projeler = res;
      })
  }

  private showEkleOrDüzenleProje(id?: number): void {
    let ekleOrdüzenleProje: BsModalRef;
    if (!id) {
      ekleOrdüzenleProje = this._modalService.show(
        ProjeEkleComponent,
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

    ekleOrdüzenleProje.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  refresh() {
    throw new Error('Method not implemented.');
  }

  delete(proje: ProjeDto): void {
    abp.message.confirm(
      this.l('ProjeDeleteWarningMessage', proje.projeId),
      undefined,
      (result: boolean) => {
        if (result) {
          this._projeServiceProxy
            delete(proje.projeId)
            pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            subscribe(() => { });
        }
      }
    );
  }

  createProje(): void {
    this.showEkleOrDüzenleProje();
  }

  // editUser(user: UserDto): void {
  //   this.showCreateOrEditUserDialog(user.id);
  // }
}
function subscribe(arg0: () => void) {
  throw new Error('Function not implemented.');
}

