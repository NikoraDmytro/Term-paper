import React, { ChangeEvent } from "react";
import { useSearchParams } from "react-router-dom";

import styles from "./styles.module.scss";

interface Props {
  placeholder?: string;
}

export const SearchInput = (props: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();

  const search = searchParams.get("SearchTerm") ?? "";

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;

    if (value === "") {
      searchParams.delete("SearchTerm");
    } else {
      searchParams.set("SearchTerm", value);
    }

    setSearchParams(searchParams);
  };

  return (
    <div className={styles.search}>
      <label htmlFor="searchTerm">Пошук</label>

      <input
        type="search"
        name="searchTerm"
        value={search}
        placeholder={props.placeholder}
        onChange={handleChange}
      />
    </div>
  );
};
