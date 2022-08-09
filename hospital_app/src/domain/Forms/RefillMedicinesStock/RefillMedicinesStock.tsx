import React from "react";
import { Formik, Form, FormikHelpers } from "formik";

import { Loader } from "components/Loader";
import { MedicinesInputsArray } from "./MedicinesInputsArray";
import { ErrorComponent } from "components/ErrorComponent/ErrorComponent";

import { FormValues } from "./types/formValues";

import { validationObject } from "./utils/validation";
import { useUpdateMedicinesMutation } from "service/endpoints/MedicinesEndpoints";

import styles from "./styles.module.scss";

const initialValues: FormValues = {
  medicines: [
    {
      name: "",
      quantity: 0,
    },
  ],
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
        {({ setFieldValue, values }) => {
          return (
            <Form className={styles.form}>
              <MedicinesInputsArray
                setFieldValue={setFieldValue}
                count={values.medicines.length}
                initialValue={initialValues.medicines[0]}
              />

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
