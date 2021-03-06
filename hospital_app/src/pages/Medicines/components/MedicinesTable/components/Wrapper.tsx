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
import { OrderOption } from "shared/types/OrderOptions";
import { ErrorComponent } from "components/ErrorComponent";

interface Props {
  children: (data: IMedicine[]) => React.ReactNode;
}

const orderBy: OrderOption[] = [
  {
    name: "Назва [а-я]",
    value: "Name",
  },
  {
    name: "Назва [я-а]",
    value: "Name desc",
  },
  {
    name: "Кількість (зростання)",
    value: "Quantity",
  },
  {
    name: " Кількість (спадання)",
    value: "Quantity desc",
  },
];

export const Wrapper = (props: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();

  let { data, isLoading, error } = useGetAllMedicinesQuery(
    searchParamsToObject(searchParams)
  );

  const setPageNumber = (pageNumber: number) => {
    searchParams.set("PageNumber", pageNumber.toString());

    setSearchParams(searchParams);
  };

  error = error as FetchBaseQueryError;

  return (
    <>
      <ControlPanel searchPlaceholder="Введіть назву ліків" orderBy={orderBy} />

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

      <ErrorComponent error={error} />
    </>
  );
};
