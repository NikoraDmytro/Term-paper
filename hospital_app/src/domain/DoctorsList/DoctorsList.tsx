import React from "react";
import { useSearchParams } from "react-router-dom";

import { PagedListWrapper } from "components/PagedListWrapper";

import { getHospitalUnitsNames } from "api/api";
import { sortingOptions } from "./sortingOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllDoctorsQuery } from "service/endpoints/DoctorsEndpoint";

import doctorImg from "./img/doctor.png";

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
            <li className={styles.doctorCard} key={doctor.fullName}>
              <img className={styles.doctorImage} src={doctorImg} alt="Ooops" />

              <div className={styles.doctorInfoBlock}>
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
              </div>
            </li>
          ))}
      </ul>
    </PagedListWrapper>
  );
};
