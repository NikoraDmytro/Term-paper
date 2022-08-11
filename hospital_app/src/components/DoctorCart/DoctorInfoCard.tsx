import React from "react";

import { IDoctor } from "models/Doctor/IDoctor";

import styles from "./styles.module.scss";
import { useDeleteDoctorMutation } from "service/endpoints/DoctorsEndpoints";
import { Loader } from "components/Loader";
import classNames from "classnames";

interface Props {
  doctor: IDoctor;
}

export const DoctorInfoCard = ({ doctor }: Props) => {
  let [deleteDoctor, { isLoading }] = useDeleteDoctorMutation();

  const handleDeleteBtnClick = async () => {
    const confirmation = window.confirm(
      `Ви впевнені, що хочете звільнити ${doctor.fullName}?`
    );

    if (confirmation) {
      const response = await deleteDoctor(doctor.fullName);

      if ("error" in response) {
        window.alert(`Через помилку не вдалося видалити лікаря з бази даних!`);
      } else {
        window.alert(`Лікаря звільнено!`);
      }
    }
  };

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

      <div className={styles.buttonsContainer}>
        <button className={classNames(styles.cardBtn, styles.editBtn)}>
          Редагувати
        </button>

        <button
          className={classNames(styles.cardBtn, styles.deleteBtn)}
          onClick={handleDeleteBtnClick}
        >
          {!isLoading ? "Звільнити" : <Loader small />}
        </button>
      </div>
    </div>
  );
};
