import React from "react";
import { useSearchParams } from "react-router-dom";

import { DoctorInfoCard } from "components/DoctorCart";
import { PagedListWrapper } from "components/PagedListWrapper";

import { getHospitalUnitsNames } from "api/api";
import { sortingOptions } from "./sortingOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllDoctorsQuery } from "service/endpoints/DoctorsEndpoint";

import styles from "./styles.module.scss";

export const DoctorsList = () => {
  const [searchParams] = useSearchParams();

  const { data, isLoading, isFetching, error } = useGetAllDoctorsQuery(
    searchParamsToObject(searchParams)
  );

  return (
    <PagedListWrapper
      controlPanelProps={{
        dataFilteringSelectors: [
          {
            name: "HospitalUnit",
            label: "Відділення:",
            request: getHospitalUnitsNames,
          },
        ],
        dataSortingOptions: sortingOptions,
        searchPlaceholder: "Введіть ФІО лікаря",
      }}
      fetchResult={{ data, isLoading, isFetching, error }}
    >
      <ul className={styles.doctorsList}>
        {data &&
          data.items.map((doctor) => (
            <li key={doctor.fullName}>
              <DoctorInfoCard doctor={doctor} />
            </li>
          ))}
      </ul>
    </PagedListWrapper>
  );
};
