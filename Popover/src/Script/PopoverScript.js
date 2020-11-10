// @ts-check

import {
  getContentAnchorOffset,
  getAnchorBoundry,
} from "../PopoverHelper/PopoverHelper";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Popover: {
      getContentAnchorOffset,
      getAnchorBoundry,
    },
  },
};
