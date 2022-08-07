import React from "react";
import { useSearchParams } from "react-router-dom";

import { sortOptions } from "./sortOptions";
import { filterOptions } from "./filterOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllPatientsQuery } from "service/endpoints/PatientsEndpoints";

import { PagedListWrapper } from "components/PagedListWrapper";

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
        <ul>
          {data.items.map((patient) => (
            <li key={patient.fullName}>{patient.fullName}</li>
          ))}
        </ul>
      )}
    </PagedListWrapper>
  );
};
