// @ts-check

import { focusRadioGroup } from "../RadioGroupHelper/RadioGroupHelper";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Selection: {
      focusRadioGroup,
    },
  },
};
