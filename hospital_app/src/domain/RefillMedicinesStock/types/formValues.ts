import { IUpdateMedicine } from "models/IUpdateMedicine";

export type IUpdateMedicineWithId = IUpdateMedicine & { id: string };

export type FormValues = {
  medicines: IUpdateMedicineWithId[];
};
