import { IPerson } from "../Person/IPerson";
import { IPatient } from "models/Patient/IPatient";

export interface ISingleDoctor extends IPerson {
  birthDate: string;
  experience: number;
  profession: string;
  patients: IPatient[];
}
