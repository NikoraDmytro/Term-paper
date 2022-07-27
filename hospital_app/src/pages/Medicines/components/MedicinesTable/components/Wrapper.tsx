import React from "react";
import { useSearchParams } from "react-router-dom";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

import { Loader } from "components/Loader";
import { IMedicine } from "models/IMedicine";
import { ControlPanel } from "components/ControlPanel";
import { useGetAllMedicinesQuery } from "service/HospitalService";
import { searchParamsToObject } from "utils/searchParamsToObject";

import styles from "./Wrapper.module.scss";
import { Pagination } from "components/Pagination";

interface Props {
  children: (data: IMedicine[]) => React.ReactNode;
}

export const Wrapper = (props: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();

  let { data, isLoading, isError, error } = useGetAllMedicinesQuery(
    searchParamsToObject(searchParams)
  );

  const setPageNumber = (pageNumber: number) => {
    searchParams.set("PageNumber", pageNumber.toString());

    setSearchParams(searchParams);
  };

  error = error as FetchBaseQueryError;

  return (
    <>
      <ControlPanel searchPlaceholder="Введіть назву ліків" />

      <h1 className={styles.title}>
        Наявність лікарських засобів та виробів медичного призначення
      </h1>

      {data && (
        <>
          <Pagination
            totalPagesCount={data.pagesQuantity}
            currentPage={Number(searchParams.get("PageNumber")) ?? 1}
            setPageNumber={setPageNumber}
          />
          {props.children(data.medicines)}
        </>
      )}

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
