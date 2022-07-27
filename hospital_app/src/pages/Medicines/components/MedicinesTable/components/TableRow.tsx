import { IMedicine } from "../../../../../models/IMedicine";

import styles from "./TableRow.module.scss";

interface Props {
  medicine: IMedicine;
}

export const TableRow = ({ medicine }: Props) => {
  return (
    <tr>
      <td>
        {medicine.name}{" "}
        <span className={styles.dosageForm}>{medicine.dosageForm}</span>
      </td>
      <td>
        {medicine.quantityInStock} {medicine.unitOfMeasure}
      </td>
    </tr>
  );
};
