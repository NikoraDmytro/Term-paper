import React from "react";
import { Link, useNavigate } from "react-router-dom";

import { IPatient } from "models/Patient/IPatient";

import { Loader } from "components/Loader";
import { ErrorComponent } from "components/ErrorComponent/ErrorComponent";

import { useDeletePatientMutation } from "service/endpoints/PatientsEndpoints";

import styles from "./styles.module.scss";

interface Props {
  patient: IPatient;
}

const renderBlock = (title: string, text: string) => (
  <div className={styles.block}>
    <p>{title}: </p>

    <span>{text}</span>
  </div>
);

const parseDateString = (date: Date) => new Date(date).toLocaleDateString();

export const PatientCart = ({ patient }: Props) => {
  const navigate = useNavigate();
  const [deletePatient, { isLoading, error }] = useDeletePatientMutation();

  const handleDeleteBtnClick = async () => {
    const confirmation = window.confirm(
      `Ви впевнені, що хочете виписати ${patient.fullName}?`
    );

    if (confirmation) {
      const response = await deletePatient(patient.fullName);

      if ("data" in response) {
        window.alert("Пацієнта виписано!");
      }
    }
  };

  return (
    <div className={styles.patientCard}>
      <h1 className={styles.patientName}>{patient.fullName}</h1>

      {renderBlock("Вік", `${patient.age} років`)}

      {renderBlock("Дата реєстрації", parseDateString(patient.dateOfAdmission))}

      {renderBlock("Палата", `№${patient.hospitalWardNumber}`)}

      <div className={styles.block}>
        <p>Діагноз: </p>

        <Link
          className={styles.illnessLink}
          to={`/illnesses/${patient.diagnosis}`}
        >
          {patient.diagnosis}
        </Link>
      </div>

      <div className={styles.lastBlock}>
        <p>Персональний лікар:</p>

        <span>{patient.attendingDoctor}</span>
      </div>

      <div className={styles.buttonsRow}>
        <button
          onClick={() => navigate(`addPatient/${patient.fullName}`)}
          className={styles.editBtn}
        >
          Редагувати
        </button>

        <button className={styles.deleteBtn} onClick={handleDeleteBtnClick}>
          {!isLoading ? "Виписати" : <Loader small />}
        </button>

        <ErrorComponent error={error} />
      </div>
    </div>
  );
};
