import { ICreatePerson } from "models/Person/ICreatePerson";

export interface ICreatePatient extends ICreatePerson {
  diagnosis: string;
  wardNumber: number;
  attendingDoctor: string;
}
