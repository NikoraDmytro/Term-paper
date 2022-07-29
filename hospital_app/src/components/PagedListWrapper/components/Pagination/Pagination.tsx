import React from "react";
import ReactPaginate from "react-paginate";

import styles from "./styles.module.scss";
import { useSearchParams } from "react-router-dom";

interface Props {
  totalPagesCount: number;
}

type handlePageClickEvent = {
  selected: number;
};

export const Pagination = ({ totalPagesCount }: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();

  const handlePageChange = ({ selected }: handlePageClickEvent) => {
    var pageNumber = selected + 1;

    searchParams.set("PageNumber", pageNumber.toString());

    setSearchParams(searchParams);
  };

  const currentPage = +(searchParams.get("PageNumber") ?? 1);

  return (
    <ReactPaginate
      breakLabel="..."
      nextLabel=">"
      previousLabel="<"
      forcePage={currentPage - 1}
      activeClassName={styles.active}
      disabledClassName={styles.disabled}
      pageClassName={styles.page}
      nextClassName={styles.nextLabel}
      previousClassName={styles.prevLabel}
      breakClassName={styles.breakLabel}
      containerClassName={styles.container}
      onPageChange={handlePageChange}
      pageRangeDisplayed={5}
      pageCount={totalPagesCount}
    />
  );
};
