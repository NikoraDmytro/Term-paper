import React from "react";
import classNames from "classnames";
import { Link, useLocation } from "react-router-dom";

import styles from "./styles.module.scss";
import { innerLink } from "shared/types/InnerLink";

interface Props {
  innerLinks: innerLink[];
}

export const InnerNavigation = ({ innerLinks }: Props) => {
  const location = useLocation();

  return (
    <ul className={styles.navigationList}>
      {innerLinks.map((innerLink) => (
        <li className={styles.listItem}>
          <Link
            className={classNames({
              [styles.activeLink]: location.pathname.endsWith(innerLink.to),
            })}
            to={innerLink.to + (innerLink.searchParams ?? "")}
          >
            {innerLink.text}
          </Link>
        </li>
      ))}
    </ul>
  );
};
