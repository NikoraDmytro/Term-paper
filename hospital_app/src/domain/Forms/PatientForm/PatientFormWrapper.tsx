import React, { ReactNode } from "react";
import { FormikHelpers } from "formik";
import { SerializedError } from "@reduxjs/toolkit";
import { useNavigate, useParams } from "react-router-dom";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

import { ICreatePatient } from "models/Patient/ICreatePatient";
import {
  useCreatePatientMutation,
  useGetPatientQuery,
  useUpdatePatientMutation,
} from "service/endpoints/PatientsEndpoints";
import { Loader } from "./../../../components/Loader/Loader";
import { ErrorComponent } from "components/ErrorComponent";

import styles from "./styles.module.scss";

interface Props {
  children: (
    initialValues: ICreatePatient,
    handleSubmit: (
      values: ICreatePatient,
      formikHelpers: FormikHelpers<ICreatePatient>
    ) => void,
    submitError?: FetchBaseQueryError | SerializedError
  ) => ReactNode;
}

const initialValues: ICreatePatient = {
  name: "",
  surname: "",
  diagnosis: "",
  patronymic: "",
  attendingDoctor: "",
  birthDate: new Date(),
  hospitalWardNumber: 0,
};

export const PatientFormWrapper = ({ children }: Props) => {
  const { patientFullName } = useParams();
  const navigate = useNavigate();

  const {
    data: patient,
    isLoading,
    error,
  } = useGetPatientQuery(patientFullName ?? "");

  const [addPatient, { error: createError }] = useCreatePatientMutation();
  const [editPatient, { error: editError }] = useUpdatePatientMutation();

  const handleSubmit = async (
    values: ICreatePatient,
    { setSubmitting, resetForm }: FormikHelpers<ICreatePatient>
  ) => {
    values.hospitalWardNumber = +values.hospitalWardNumber;

    if (patientFullName) {
      const response = await editPatient({
        fullName: patientFullName,
        patient: values,
      });

      if ("data" in response) {
        window.alert("Дані пацієнта оновлено!");
        navigate("/patients?PageSize=6&PageNumber=1");

        resetForm();
        setSubmitting(false);
      }
    } else {
      const response = await addPatient(values);

      if ("data" in response) {
        window.alert("Пацінта зареєстровано!");

        resetForm();
        setSubmitting(false);
      }
    }
  };

  if (patientFullName) {
    const [surname, name, patronymic] = patientFullName.split(" ");

    return (
      <>
        {isLoading && <Loader />}
        {error && <ErrorComponent error={error} />}
        {patient && (
          <>
            <h1 className={styles.formTitle}>
              Форма для редагування даних пацієнта
            </h1>

            {children(
              {
                name,
                surname,
                patronymic,
                diagnosis: patient.diagnosis,
                birthDate: new Date(patient.birthDate),
                attendingDoctor: patient.attendingDoctor,
                hospitalWardNumber: patient.hospitalWardNumber,
              },
              handleSubmit,
              editError
            )}
          </>
        )}
      </>
    );
  }

  return (
    <>
      <h1 className={styles.formTitle}>Форма для внесення даних пацієнта</h1>

      {children(initialValues, handleSubmit, createError)}
    </>
  );
};
