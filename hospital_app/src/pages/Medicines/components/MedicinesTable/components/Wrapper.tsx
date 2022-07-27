import React from "react";
import { useSearchParams } from "react-router-dom";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

import { Loader } from "components/Loader";
import { IMedicine } from "models/IMedicine";
import { useGetAllMedicinesQuery } from "service/HospitalService";
import { searchParamsToObject } from "utils/searchParamsToObject";

import styles from "./Wrapper.module.scss";

interface Props {
  children: (data: IMedicine[]) => React.ReactNode;
}

export const Wrapper = (props: Props) => {
  const [searchParams] = useSearchParams();

  let { data, isLoading, isError, error } = useGetAllMedicinesQuery(
    searchParamsToObject(searchParams)
  );

  error = error as FetchBaseQueryError;

  return (
    <>
      <h1 className={styles.title}>
        Наявність лікарських засобів та виробів медичного призначення
      </h1>

      {data && props.children(data)}

      {isLoading && (
        <div className={styles.spinnerContainer}>
          <Loader />
        </div>
      )}

      {isError && error && (
        <div className={styles.error}>
          <h1>{error.status}</h1>
          <h2>
            {error.data ? JSON.stringify(error.data) : "Помилка сервера!"}
          </h2>
        </div>
      )}
    </>
  );
};
