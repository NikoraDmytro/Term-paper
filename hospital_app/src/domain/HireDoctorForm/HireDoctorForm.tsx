import React from "react";
import { Form, Formik, FormikHelpers } from "formik";

import { Loader } from "components/Loader";
import { DateField } from "components/Inputs/DateField";
import { InputField } from "components/Inputs/InputField";
import { ErrorComponent } from "components/ErrorComponent";
import { AsyncDropDownField } from "components/Inputs/AsyncDropDownField";

import { getHospitalUnitsNames } from "api/api";
import { validationObject } from "./utils/validation";
import { ICreateDoctor } from "models/Doctor/ICreateDoctor";

import styles from "./styles.module.scss";
import { useCreateDoctorMutation } from "service/endpoints/DoctorsEndpoints";

const initialValues: ICreateDoctor = {
  name: "",
  surname: "",
  experience: 0,
  patronymic: "",
  hospitalUnitName: "",
  birthDate: new Date(),
};

export const HireDoctorForm = () => {
  const [addDoctor, { error }] = useCreateDoctorMutation();

  const handleSubmit = async (
    values: ICreateDoctor,
    { setSubmitting, resetForm }: FormikHelpers<ICreateDoctor>
  ) => {
    try {
      await addDoctor(values).unwrap();

      window.alert("Лікар тепер працює в лікарні!");

      resetForm();
      setSubmitting(false);
    } catch (error) {}
  };

  return (
    <>
      <h1 className={styles.formTitle}>Форма для внесення даних лікаря</h1>

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

              <InputField label="Досвід" name="experience" type="number" />

              <AsyncDropDownField
                label="Відділення"
                name="hospitalUnitName"
                loadOptions={getHospitalUnitsNames}
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
