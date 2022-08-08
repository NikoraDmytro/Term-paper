import React from "react";
import { useSearchParams } from "react-router-dom";

import { sortOptions } from "./sortOptions";
import { filterOptions } from "./filterOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllPatientsQuery } from "service/endpoints/PatientsEndpoints";

import { PagedListWrapper } from "components/PagedListWrapper";

import styles from "./styles.module.scss";

export const PatientsList = () => {
  const [searchParams] = useSearchParams();

  const { data, isLoading, isFetching, error } = useGetAllPatientsQuery(
    searchParamsToObject(searchParams)
  );

  return (
    <PagedListWrapper
      fetchResult={{ data, isLoading, isFetching, error }}
      controlPanelProps={{
        searchPlaceholder: "Введіть ФІО пацієнта",
        dataSortingOptions: sortOptions,
        dataFilteringSelectors: filterOptions,
      }}
    >
      {data && (
        <ul className={styles.patientsList}>
          {data.items.map((patient) => (
            <li key={patient.fullName}>
              <div className={styles.patientCard}>
                <h1 className={styles.patientName}>{patient.fullName}</h1>

                <div className={styles.block}>
                  <span>Вік: {patient.age}</span>

                  <span>
                    Дата реєстрації:{" "}
                    {new Date(patient.dateOfAdmission).toLocaleDateString()}
                  </span>
                </div>

                <div className={styles.block}>
                  <span>Діагноз: {patient.diagnosis}</span>

                  <span>Палата: №{patient.hospitalWardNumber}</span>
                </div>

                <div className={styles.block}>
                  <span>Персональний лікар:</span>

                  <span>{patient.attendingDoctor}</span>
                </div>
              </div>
            </li>
          ))}
        </ul>
      )}
    </PagedListWrapper>
  );
};
