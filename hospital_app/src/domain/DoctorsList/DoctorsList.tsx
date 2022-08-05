import React from "react";
import { useSearchParams } from "react-router-dom";

import { PagedListWrapper } from "components/PagedListWrapper";

import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllDoctorsQuery } from "service/endpoints/DoctorsEndpoint";

export const DoctorsList = () => {
  const [searchParams] = useSearchParams();

  const { data, isLoading, isFetching, error } = useGetAllDoctorsQuery(
    searchParamsToObject(searchParams)
  );

  return (
    <PagedListWrapper
      controlPanelProps={{
        searchPlaceholder: "Введіть ФІО лікаря",
      }}
      fetchResult={{ data, isLoading, isFetching, error }}
    >
      <ul>
        {data &&
          data.items.map((doctor) => (
            <li key={doctor.fullName}>{doctor.fullName}</li>
          ))}
      </ul>
    </PagedListWrapper>
  );
};
