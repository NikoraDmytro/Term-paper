import React from "react";

import { IDoctor } from "models/Doctor/IDoctor";

import defaultImg from "./img/doctor.png";

import styles from "./styles.module.scss";

interface Props {
  doctor: IDoctor;
}

export const DoctorInfoCard = ({ doctor }: Props) => {
  return (
    <div className={styles.doctorCard} key={doctor.fullName}>
      <img className={styles.doctorImage} src={defaultImg} alt="Ooops" />

      <div className={styles.cardInfoBlock}>
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
    </div>
  );
};
