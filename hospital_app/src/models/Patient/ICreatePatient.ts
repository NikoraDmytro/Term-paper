import { ICreatePerson } from "models/Person/ICreatePerson";

export interface ICreatePatient extends ICreatePerson {
  diagnosis: string;
  hospitalWardNumber: number;
  attendingDoctor: string;
}
