import React from "react";
import { Formik, Form, FormikHelpers } from "formik";

import { Loader } from "components/Loader";
import { MedicinesInputsArray } from "./MedicinesInputsArray";
import { ErrorComponent } from "components/ErrorComponent/ErrorComponent";

import { FormValues } from "./types/formValues";

import { getNewValue } from "./utils/getNewValue";
import { validationObject } from "./utils/validation";
import { useUpdateMedicinesMutation } from "service/endpoints/MedicinesEndpoint";

import styles from "./styles.module.scss";

const initialValues: FormValues = {
  medicines: [getNewValue()],
};

export const RefillMedicinesStock = () => {
  const [updateMedicines, { isLoading, error }] = useUpdateMedicinesMutation();

  const handleSubmit = async (
    values: FormValues,
    { setSubmitting, resetForm }: FormikHelpers<FormValues>
  ) => {
    try {
      await updateMedicines(values.medicines).unwrap();

      window.alert("Запаси ліків оновлено!");

      resetForm();
      setSubmitting(false);
    } catch (error) {}
  };

  return (
    <>
      <h1 className={styles.formTitle}>Поповнити склад ліків</h1>

      <Formik
        initialValues={initialValues}
        validationSchema={validationObject}
        onSubmit={handleSubmit}
      >
        {({ values }) => {
          return (
            <Form className={styles.form}>
              <MedicinesInputsArray medicineToUpdate={values.medicines} />

              <ErrorComponent error={error} inline />

              <button className={styles.submitBtn} type="submit">
                {!isLoading ? "Підтвердити" : <Loader small />}
              </button>
            </Form>
          );
        }}
      </Formik>
    </>
  );
};