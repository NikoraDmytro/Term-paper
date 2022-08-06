import { SortOption } from "shared/types/SortOption";

export const sortOptions: SortOption[] = [
  {
    name: "Номер (зростання)",
    value: "number",
  },
  {
    name: "Номер (спадання)",
    value: "number desc",
  },
  {
    name: "Ліжко-місця (зростання)",
    value: "bedsQuantity",
  },
  {
    name: "Ліжко-місця (спадання)",
    value: "bedsQuantity desc",
  },
  {
    name: "Заповненість (зростання)",
    value: "occupancy",
  },
  {
    name: "Заповненість (спадання)",
    value: "occupancy desc",
  },
];
