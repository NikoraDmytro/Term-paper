import React from "react";
import { useSearchParams } from "react-router-dom";

import { Pagination } from "components/Pagination";

interface Props {
  totalPagesCount: number;
}

export const PagedListPagination = (props: Props) => {
  const [searchParams, setSearchParams] = useSearchParams();

  const currentPage = +(searchParams.get("PageNumber") ?? 1);

  const handlePageSelect = ({ selected }: { selected: number }) => {
    var pageNumber = selected + 1;

    searchParams.set("PageNumber", pageNumber.toString());

    setSearchParams(searchParams);
  };

  return (
    <Pagination
      currentPage={currentPage}
      handlePageChange={handlePageSelect}
      {...props}
    />
  );
};
