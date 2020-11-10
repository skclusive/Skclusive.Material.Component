// @ts-check

import {
  getSlideTranslateValue,
  setSlideTranslateValue,
} from "../SlideHelper/SlideHelper";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Transition: {
      getSlideTranslateValue,
      setSlideTranslateValue,
    },
  },
};
