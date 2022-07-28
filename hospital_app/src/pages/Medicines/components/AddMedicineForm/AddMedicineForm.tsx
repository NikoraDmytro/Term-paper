import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

import { InputField } from "./InputField";
import { Loader } from "components/Loader";
import { IMedicine } from "models/IMedicine";
import { validationObject } from "./utils/validation";
import { ErrorComponent } from "components/ErrorComponent";

import { useCreateMedicineMutation } from "service/HospitalService";

import styles from "./styles.module.scss";
import { Navigate } from "react-router-dom";

const initialValues: IMedicine = {
  name: "",
  dosageForm: "",
  unitOfMeasure: "",
  quantityInStock: 0,
};

export const AddMedicineForm = () => {
  const [addMedicine, { isSuccess, error }] = useCreateMedicineMutation();

  const handleSubmit = async (
    values: IMedicine,
    { setSubmitting, resetForm }: FormikHelpers<IMedicine>
  ) => {
    await addMedicine(values);

    if (isSuccess) {
      resetForm();
      setSubmitting(false);

      Navigate({ to: "/medicines" });
    }
    if (error) {
      setSubmitting(false);
    }
  };

  return (
    <>
      <h1 className={styles.title}>
        Будь ласка заповніть форму для реєстрації нових ліків
      </h1>

      <Formik
        initialValues={initialValues}
        validationSchema={validationObject}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting }) => (
          <Form>
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

            <ErrorComponent error={error} />

            <button className={styles.submitBtn} type="submit">
              {!isSubmitting ? "Зареєструвати" : <Loader />}
            </button>
          </Form>
        )}
      </Formik>
    </>
  );
};
