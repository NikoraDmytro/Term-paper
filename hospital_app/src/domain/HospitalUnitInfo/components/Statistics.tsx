import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";
import React from "react";

import styles from "./Statistics.module.scss";

import wardIcon from "icons/wardIcon.png";
import doctorIcon from "icons/doctorIcon.png";
import patientIcon from "icons/patientIcon.png";

interface Props {
  unit: IHospitalUnit;
}

export const Statistics = ({ unit }: Props) => (
  <div className={styles.statisticsBlock}>
    <ul className={styles.statistics}>
      <li>
        <div className={styles.count}>
          {unit.wardsQuantity} <img src={wardIcon} alt="" />
        </div>
        Палати
      </li>
      <li>
        <div className={styles.count}>
          {unit.doctorsQuantity} <img src={doctorIcon} alt="" />
        </div>
        Лікарів
      </li>
      <li>
        <div className={styles.count}>
          {unit.totalOccupancy} <img src={patientIcon} alt="" />
        </div>
        Хворих
      </li>
    </ul>
  </div>
);
