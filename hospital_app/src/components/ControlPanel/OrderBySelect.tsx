import React, { useState } from "react";
import { useSearchParams } from "react-router-dom";

import { DropDown } from "components/Inputs/DropDown";
import { OrderOption } from "shared/types/OrderOptions";

interface Props {
  className: string;
  orderByOption: OrderOption[];
}

export const OrderBySelect = ({ orderByOption, className }: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();
  const [selectedOption, setSelectedOption] = useState(orderByOption[0].name);

  const onSelect = (option: OrderOption) => {
    searchParams.set("OrderBy", option.value);

    setSelectedOption(option.name);
    setSearchParams(searchParams);
  };

  return (
    <div className={className}>
      <label htmlFor="orderBy">Впорядкувати за</label>

      <DropDown value={selectedOption} type="button" name="orderBy">
        {orderByOption.map((option) => (
          <li key={option.name} onClick={() => onSelect(option)}>
            {option.name}
          </li>
        ))}
      </DropDown>
    </div>
  );
};
