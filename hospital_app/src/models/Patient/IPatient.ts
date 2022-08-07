import { IPerson } from "../Person/IPerson";

export interface IPatient extends IPerson {
  diagnosis: string;
  wardNumber: number;
  dateOfAdmission: Date;
  attendingDoctor: string;
}
