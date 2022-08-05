import { ICreatePerson } from "../Person/ICreatePerson";

export interface ICreateDoctor extends ICreatePerson {
  hospitalUnitName: string;
  experience: number;
}
