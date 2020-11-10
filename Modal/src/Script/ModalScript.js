// @ts-check

import { TrapFocusHelper } from "../TrapFocusHelper/TrapFocusHelper";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Modal: {
      TrapFocusHelper,
    },
  },
};
