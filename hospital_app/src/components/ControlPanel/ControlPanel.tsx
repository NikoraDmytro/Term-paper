import React from "react";

import styles from "./styles.module.scss";
import { SearchInput } from "../Inputs/SearchInput";
import { OrderOption } from "shared/types/OrderOptions";
import { OrderBySelect } from "./OrderBySelect";

interface Props {
  orderBy?: OrderOption[];
  searchPlaceholder?: string;
}

export const ControlPanel = ({ orderBy, searchPlaceholder }: Props) => {
  return (
    <div className={styles.controlPanel}>
      {orderBy && (
        <OrderBySelect
          orderByOption={orderBy}
          className={styles.orderBySelect}
        />
      )}

      <SearchInput placeholder={searchPlaceholder} />
    </div>
  );
};
