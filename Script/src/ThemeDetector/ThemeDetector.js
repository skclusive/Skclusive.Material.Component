// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

const colorSchemes = {
  Dark: "(prefers-color-scheme: dark)",
  Light: "(prefers-color-scheme: light)",
  None: "(prefers-color-scheme: no-preference)"
};

export class ThemeDetector {
  static cache = {};

  static construct(target) {
    const id = generateId();

    const callback = ThemeDetector.callback(id);

    ThemeDetector.cache[id] = {
      id,
      target,
      callback,
    };

    ThemeDetector.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = ThemeDetector.cache[id];
    if (record) {
      const { callback } = record;
      const activeMatches = [];
      Object.keys(colorSchemes).forEach(schemeName => {
        const mq = window.matchMedia(colorSchemes[schemeName]);
        mq.addListener(callback);
        activeMatches.push(mq);
        setTimeout(() => callback(mq));
      });
      Object.assign(record, { activeMatches });
    }
  }

  static callback(id) {
    return (e) => {
      if (!e || !e.matches) {
        return;
      }
      const record = ThemeDetector.cache[id];
      if (record && record.target) {
        const schemeNames = Object.keys(colorSchemes);
        for (let i = 0; i < schemeNames.length; i++) {
          const schemeName = schemeNames[i];
          if (e.media === colorSchemes[schemeName]) {
            record.target.invokeMethodAsync(
              "OnChangeAsync",
              schemeName
            );
            break;
          }
        }
      }
    };
  }

  static dispose(id) {
    const record = ThemeDetector.cache[id];
    if (record) {
      const { callback, activeMatches } = record;
      activeMatches.forEach(mq => mq.removeListener(callback));
      activeMatches.length = 0;
    }
    delete ThemeDetector.cache[id];
  }
}