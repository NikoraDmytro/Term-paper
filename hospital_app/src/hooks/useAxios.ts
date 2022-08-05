import { useEffect, useState } from "react";

export const useAxios = <TReturn>(
  loadData: (values: any) => Promise<TReturn>,
  values?: any[]
) => {
  const [loading, setLoading] = useState(false);
  const [data, setData] = useState<TReturn | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setData(null);
        setLoading(true);

        const response = await loadData(values);

        setError(null);
        setData(response);
      } catch (err) {
        setError((err as Error).message ?? "Внутрішня помилка сервера!");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [values, loadData]);

  return { data, loading, error };
};
