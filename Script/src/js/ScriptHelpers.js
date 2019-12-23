// @ts-check

import { goBack } from "./ScriptUtils";
import { registerHistoryBack, unRegisterHistoryBack } from "./HistoryBackHelper";
import { getTranslateValue, setTranslateValue } from "./Slide";
import { registerEvent, unRegisterEvent } from "./EventDelegator";
import { initTrapFocus, disposeTrapFocus } from "./TrapFocus";
import { registerMediaQuery, unRegisterMediaQuery } from "./MediaQueryMatcher";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Script: {
      goBack,
      getTranslateValue,
      setTranslateValue,
      registerEvent,
      unRegisterEvent,
      initTrapFocus,
      disposeTrapFocus,
      registerMediaQuery,
      unRegisterMediaQuery,
      registerHistoryBack,
      unRegisterHistoryBack
    }
  }
};
