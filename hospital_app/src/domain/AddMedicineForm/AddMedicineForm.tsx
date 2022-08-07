import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

import { IMedicine } from "models/Medicine/IMedicine";

import { Loader } from "components/Loader";
import { InputField } from "components/Inputs/InputField";
import { ErrorComponent } from "components/ErrorComponent";

import { validationObject } from "./utils/validation";
import { useCreateMedicineMutation } from "service/endpoints/MedicinesEndpoints";

import styles from "./styles.module.scss";

const initialValues: IMedicine = {
  name: "",
  dosageForm: "",
  unitOfMeasure: "",
  quantityInStock: 0,
};

export const AddMedicineForm = () => {
  const [addMedicine, { error }] = useCreateMedicineMutation();

  const handleSubmit = async (
    values: IMedicine,
    { setSubmitting, resetForm }: FormikHelpers<IMedicine>
  ) => {
    try {
      await addMedicine(values).unwrap();

      window.alert("Зареєстровано!");

      resetForm();
      setSubmitting(false);
    } catch (error) {}
  };

  return (
    <>
      <h1 className={styles.formTitle}>Форма реєстрації ліків</h1>

      <Formik
        initialValues={initialValues}
        validationSchema={validationObject}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting }) => (
          <Form className={styles.form}>
            <InputField label="Назва ліків" name="name" type="text" />

            <InputField label="Лікарська форма" name="dosageForm" type="text" />

            <InputField
              label="Одиниця виміру кількості"
              name="unitOfMeasure"
              type="text"
            />

            <InputField
              label="Кількість"
              name="quantityInStock"
              type="number"
            />

            <ErrorComponent inline error={error} />

            <button className={styles.submitBtn} type="submit">
              {!isSubmitting ? "Зареєструвати" : <Loader small />}
            </button>
          </Form>
        )}
      </Formik>
    </>
  );
};
