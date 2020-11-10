// @ts-check

import { MenuListHelper } from "../MenuListHelper/MenuListHelper";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Menu: {
      MenuListHelper,
    },
  },
};
