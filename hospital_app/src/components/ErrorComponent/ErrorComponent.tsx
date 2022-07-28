import React from "react";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";
import { SerializedError } from "@reduxjs/toolkit";

import styles from "./styles.module.scss";

interface Props {
  error: FetchBaseQueryError | SerializedError | undefined;
}

export const ErrorComponent = ({ error }: Props) => {
  if (!error) return null;

  if ("status" in error) {
    let errorName;

    switch (error.status) {
      case 400:
        errorName = "Поганий запит";
        break;
      case 404:
        errorName = "Не знайдено";
        break;
      default:
        errorName = "Внутрішня помилка сервера";
    }

    let errMsg;

    if (error.data) {
      const errorData = error.data as any;

      if ("message" in errorData) {
        errMsg = errorData.message;
      } else {
        errMsg = JSON.stringify(errorData);
      }
    }

    return (
      <div className={styles.error}>
        <h1>
          {error.status ?? "500"} {errorName}
        </h1>
        <h2>{errMsg}</h2>
      </div>
    );
  }

  return (
    <div className={styles.error}>
      <h1>
        {error.code ?? "500"} {error.name ?? "Внутрішня помилка сервера"}
      </h1>
      <h2>{error.message ?? ""}</h2>
    </div>
  );
};
