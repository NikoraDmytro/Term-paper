import { ICreatePerson } from "../Person/ICreatePerson";

export interface ICreateDoctor extends ICreatePerson {
  hospitalUnit: string;
  experience: number;
}
