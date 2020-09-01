// @ts-check

import { generateId, debounce } from '../DomHelpers/DomHelpers';

export class EventDelegator {
  static cache = {};

  static construct(node, name, target, delay) {
    const id = generateId();

    const source = node instanceof Element ? node : window;

    let callback = EventDelegator.callback(id);
    if (delay) {
      callback = debounce(callback, delay);
    }

    EventDelegator.cache[id] = {
      id,
      source,
      name,
      target,
      callback,
    };

    EventDelegator.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = EventDelegator.cache[id];
    if (record) {
      const { name, source, callback } = record;
      source.addEventListener(name, callback);
    }
  }

  static callback(id) {
    return (e) => {
      const record = EventDelegator.cache[id];
      if (record && record.target) {
        record.target.invokeMethodAsync('OnEventAsync', JSON.stringify(e));
      }
    };
  }

  static dispose(id) {
    const record = EventDelegator.cache[id];
    if (record && record.callback) {
      const { name, source, callback } = record;
      source.removeEventListener(name, callback);
    }
    delete EventDelegator.cache[id];
  }
}
