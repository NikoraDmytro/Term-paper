import { SortOption } from "./SortOption";
import { AsyncFilterSelectorProps } from "./AsyncFilterSelectorProps";

export type DataControlPanelProps = {
  searchPlaceholder?: string;
  dataSortingOptions?: SortOption[];
  dataFilteringSelectors?: AsyncFilterSelectorProps[];
};
