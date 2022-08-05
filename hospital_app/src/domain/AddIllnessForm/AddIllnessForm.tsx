import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

import { Loader } from "components/Loader";
import { TreatmentsInputs } from "./TreatmentsInputs";
import { InputField } from "components/Inputs/InputField";
import { ErrorComponent } from "components/ErrorComponent";
import { AsyncDropDownField } from "components/Inputs/AsyncDropDownField";

import { ICreateIllness } from "models/Illness/ICreateIllness";

import { getHospitalUnitsNames } from "api/api";
import { validationObject } from "./utils/validation";
import { useCreateIllnessMutation } from "service/endpoints/IllnessesEndpoints";

import styles from "./styles.module.scss";

const initialValues: ICreateIllness = {
  name: "",
  symptoms: "",
  procedures: "",
  hospitalUnitName: "",
  treatments: [
    {
      medicineName: "",
      medicineQuantity: 0,
    },
  ],
};

export const AddIllnessForm = () => {
  const [addIllness, { error }] = useCreateIllnessMutation();

  const handleSubmit = async (
    values: ICreateIllness,
    { setSubmitting, resetForm }: FormikHelpers<ICreateIllness>
  ) => {
    try {
      await addIllness(values).unwrap();

      window.alert("Додано!");

      resetForm();
      setSubmitting(false);
    } catch (error) {}
  };

  return (
    <>
      <h1 className={styles.formTitle}>Форма реєстрації нової хвороби</h1>

      <Formik
        initialValues={initialValues}
        validationSchema={validationObject}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting, setFieldValue, values }) => {
          return (
            <Form className={styles.form}>
              <InputField label="Назва хвороби" name="name" type="text" />

              <InputField label="Симптоми" name="symptoms" isTextArea />

              <InputField label="Процедури" name="procedures" isTextArea />

              <AsyncDropDownField
                label="Відділення"
                name="hospitalUnitName"
                loadOptions={getHospitalUnitsNames}
              />

              <h2
                style={{
                  fontWeight: 500,
                  padding: "0.25em 1em",
                  gridColumn: "1 / -1",
                  borderBottom: "1px solid black",
                }}
              >
                Необхідні ліки
              </h2>

              <TreatmentsInputs
                setFieldValue={setFieldValue}
                count={values.treatments.length}
                initialValue={initialValues.treatments[0]}
              />

              <ErrorComponent inline error={error} />

              <button className={styles.submitBtn} type="submit">
                {!isSubmitting ? "Зареєструвати" : <Loader small />}
              </button>
            </Form>
          );
        }}
      </Formik>
    </>
  );
};
