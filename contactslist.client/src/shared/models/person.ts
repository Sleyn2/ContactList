import { Category } from "./category";
import { Subcategory } from "./subcategory";

export class Person {
    Id: String = ''
    name: string = ''
    surname: string = ''
    email: string = ''
    categoryId: number | null = null
    category: Category | null = null
    subcategoryId?: number | null = null
    subcategory?: Subcategory | null = null
    birthDate: Date = new Date()
    PasswordHash: string = ''
}