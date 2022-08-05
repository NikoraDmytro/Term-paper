import React from "react";
import { Link } from "react-router-dom";

import { useAxios } from "hooks/useAxios";

import { Loader } from "components/Loader/Loader";
import { getHospitalUnitsNames } from "api/api";

import styles from "./styles.module.scss";

export const HospitalUnitsList = () => {
  const { data, loading, error } = useAxios<string[]>(getHospitalUnitsNames);

  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Відділення в лікарні</h1>

      <ul className={styles.hospitalUnitsList}>
        {loading && <Loader />}
        {error && <h2 className={styles.errorMessage}>{error}</h2>}
        {data &&
          data.map((unitName) => (
            <li key={unitName}>
              <Link to={unitName}>{unitName}</Link>
            </li>
          ))}
      </ul>
    </div>
  );
};
