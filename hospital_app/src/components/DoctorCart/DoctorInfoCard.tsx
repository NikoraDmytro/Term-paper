import React from "react";

import { IDoctor } from "models/Doctor/IDoctor";

import styles from "./styles.module.scss";

interface Props {
  doctor: IDoctor;
}

export const DoctorInfoCard = ({ doctor }: Props) => {
  return (
    <div className={styles.doctorCard} key={doctor.fullName}>
      <h2>{doctor.fullName}</h2>
      <p>{doctor.profession}</p>

      <div>
        <span>
          <strong>Вік:</strong> {doctor.age} років
        </span>

        <span>
          <strong>Досвід:</strong> {doctor.experience} років
        </span>
      </div>
    </div>
  );
};
