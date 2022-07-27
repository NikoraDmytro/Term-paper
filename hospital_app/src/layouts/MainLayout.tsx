import React from "react";
import { Outlet } from "react-router-dom";

import styles from "./styles.module.scss";
import { innerLink } from "shared/types/InnerLink";
import { InnerNavigation } from "components/InnerNavigation";

interface Props {
  innerLinks?: innerLink[];
}

export const MainLayout = ({ innerLinks }: Props) => {
  return (
    <main className={styles.mainContainer}>
      {innerLinks && <InnerNavigation innerLinks={innerLinks} />}

      <Outlet />
    </main>
  );
};
