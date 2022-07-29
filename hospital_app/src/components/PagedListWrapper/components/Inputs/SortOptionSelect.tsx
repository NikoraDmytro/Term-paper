import React, { useState } from "react";
import { useSearchParams } from "react-router-dom";

import { DropDown } from "components/Inputs/DropDown";
import { SortOption } from "shared/types/SortOption";

import styles from "./SortOptionSelect.module.scss";

interface Props {
  sortOptions: SortOption[];
}

export const SortOptionSelect = ({ sortOptions }: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();
  const [selectedOption, setSelectedOption] = useState(sortOptions[0].name);

  const onSelect = (option: SortOption) => {
    searchParams.set("PageNumber", "1");
    searchParams.set("OrderBy", option.value);

    setSelectedOption(option.name);
    setSearchParams(searchParams);
  };

  return (
    <div className={styles.sortOptionSelect}>
      <label htmlFor="orderBy">Впорядкувати за:</label>

      <DropDown value={selectedOption} type="button" name="orderBy">
        {sortOptions.map((option) => (
          <li key={option.name} onClick={() => onSelect(option)}>
            {option.name}
          </li>
        ))}
      </DropDown>
    </div>
  );
};
