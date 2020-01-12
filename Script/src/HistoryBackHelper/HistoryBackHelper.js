// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

const eventPool = {};

export function registerHistoryBack(node, name, delay) {
  const id = generateId();
  let callback = eventCallback(id);
  node.addEventListener(name, callback);

  const dispose = () => node.removeEventListener(name, callback);

  eventPool[id] = { id, delay, dispose };

  return id;
}

function eventCallback(id) {
  return e => {
    e.preventDefault();
    e.stopPropagation();
    e.currentTarget.blur();
    const record = eventPool[id];
    if (record) {
      if (record.delay) {
        setTimeout(() => history.back(), record.delay);
      } else {
        history.back();
      }
    }
  };
}

export function unRegisterHistoryBack(id) {
  const record = eventPool[id];
  if (record && record.dispose) {
    record.dispose();
  }
  delete eventPool[id];
}
