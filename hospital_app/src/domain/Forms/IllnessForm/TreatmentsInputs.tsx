import { InputField } from "components/Inputs/InputField";
import { AsyncDropDownField } from "components/Inputs/AsyncDropDownField";
import { DynamicInputsArray } from "components/Inputs/DynamicInputsArray";

import { getMedicinesNames } from "api/api";

import { ICreateTreatment } from "models/Illness/ICreateTreatment";

interface Props {
  count: number;
  initialValue: ICreateTreatment;
  setFieldValue: (fieldName: string, value: any) => void;
}

export const TreatmentsInputs = (props: Props) => {
  return (
    <DynamicInputsArray
      name="treatments"
      count={props.count}
      initialValue={props.initialValue}
    >
      {(index) => (
        <>
          <AsyncDropDownField
            type="text"
            label="Назва ліків"
            loadOptions={getMedicinesNames}
            name={`treatments.${index}.medicineName`}
          />

          <InputField
            label="Кількість"
            name={`treatments.${index}.medicineQuantity`}
            type="number"
          />
        </>
      )}
    </DynamicInputsArray>
  );
};
