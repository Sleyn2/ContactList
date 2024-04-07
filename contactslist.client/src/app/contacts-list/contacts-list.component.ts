import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../../shared/services/contacts.service';
import { MatTableDataSource } from '@angular/material/table';
import { Person } from '../../shared/models/person';
import { SelectionModel } from '@angular/cdk/collections';
import { DictionaryItem } from '../../shared/utils/Dictionary';
import { DictionaryService } from '../../shared/services/dictionary.service';
import { PersonDialog } from '../person-dialog/person-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
    selector: 'app-contacts-list',
    templateUrl: './contacts-list.component.html',
    styleUrl: './contacts-list.component.css'
})
export class ContactsListComponent implements OnInit {

    private _dataSource = new MatTableDataSource<Person>()
    private _selection = new SelectionModel<Person>(false, [])
    private _displayedColumns: string[] = ['select', 'name', 'surname', 'category']

    private _categoryTypes: DictionaryItem[] = [];
    private _subcategoryTypes: DictionaryItem[] = [];

    public get categoryTypes() {
        return this._categoryTypes
    }

    public category(i: number) {
        return this._categoryTypes.find(x => x.id == i)
    }

    public get signedIn() {
        return !!localStorage.getItem("id_token");
    }

    public get notDisabled() {
        return this.signedIn == true && !!this._selection.selected[0] == true
    }

    public get subcategoryTypes() {
        return this._subcategoryTypes
    }

    public subcategory(i: number) {
        return this._subcategoryTypes.find(x => x.id == i)
    }

    public get dataSource() {
        return this._dataSource
    }

    public get selection() {
        return this._selection
    }

    public get displayedColumns() {
        return this._displayedColumns
    }

    constructor(
        public dialog: MatDialog,
        private _contactsService: ContactsService,
        private _dictionaryService: DictionaryService
    ) {
    }

    ngOnInit(): void {
        this._contactsService.getAllPersons().subscribe(list => this._dataSource = new MatTableDataSource<Person>(list))
        this._dictionaryService.getCategoryDict().subscribe(list => this._categoryTypes = list)
        this._dictionaryService.getSubcategoryDict().subscribe(list => this._subcategoryTypes = list)
    }

    addItem() {
        const dialogRef = this.dialog.open(PersonDialog, {
            data: {
                categories: this._categoryTypes,
                subcategories: this._subcategoryTypes,
                mode: 'Add'
            }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result != undefined)
                this._dataSource = new MatTableDataSource<Person>(result)
        });
    }

    editItem() {
        const dialogRef = this.dialog.open(PersonDialog, {
            data: {
                person: this._selection.selected[0],
                categories: this._categoryTypes,
                subcategories: this._subcategoryTypes,
                mode: 'Edit'
            }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result != undefined)
                this._dataSource = new MatTableDataSource<Person>(result)
        });
    }

    removeItem() {
        this._contactsService.removePerson(this._selection.selected[0]).subscribe(result => {
            if (result != undefined)
                this._dataSource = new MatTableDataSource<Person>(result)
        }
        )
    }
}