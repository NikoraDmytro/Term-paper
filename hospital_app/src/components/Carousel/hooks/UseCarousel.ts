import { useEffect, useState } from "react";

export const useCarousel = (images: string[]) => {
  const lastImage = images.slice(-1);
  const loopedList = [...lastImage, ...images];

  const [current, setCurrent] = useState(1);

  const loop = () => {
    setCurrent(0);

    setTimeout(() => {
      setCurrent(1);
    }, 10);
  };

  const next = () => {
    if (current === loopedList.length - 1) {
      loop();
      return;
    }

    setCurrent(current + 1);
  };

  useEffect(() => {
    const timeout = setTimeout(() => {
      next();
    }, 5000);

    return () => clearTimeout(timeout);
  });

  return { current, loopedList };
};
