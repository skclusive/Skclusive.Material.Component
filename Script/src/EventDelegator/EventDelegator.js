// @ts-check

import { generateId, debounce } from '../DomHelpers/DomHelpers';

const eventPool = {};

export function registerEvent(node, name, target, delay) {
  const id = generateId();
  const source = node instanceof Element ? node : window;
  let callback = eventCallback(id);
  if (delay) {
    callback = debounce(callback, delay);
  }
  source.addEventListener(name, callback);

  const dispose = () => source.removeEventListener(name, callback);

  eventPool[id] = { id, source, target, dispose };

  return id;
}

function eventCallback(id) {
  return e => {
    const record = eventPool[id];
    if (record && record.target) {
      record.target.invokeMethodAsync('OnEventAsync', JSON.stringify(e));
    }
  };
}

export function unRegisterEvent(id) {
  const record = eventPool[id];
  if (record && record.dispose) {
    record.dispose();
  }
  delete eventPool[id];
}
