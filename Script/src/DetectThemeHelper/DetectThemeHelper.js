// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

const eventPool = {};

const colorSchemes = {
  Dark: "(prefers-color-scheme: dark)",
  Light: "(prefers-color-scheme: light)",
  None: "(prefers-color-scheme: no-preference)"
};

export function registerDetectTheme(target) {
  const id = generateId();

  const listener = eventCallback(id);

  const activeMatches = [];
  Object.keys(colorSchemes).forEach(schemeName => {
    const mq = window.matchMedia(colorSchemes[schemeName]);
    mq.addListener(listener);
    activeMatches.push(mq);
    setTimeout(() => listener(mq));
  });

  const dispose = () => {
    activeMatches.forEach(mq => mq.removeListener(listener));
    activeMatches.length = 0;
  };

  eventPool[id] = { id, target, dispose };

  return id;
}

function eventCallback(id) {
  return e => {
    if (!e || !e.matches) {
      return;
    }
    const record = eventPool[id];
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

export function unRegisterDetectTheme(id) {
  const record = eventPool[id];
  if (record && record.dispose) {
    record.dispose();
  }
  delete eventPool[id];
}
