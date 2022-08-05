import { IPerson } from "../Person/IPerson";

export interface IDoctor extends IPerson {
  experience: number;
  profession: string;
}
