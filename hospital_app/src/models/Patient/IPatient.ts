import { IPerson } from "../Person/IPerson";

export interface IPatient extends IPerson {
  diagnosis: string;
  dateOfAdmission: Date;
  attendingDoctor: string;
  hospitalWardNumber: number;
}
