import React from "react";
import { useSearchParams } from "react-router-dom";

import { TableRow } from "./components/TableRow";
import { PagedListWrapper } from "components/PagedListWrapper";

import { medicinesSortOptions } from "./medicinesSortOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetAllMedicinesQuery } from "service/endpoints/MedicinesEndpoints";

import styles from "./styles.module.scss";

export const MedicinesTable = () => {
  const [searchParams] = useSearchParams();

  let { data, isFetching, isLoading, error } = useGetAllMedicinesQuery(
    searchParamsToObject(searchParams)
  );

  return (
    <PagedListWrapper
      title="Наявність лікарських засобів та виробів медичного призначення"
      fetchResult={{
        data,
        error,
        isLoading,
        isFetching,
      }}
      controlPanelProps={{
        searchPlaceholder: "Введіть назву ліків",
        dataSortingOptions: medicinesSortOptions,
      }}
    >
      <table className={styles.medicinesTable}>
        <thead>
          <tr>
            <th>Назва</th>
            <th>Кількість</th>
            <th></th>
          </tr>
        </thead>

        <tbody>
          {data &&
            data.items.map((medicine, index) => (
              <TableRow key={index} medicine={medicine} />
            ))}
        </tbody>
      </table>
    </PagedListWrapper>
  );
};
