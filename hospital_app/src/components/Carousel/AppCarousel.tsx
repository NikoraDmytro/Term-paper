import React from "react";

import doctorImg from "./img/doctor.jpg";
import surgeryImg from "./img/surgery.jpg";
import laboratoryImg from "./img/laboratory.jpg";

import classNames from "classnames";
import styles from "./styles.module.scss";
import { useCarousel } from "./hooks/UseCarousel";

export const AppCarousel = () => {
  const images = [doctorImg, surgeryImg, laboratoryImg];

  const { current, loopedList } = useCarousel(images);

  const disableTransition = current === 0;

  return (
    <div className={styles.carouselContainer}>
      <div
        style={{ transform: `translateX(${current * -100}%)` }}
        className={classNames({
          [styles.carousel]: true,
          [styles.noTransition]: disableTransition,
        })}
      >
        {loopedList.map((image, index) => (
          <img key={index} src={image} alt="" />
        ))}
      </div>
    </div>
  );
};
