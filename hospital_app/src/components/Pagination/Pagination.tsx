import React from "react";
import ReactPaginate from "react-paginate";

import styles from "./styles.module.scss";

interface Props {
  currentPage: number;
  setPageNumber: (pageNumber: number) => void;
  totalPagesCount: number;
}

type handlePageClickEvent = {
  selected: number;
};

export const Pagination = ({
  totalPagesCount,
  currentPage,
  setPageNumber,
}: Props) => {
  const handlePageClick = (event: handlePageClickEvent) => {
    var pageNumber = event.selected + 1;

    setPageNumber(pageNumber);
  };

  return (
    <ReactPaginate
      breakLabel="..."
      nextLabel=">"
      forcePage={currentPage - 1}
      activeClassName={styles.active}
      disabledClassName={styles.disabled}
      pageClassName={styles.paginationItem}
      nextClassName={styles.paginationNext}
      previousClassName={styles.paginationPrev}
      containerClassName={styles.paginationContainer}
      onPageChange={handlePageClick}
      pageRangeDisplayed={5}
      pageCount={totalPagesCount}
      previousLabel="<"
    />
  );
};
