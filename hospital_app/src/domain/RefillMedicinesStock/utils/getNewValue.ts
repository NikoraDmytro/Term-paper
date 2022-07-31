import { v4 as uuidv4 } from "uuid";
import { IUpdateMedicineWithId } from "../types/formValues";

export const getNewValue = (): IUpdateMedicineWithId => {
  return {
    id: uuidv4(),
    name: "",
    quantity: 0,
  };
};
