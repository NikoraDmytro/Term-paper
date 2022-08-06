import React from "react";
import { useParams, useSearchParams } from "react-router-dom";

import { DoctorInfoCard } from "components/DoctorCart";
import { PagedListWrapper } from "components/PagedListWrapper";

import { useGetHospitalUnitDoctorsQuery } from "service/endpoints/HospitalUnitsEndpoints";

import { searchParamsToObject } from "utils/searchParamsToObject";

import styles from "./UnitDoctors.module.scss";

export const UnitDoctors = () => {
  const { unitName } = useParams();
  const [searchParams] = useSearchParams();
  const { data, isLoading, isFetching, error } = useGetHospitalUnitDoctorsQuery(
    {
      unitName: unitName ?? "",
      searchParams: searchParamsToObject(searchParams),
    }
  );

  return (
    <PagedListWrapper
      controlPanelProps={{
        searchPlaceholder: "Введіть ФІО лікаря",
      }}
      fetchResult={{ data, isLoading, isFetching, error }}
    >
      {data && (
        <ul className={styles.doctorsList}>
          {data.items.map((doctor) => (
            <li key={doctor.fullName}>
              <DoctorInfoCard doctor={doctor} />
            </li>
          ))}
        </ul>
      )}
    </PagedListWrapper>
  );
};
