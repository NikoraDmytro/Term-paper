import React from "react";
import { useState } from "react";

import { Loader } from "components/Loader/Loader";
import { Pagination } from "components/Pagination";
import { DoctorInfoCard } from "components/DoctorCart";
import { ErrorComponent } from "components/ErrorComponent";

import { useGetHospitalUnitDoctorsQuery } from "service/endpoints/HospitalUnitsEndpoints";

import styles from "./UnitDoctors.module.scss";

interface Props {
  unitName: string;
}

export const UnitDoctors = ({ unitName }: Props) => {
  const [pageNumber, setPageNumber] = useState(1);
  const { data, isLoading, error } = useGetHospitalUnitDoctorsQuery({
    unitName: unitName,
    searchParams: {
      PageSize: "3",
      PageNumber: pageNumber.toString(),
    },
  });

  const handlePageChange = ({ selected }: { selected: number }) => {
    setPageNumber(selected + 1);
  };

  return (
    <>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {data && (
        <>
          <Pagination
            currentPage={pageNumber}
            handlePageChange={handlePageChange}
            totalPagesCount={data.pagesQuantity}
          />
          <ul className={styles.doctorsList}>
            {data.items.map((doctor) => (
              <li key={doctor.fullName}>
                <DoctorInfoCard doctor={doctor} />
              </li>
            ))}
          </ul>
        </>
      )}
    </>
  );
};
