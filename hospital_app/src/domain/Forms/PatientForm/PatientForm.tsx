import React from "react";
import { Form, Formik } from "formik";

import { Loader } from "components/Loader";
import { DateField } from "components/Inputs/DateField";
import { InputField } from "components/Inputs/InputField";
import { ErrorComponent } from "components/ErrorComponent";
import { AsyncDropDownField } from "components/Inputs/AsyncDropDownField";

import {
  getDoctorsFullNames,
  getIllnessesNames,
  getWardsNumbers,
} from "api/api";
import { validationObject } from "./utils/validation";

import styles from "./styles.module.scss";
import { PatientFormWrapper } from "./PatientFormWrapper";

export const PatientForm = () => {
  return (
    <PatientFormWrapper>
      {(initialValues, handleSubmit, error) => (
        <Formik
          initialValues={initialValues}
          validationSchema={validationObject}
          onSubmit={handleSubmit}
        >
          {({ isSubmitting }) => {
            return (
              <Form className={styles.form}>
                <InputField label="Прізвище" name="surname" type="text" />

                <InputField label="Ім'я" name="name" type="text" />

                <InputField label="По батькові" name="patronymic" type="text" />

                <DateField label="Дата народження" name="birthDate" />

                <AsyncDropDownField
                  label="Палата"
                  name="hospitalWardNumber"
                  loadOptions={getWardsNumbers}
                />

                <AsyncDropDownField
                  label="Персональний лікар"
                  name="attendingDoctor"
                  loadOptions={getDoctorsFullNames}
                />

                <AsyncDropDownField
                  label="Діагноз"
                  name="diagnosis"
                  loadOptions={getIllnessesNames}
                />

                <ErrorComponent inline error={error} />

                <button className={styles.submitBtn} type="submit">
                  {!isSubmitting ? "Зареєструвати" : <Loader small />}
                </button>
              </Form>
            );
          }}
        </Formik>
      )}
    </PatientFormWrapper>
  );
};
