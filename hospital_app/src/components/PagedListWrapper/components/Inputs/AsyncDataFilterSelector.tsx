import React, { ChangeEvent, useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";

import { useAxios } from "hooks/useAxios";
import { AsyncFilterSelectorProps } from "shared/types/AsyncFilterSelectorProps";
import { DropDown } from "components/Inputs/DropDown";
import { Loader } from "components/Loader";

import styles from "./AsyncDataFilter.module.scss";

const toTitleCase = (str: string) => {
  return str.charAt(0).toUpperCase() + str.substr(1);
};

export const AsyncDataFilterSelector = (props: AsyncFilterSelectorProps) => {
  const [value, setValue] = useState("");
  const [searchParams, setSearchParams] = useSearchParams();

  const nameInTitleCase = toTitleCase(props.name);

  useEffect(() => {
    const search = searchParams.get(nameInTitleCase) ?? "";

    setValue(search);
  }, [searchParams, setValue, nameInTitleCase]);

  const { data, loading, error } = useAxios<string[]>(
    props.request,
    value as any
  );

  const selectOption = (option: string) => () => {
    searchParams.set(nameInTitleCase, option);

    setSearchParams(searchParams);
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setValue(e.target.value);
  };

  const handleBlur = () => {
    if (value === "") {
      searchParams.delete(nameInTitleCase);
    } else {
      searchParams.set(nameInTitleCase, value);
    }

    setSearchParams(searchParams);
  };

  const renderOption = (option: string) => (
    <li key={option} onClick={selectOption(option)}>
      {option}
    </li>
  );

  return (
    <div className={styles.filterSelect}>
      <label htmlFor={props.name}>{props.label}</label>

      <DropDown value={value} onChange={handleChange} onBlur={handleBlur}>
        {!loading && data && data.length ? (
          data.map(renderOption)
        ) : (
          <li>
            {loading && <Loader small />}
            {error && <p style={{ color: "red" }}>{error}</p>}
            {data && !data.length && <p>Нічого не знайдено!</p>}
          </li>
        )}
      </DropDown>
    </div>
  );
};
