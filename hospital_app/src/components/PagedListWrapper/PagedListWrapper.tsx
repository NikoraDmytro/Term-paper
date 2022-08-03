import React from "react";
import { SerializedError } from "@reduxjs/toolkit";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

import { Loader } from "components/Loader";
import { Pagination } from "./components/Pagination";
import { ErrorComponent } from "components/ErrorComponent";
import { ControlPanel } from "./components/DataControlPanel";

import { DataControlPanelProps } from "shared/types/DataControlPanelProps";
import { IPagedList } from "models/IPagedList";

import styles from "./styles.module.scss";

type FetchResult = {
  data?: IPagedList<any>;
  isLoading: boolean;
  isFetching: boolean;
  error: FetchBaseQueryError | SerializedError | undefined;
};

interface Props {
  title?: string;
  fetchResult: FetchResult;
  children: React.ReactNode;
  controlPanelProps: DataControlPanelProps;
}

export const PagedListWrapper = (props: Props) => {
  const { isLoading, isFetching, data, error } = props.fetchResult;

  return (
    <>
      <ControlPanel {...props.controlPanelProps} />

      <h1 className={styles.title}>{props.title ?? null}</h1>

      {data?.pagesQuantity != null && (
        <Pagination totalPagesCount={data.pagesQuantity} />
      )}
      {!isLoading && isFetching && <Loader small />}

      {props.children}

      {data?.items.length === 0 && (
        <h1 className={styles.noData}>Список порожній!</h1>
      )}

      {isLoading && <Loader />}

      <ErrorComponent error={error} />
    </>
  );
};
