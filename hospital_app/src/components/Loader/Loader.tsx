import classNames from "classnames";
import React from "react";

import styles from "./styles.module.scss";

interface Props {
  color?: string;
  small?: boolean;
}

export const Loader = ({ color, small }: Props) => {
  const className = classNames(styles.loader, {
    [styles.small]: small,
  });

  return <div style={{ color: color }} className={className}></div>;
};
