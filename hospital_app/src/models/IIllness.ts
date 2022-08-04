import { ITreatment } from "./ITreatment";

export interface IIllness {
  name: string;
  symptoms: string;
  procedures: string;
  hospitalUnitName: string;
  treatments: ITreatment[];
}
