import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

import { Loader } from "components/Loader";
import { IMedicine } from "models/IMedicine";
import { validationObject } from "./utils/validation";
import { InputField } from "components/Inputs/InputField";
import { ErrorComponent } from "components/ErrorComponent";

import { useCreateMedicineMutation } from "service/HospitalService";

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
      <h1 className={styles.title}>Форма реєстрації ліків</h1>

      <Formik
        initialValues={initialValues}
        validationSchema={validationObject}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting }) => (
          <Form className={styles.addMedicineForm}>
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

            <button className={styles.submitBtn} type="submit">
              {!isSubmitting ? "Зареєструвати" : <Loader small />}
            </button>

            <div className={styles.errorBlock}>
              <ErrorComponent error={error} />
            </div>
          </Form>
        )}
      </Formik>
    </>
  );
};
