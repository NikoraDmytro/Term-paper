import React from "react";

import styles from "./styles.module.scss";
import { SearchInput } from "../Inputs/SearchInput";
import { SortOptionSelect } from "../Inputs/SortOptionSelect";
import { DataControlPanelProps } from "shared/types/DataControlPanelProps";
import { AsyncDataFilterSelector } from "../Inputs/AsyncDataFilterSelector";

export const ControlPanel = ({
  dataSortingOptions,
  searchPlaceholder,
  dataFilteringSelectors = [],
}: DataControlPanelProps) => {
  return (
    <div className={styles.controlPanel}>
      {dataSortingOptions && (
        <SortOptionSelect sortOptions={dataSortingOptions} />
      )}

      {dataFilteringSelectors.length !== 0 &&
        dataFilteringSelectors.map((filterSelectorProps) => (
          <AsyncDataFilterSelector key={filterSelectorProps.name} {...filterSelectorProps} />
        ))}

      <SearchInput placeholder={searchPlaceholder} />
    </div>
  );
};
