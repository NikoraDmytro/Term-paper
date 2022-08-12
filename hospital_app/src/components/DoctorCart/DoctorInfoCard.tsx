import React, { MouseEvent } from "react";
import { useNavigate } from "react-router-dom";

import { IDoctor } from "models/Doctor/IDoctor";

import styles from "./styles.module.scss";
import { useDeleteDoctorMutation } from "service/endpoints/DoctorsEndpoints";
import { Loader } from "components/Loader";
import { ErrorComponent } from "./../ErrorComponent/ErrorComponent";

interface Props {
  doctor: IDoctor;
}

export const DoctorInfoCard = ({ doctor }: Props) => {
  const navigate = useNavigate();
  let [deleteDoctor, { isLoading, error }] = useDeleteDoctorMutation();

  const handleDeleteBtnClick = async (e: MouseEvent<HTMLButtonElement>) => {
    e.stopPropagation();

    const confirmation = window.confirm(
      `Ви впевнені, що хочете звільнити ${doctor.fullName}?`
    );

    if (confirmation) {
      const response = await deleteDoctor(doctor.fullName);

      if ("data" in response) {
        window.alert(`Лікаря звільнено!`);
      }
    }
  };

  return (
    <div
      onClick={() => navigate(doctor.fullName)}
      className={styles.doctorCard}
    >
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

      <div className={styles.buttonBlock}>
        <button className={styles.deleteBtn} onClick={handleDeleteBtnClick}>
          {!isLoading ? "Звільнити" : <Loader small />}
        </button>
      </div>

      <ErrorComponent inline error={error} />
    </div>
  );
};
