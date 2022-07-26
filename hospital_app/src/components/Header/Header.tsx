import React from "react";
import classNames from "classnames";
import { Link, NavLink } from "react-router-dom";

import styles from "./styles.module.scss";
import logo from "./logo.svg";

type NavLinkProps = {
  href: string;
  text: string;
};

const NavBarLink = (props: NavLinkProps) => {
  return (
    <li className={styles.navBarLink}>
      <NavLink
        className={({ isActive }) => classNames({ [styles.active]: isActive })}
        to={props.href}
      >
        {props.text}
      </NavLink>
    </li>
  );
};

export const Header = () => {
  return (
    <header className={styles.appHeader}>
      <Link to="/">
        <img src={logo} alt="Logo" className={styles.logo} />
      </Link>

      <nav className={styles.navBar}>
        <ul>
          <NavBarLink href="hospitalUnits" text="Відділення" />
          <NavBarLink href="doctors" text="Лікарі" />
          <NavBarLink href="patients" text="Пацієнти" />
          <NavBarLink href="medicines" text="Склад медикаментів" />
          <NavBarLink href="illnesses" text="База хвороб" />
        </ul>
      </nav>
    </header>
  );
};
