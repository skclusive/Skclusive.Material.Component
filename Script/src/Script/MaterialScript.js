// @ts-check

import { HistoryBackHelper } from "../HistoryBackHelper/HistoryBackHelper";
import { EventDelegator } from "../EventDelegator/EventDelegator";
import { MediaQueryMatcher } from "../MediaQueryMatcher/MediaQueryMatcher";
import { ThemeDetector } from "../ThemeDetector/ThemeDetector";

// @ts-ignore
window.Skclusive = {
  // @ts-ignore
  ...window.Skclusive,
  Material: {
    // @ts-ignore
    ...(window.Skclusive || {}).Material,
    Script: {
      EventDelegator,
      MediaQueryMatcher,
      HistoryBackHelper,
      ThemeDetector,
    },
  },
};
