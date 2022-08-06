import React from "react";
import ReactPaginate from "react-paginate";

import styles from "./styles.module.scss";

interface Props {
  currentPage: number;
  totalPagesCount: number;
  handlePageChange: ({ selected }: { selected: number }) => void;
}

export const Pagination = (props: Props) =>
  props.totalPagesCount > 1 ? (
    <ReactPaginate
      breakLabel="..."
      nextLabel=">"
      previousLabel="<"
      forcePage={props.currentPage - 1}
      activeClassName={styles.active}
      disabledClassName={styles.disabled}
      pageClassName={styles.page}
      nextClassName={styles.nextLabel}
      previousClassName={styles.prevLabel}
      breakClassName={styles.breakLabel}
      containerClassName={styles.container}
      onPageChange={props.handlePageChange}
      pageRangeDisplayed={5}
      pageCount={props.totalPagesCount}
    />
  ) : null;
