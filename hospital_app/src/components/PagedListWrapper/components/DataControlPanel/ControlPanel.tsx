import React from "react";

import styles from "./styles.module.scss";
import { SearchInput } from "../Inputs/SearchInput";
import { SortOption } from "shared/types/SortOption";
import { SortOptionSelect } from "../Inputs/SortOptionSelect";

interface Props {
  dataSortingOptions?: SortOption[];
  searchPlaceholder?: string;
}

export const ControlPanel = ({
  dataSortingOptions,
  searchPlaceholder,
}: Props) => {
  return (
    <div className={styles.controlPanel}>
      {dataSortingOptions && (
        <SortOptionSelect sortOptions={dataSortingOptions} />
      )}

      <SearchInput placeholder={searchPlaceholder} />
    </div>
  );
};
