import { IHospitalWard } from "models/HospitalWard/IHospitalWard";

import bedIcon from "icons/bedIcon.png";
import patientIcon from "icons/patientIcon.png";

import styles from "./UnitWards.module.scss";

interface Props {
  ward: IHospitalWard;
}

export const WardInfoBlock = ({ ward }: Props) => {
  return (
    <div className={styles.wardContainer}>
      <h2 className={styles.wardNumber}>№ {ward.number}</h2>

      <div>
        <div className={styles.count}>
          {ward.occupancy} <img src={patientIcon} alt="" />
        </div>

        <p className={styles.caption}>Хворих</p>
      </div>

      <div>
        <div className={styles.count}>
          {ward.bedsQuantity} <img src={bedIcon} alt="" />
        </div>

        <p className={styles.caption}>Ліжок</p>
      </div>
    </div>
  );
};
