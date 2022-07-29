import { DataFilteringSelectorProps } from "./DataFilteringSelectorProps";
import { SortOption } from "./SortOption";

export type DataControlPanelProps = {
  searchPlaceholder?: string;
  dataSortingOptions?: SortOption[];
  DataFilteringSelectors?: DataFilteringSelectorProps[];
};
