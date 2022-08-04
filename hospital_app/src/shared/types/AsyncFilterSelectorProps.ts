export type AsyncFilterSelectorProps = {
  name: string;
  label: string;
  request: (input: string) => Promise<string[]>;
};
