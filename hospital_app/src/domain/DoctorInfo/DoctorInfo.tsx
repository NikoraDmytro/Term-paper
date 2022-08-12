import React from "react";
import { useParams } from "react-router-dom";

import { useGetDoctorQuery } from "service/endpoints/DoctorsEndpoints";

import { Loader } from "components/Loader";
import { ErrorComponent } from "components/ErrorComponent";
import { PatientCart } from "components/PatientCart/PatientCart";

import styles from "./styles.module.scss";

export const DoctorInfo = () => {
  const { doctorFullName = "" } = useParams();
  const { data: doctor, isLoading, error } = useGetDoctorQuery(doctorFullName);

  return (
    <>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {doctor && (
        <>
          <h1 className={styles.doctorName}>{doctor.fullName}</h1>

          <p className={styles.doctorProfession}>{doctor.profession}</p>

          <h2 className={styles.subTitle}>Пацієнти</h2>

          <ul className={styles.patientsList}>
            {doctor.patients.length ? (
              doctor.patients.map((patient) => (
                <li key={patient.fullName}>
                  <PatientCart patient={patient} />
                </li>
              ))
            ) : (
              <h1 className={styles.noContent}>Список порожній</h1>
            )}
          </ul>
        </>
      )}
    </>
  );
};
