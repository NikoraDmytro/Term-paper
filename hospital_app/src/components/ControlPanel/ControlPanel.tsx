import React from "react";

import styles from "./styles.module.scss";
import { SearchInput } from "../Inputs/SearchInput";

interface Props {
  searchPlaceholder?: string;
}

export const ControlPanel = (props: Props) => {
  return (
    <div className={styles.controlPanel}>
      <SearchInput placeholder={props.searchPlaceholder} />
    </div>
  );
};
