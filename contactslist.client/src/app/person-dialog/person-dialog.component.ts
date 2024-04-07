import { Component, Inject, OnInit, model } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { CommonModule, DatePipe, NgIf } from "@angular/common";
import { Person } from "../../shared/models/person";
import { Category } from "../../shared/models/category";
import { Subcategory } from "../../shared/models/subcategory";
import { MatNativeDateModule, MatOption } from "@angular/material/core";
import { ContactsService } from "../../shared/services/contacts.service";
import { MatSelectModule } from "@angular/material/select";
import { MatDatepicker } from "@angular/material/datepicker";
import { DictionaryService } from "../../shared/services/dictionary.service";

@Component({
    selector: 'person-dialog',
    templateUrl: 'person-dialog.component.html',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatButtonModule,
        MatDialogTitle,
        MatDialogContent,
        MatDialogActions,
        MatDialogClose,
        NgIf,
        CommonModule,
        MatOption,
        MatSelectModule,
    ],
})
export class PersonDialog implements OnInit {

    public person: Person;
    public categories: Category[];
    public subcategories: Subcategory[];
    public errorFlag: boolean = false
    public filteredSubcategories: Subcategory[] = [];
    private _mode: string = '';
    private _data: any
    public newSubcategory: boolean = false;
    public newSubcategoryName: string = '';

    public get mode() {
        return this._mode
    }

    constructor(
        private _contactsService: ContactsService,
        private _dictionaryService: DictionaryService,
        public dialogRef: MatDialogRef<PersonDialog>,
        public datepipe: DatePipe,
        @Inject(MAT_DIALOG_DATA) public data?: any
    ) {
        if (this.data.person != null)
            this.person = data.person
        else
            this.person = new Person();
        this.categories = data.categories;
        this.subcategories = data.subcategories;
        this._mode = data.mode;
        this._data = data;
    }

    ngOnInit(): void {
        this.onCategoryChange()
        this.person.categoryId = this.data?.person?.categoryId
    }

    public get date() {
        return this.datepipe.transform(this.person.birthDate, 'yyyy-MM-dd')
    }

    cancel(): void {
        this.dialogRef.close()
    }

    save(): void {
        this.errorFlag = false
        if (this._mode === 'Add') {
            if (this.newSubcategory) {
                if (this.person.subcategoryId === null) {
                    var newSubcategory: Subcategory = { categoryId: 3, name: this.newSubcategoryName, id: 0 }
                    this._dictionaryService.addSubcategory(newSubcategory).subscribe(
                        res => {
                            this.person.subcategoryId = res
                            this._contactsService.addPerson(this.person).subscribe(
                                res => {
                                    this.dialogRef.close(res)
                                },
                                err => this.errorFlag = true,
                                () => console.log('HTTP request completed.'));
                        },
                        err => this.errorFlag = true,
                    );
                }
                this._contactsService.addPerson(this.person).subscribe(
                    res => {
                        this.dialogRef.close(res)
                    },
                    err => this.errorFlag = true,
                    () => console.log('HTTP request completed.'));
            }
            else
                this._contactsService.addPerson(this.person).subscribe(
                    res => {
                        this.dialogRef.close(res)
                    },
                    err => this.errorFlag = true,
                    () => console.log('HTTP request completed.'));
        }
        else
            this._contactsService.editPerson(this.person).subscribe(
                res => {
                    this.dialogRef.close(res)
                },
                err => this.errorFlag = true,
                () => console.log('HTTP request completed.'));

    }

    onCategoryChange(): void {
        this.newSubcategory = false
        this.newSubcategoryName = ''
        this.filteredSubcategories = this.subcategories.filter(
            sc => sc.categoryId === this.person.categoryId
        );
        if (!this.filteredSubcategories.some(sc => sc.id === this.person.subcategoryId)) {
            this.person.subcategoryId = null;
        }
        if (this.person.categoryId === 3)
            this.newSubcategory = true
    }
}

