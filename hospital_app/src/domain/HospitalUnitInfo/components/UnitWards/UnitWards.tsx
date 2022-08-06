import React from "react";
import { useSearchParams } from "react-router-dom";

import { WardInfoBlock } from "./WardInfoBlock";
import { PagedListWrapper } from "components/PagedListWrapper";

import { sortOptions } from "./sortOptions";
import { searchParamsToObject } from "utils/searchParamsToObject";
import { useGetHospitalUnitWardsQuery } from "service/endpoints/HospitalUnitsEndpoints";

import styles from "./UnitWards.module.scss";

interface Props {
  unitName: string;
}

export const UnitWards = ({ unitName }: Props) => {
  const [searchParams] = useSearchParams();
  const { data, isLoading, isFetching, error } = useGetHospitalUnitWardsQuery({
    unitName: unitName,
    searchParams: searchParamsToObject(searchParams),
  });

  return (
    <PagedListWrapper
      controlPanelProps={{
        searchPlaceholder: "Введіть номер палати",
        dataSortingOptions: sortOptions,
      }}
      fetchResult={{ data, isLoading, isFetching, error }}
    >
      <ul className={styles.wardsList}>
        {data &&
          data.items.map((ward) => (
            <li key={ward.number}>
              <WardInfoBlock ward={ward} />
            </li>
          ))}
      </ul>
    </PagedListWrapper>
  );
};
