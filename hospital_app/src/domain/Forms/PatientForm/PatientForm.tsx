import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

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
import { ICreatePatient } from "models/Patient/ICreatePatient";
import { useCreatePatientMutation } from "service/endpoints/PatientsEndpoints";

const initialValues: ICreatePatient = {
  name: "",
  surname: "",
  diagnosis: "",
  patronymic: "",
  attendingDoctor: "",
  birthDate: new Date(),
  hospitalWardNumber: 0,
};

export const PatientForm = () => {
  const [addPatient, { error }] = useCreatePatientMutation();

  const handleSubmit = async (
    values: ICreatePatient,
    { setSubmitting, resetForm }: FormikHelpers<ICreatePatient>
  ) => {
    try {
      values.hospitalWardNumber = +values.hospitalWardNumber;

      await addPatient(values).unwrap();

      window.alert("Пацінта зареєстровано!");

      resetForm();
      setSubmitting(false);
    } catch (error) {}
  };

  return (
    <>
      <h1 className={styles.formTitle}>Форма для внесення даних пацієнта</h1>

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
    </>
  );
};
