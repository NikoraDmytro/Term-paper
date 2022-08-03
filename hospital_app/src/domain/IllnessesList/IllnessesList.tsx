import React from "react";
import { useSearchParams, Link } from "react-router-dom";

import { searchParamsToObject } from "utils/searchParamsToObject";

import { sortingOptions } from "./sortingOptions";
import { PagedListWrapper } from "components/PagedListWrapper";
import { useGetIllnessesNamesQuery } from "service/endpoints/IllnessesEndpoints";

import styles from "./styles.module.scss";

const getFirstLetter = (str: string) => {
  return str.charAt(0).toUpperCase();
};

export const IllnessesList = () => {
  const [searchParams] = useSearchParams();

  const { data, isLoading, isFetching, error } = useGetIllnessesNamesQuery(
    searchParamsToObject(searchParams)
  );

  return (
    <PagedListWrapper
      fetchResult={{ data, isFetching, isLoading, error }}
      controlPanelProps={{
        searchPlaceholder: "Введіть назву хвороби",
        dataSortingOptions: sortingOptions,
      }}
    >
      <ul className={styles.alphabeticalList}>
        {data &&
          data.items.map((name, index) => {
            const prev = data.items[index - 1] ?? "";
            const firstLetter = getFirstLetter(name);

            return (
              <>
                {getFirstLetter(prev) !== firstLetter && (
                  <li key={firstLetter}>
                    <h2>{firstLetter}</h2>
                  </li>
                )}

                <li key={name}>
                  <Link to={name}>{name}</Link>
                </li>
              </>
            );
          })}
      </ul>
    </PagedListWrapper>
  );
};
