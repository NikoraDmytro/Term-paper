import { ICreateTreatment } from "./ICreateTreatment";

export interface ICreateIllness {
  name: string;
  symptoms: string;
  procedures: string;
  hospitalUnitName: string;
  treatments: ICreateTreatment[];
}
