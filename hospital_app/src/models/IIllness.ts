import { IUpdateMedicine } from "models/IUpdateMedicine";

export interface IIllness {
  name: string;
  symptoms: string;
  procedures: string;
  hospitalUnitName: string;
  treatments: IUpdateMedicine[];
}
