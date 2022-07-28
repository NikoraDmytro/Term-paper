import React from "react";

import { Wrapper } from "./components/Wrapper";
import { TableRow } from "./components/TableRow";

import styles from "./styles.module.scss";

export const MedicinesTable = () => {
  return (
    <Wrapper>
      {(medicines) => (
        <table className={styles.medicinesTable}>
          <thead>
            <tr>
              <th>Назва</th>
              <th>Кількість</th>
              <th></th>
            </tr>
          </thead>

          <tbody>
            {medicines &&
              medicines.map((medicine, index) => (
                <TableRow key={index} medicine={medicine} />
              ))}
          </tbody>
        </table>
      )}
    </Wrapper>
  );
};
