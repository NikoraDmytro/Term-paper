import { InputField } from "components/Inputs/InputField";
import { AsyncDropDownField } from "components/Inputs/AsyncDropDownField";
import { DynamicInputsArray } from "components/Inputs/DynamicInputsArray";

import { getMedicinesNames } from "api/api";

import { IUpdateMedicine } from "models/IUpdateMedicine";

interface Props {
  count: number;
  initialValue: IUpdateMedicine;
  setFieldValue: (fieldName: string, value: any) => void;
}

export const MedicinesInputsArray = (props: Props) => {
  return (
    <DynamicInputsArray
      name="medicines"
      count={props.count}
      initialValue={props.initialValue}
    >
      {(index) => (
        <>
          <AsyncDropDownField
            type="text"
            label="Назва ліків"
            loadOptions={getMedicinesNames}
            name={`medicines.${index}.name`}
            select={(option) =>
              props.setFieldValue(`medicines.${index}.name`, option)
            }
          />

          <InputField
            label="Кількість"
            name={`medicines.${index}.quantity`}
            type="number"
          />
        </>
      )}
    </DynamicInputsArray>
  );
};
