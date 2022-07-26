import React from "react";
import { Link } from "react-router-dom";

import styles from "./styles.module.scss";
import image from "./backGroundImage.jpg";

export const NotFound = () => {
  return (
    <div className={styles.pageBody}>
      <img className={styles.backGroundImage} src={image} alt="" />

      <div className={styles.errorBlock}>
        <h1 className={styles.errorCode}>404</h1>

        <h2>Веб-сторінку не знайдено!</h2>

        <Link className={styles.linkToHome} to="/">
          <h2>
            Повернутися до <span>головної</span> сторінки
          </h2>
        </Link>
      </div>
    </div>
  );
};
