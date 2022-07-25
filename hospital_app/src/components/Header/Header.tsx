import React from "react";
import classNames from "classnames";
import { NavLink } from "react-router-dom";

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
      <img src={logo} alt="Logo" className={styles.logo} />

      <nav className={styles.navBar}>
        <ul>
          <NavBarLink href="/" text="Відділення" />
          <NavBarLink href="/a" text="Лікарі" />
          <NavBarLink href="/b" text="Пацієнти" />
          <NavBarLink href="/c" text="Склад медикаментів" />
          <NavBarLink href="/d" text="База хвороб" />
        </ul>
      </nav>
    </header>
  );
};
