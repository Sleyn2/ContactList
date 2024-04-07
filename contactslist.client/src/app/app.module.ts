import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatCell, MatCellDef, MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef, MatTable, MatColumnDef, MatHeaderCell, MatHeaderCellDef } from '@angular/material/table'
import { MatCheckboxModule } from '@angular/material/checkbox'
import { MatIconModule } from '@angular/material/icon'
import { MatDialogModule } from '@angular/material/dialog'
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ContactsListComponent } from './contacts-list/contacts-list.component';
import { MatOption, MatSelectModule } from '@angular/material/select';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { LoginDialog } from './login-dialog/login-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, DatePipe, NgIf } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    ContactsListComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatTable,
    MatCheckboxModule,
    MatRow,
    MatRowDef,
    MatCell,
    MatCellDef,
    MatHeaderRow,
    MatHeaderRowDef,
    MatSelectModule,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderCellDef,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    LoginDialog,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NgIf,
    MatOption,
    MatFormFieldModule
  ],
  providers: [
    provideAnimationsAsync(),
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
