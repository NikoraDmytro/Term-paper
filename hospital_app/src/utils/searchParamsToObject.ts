export const searchParamsToObject = (searchParams: URLSearchParams) => {
  const object: Record<string, string> = {};

  searchParams.forEach((value, key) => {
    object[key] = value;
  });

  return object;
};
