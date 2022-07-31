import { MouseEvent, useState } from "react";
import { FieldArray } from "formik";
import classNames from "classnames";

import { getNewValue } from "./utils/getNewValue";
import { InputField } from "components/Inputs/InputField";
import { IUpdateMedicineWithId } from "./types/formValues";

import styles from "./styles.module.scss";

interface Props {
  medicineToUpdate: IUpdateMedicineWithId[];
}

type BtnClickEvent = MouseEvent<HTMLButtonElement>;

export const MedicinesInputsArray = ({ medicineToUpdate }: Props) => {
  const [newElementIndex, setNewElementIndex] = useState(-1);

  return (
    <FieldArray name="medicines">
      {(arrayHelpers) => {
        const addElement = (index: number) => () => {
          arrayHelpers.insert(index + 1, getNewValue());

          setNewElementIndex(index + 1);
        };

        const removeElement = (index: number) => (e: BtnClickEvent) => {
          if (medicineToUpdate.length < 2) return;

          const parent = e.currentTarget.parentElement;

          if (!parent) return;

          parent.classList.add(styles.shrink);

          parent.onanimationend = () => {
            arrayHelpers.remove(index);
          };
        };

        return medicineToUpdate.map(({ id }, index) => (
          <div
            key={id}
            className={classNames(styles.inputsBlock, {
              [styles.grow]: index === newElementIndex,
            })}
            onAnimationEnd={
              index === newElementIndex
                ? () => setNewElementIndex(-1)
                : undefined
            }
          >
            <InputField
              label="Назва ліків"
              name={`medicines.${index}.name`}
              type="text"
            />

            <InputField
              label="Кількість"
              name={`medicines.${index}.quantity`}
              type="number"
            />

            <button
              type="button"
              className={styles.addBlockBtn}
              onClick={addElement(index)}
            />

            <button
              type="button"
              className={styles.removeBlockBtn}
              onClick={removeElement(index)}
            />
          </div>
        ));
      }}
    </FieldArray>
  );
};
