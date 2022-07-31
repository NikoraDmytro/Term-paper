import React from "react";
import { SerializedError } from "@reduxjs/toolkit";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

import classNames from "classnames";

import styles from "./styles.module.scss";

interface Props {
  inline?: boolean;
  error: FetchBaseQueryError | SerializedError | undefined;
}

export const ErrorComponent = ({ error, inline }: Props) => {
  if (!error) return null;

  const errorClass = classNames([styles.error], {
    [styles.errorInline]: inline,
  });

  if ("status" in error) {
    let errorName;

    switch (error.status) {
      case 400:
        errorName = "Поганий запит!";
        break;
      case 404:
        errorName = "Не знайдено!";
        break;
      case 422:
        errorName = "Не підлягає обробці";
        break;
      default:
        errorName = "Внутрішня помилка сервера!";
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
      <div className={errorClass}>
        <h1>
          {error.status ?? "500"} {errorName}
        </h1>
        <h2>{errMsg}</h2>
      </div>
    );
  }

  return (
    <div className={errorClass}>
      <h1>
        {error.code ?? "500"} {error.name ?? "Внутрішня помилка сервера"}
      </h1>
      <h2>{error.message ?? ""}</h2>
    </div>
  );
};
