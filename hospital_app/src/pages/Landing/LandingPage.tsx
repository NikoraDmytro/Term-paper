import React from "react";
import { Link } from "react-router-dom";

import styles from "./styles.module.scss";
import { AppCarousel } from "./../../components/Carousel";

export const LandingPage = () => {
  return (
    <div className={styles.landing}>
      <div className={styles.caption}>
        <h1>Харківська обласна дитяча клінічна лікарня №1</h1>

        <p>
          Ми прагнемо бути милосердними, і радіємо, коли турбота наших лікарів
          повертає людям здоров'я
        </p>

        <Link to="/hospitalUnits">
          <button className={styles.goToUnitsButton}>
            Перейти у відділення
          </button>
        </Link>
      </div>

      <AppCarousel />
    </div>
  );
};
