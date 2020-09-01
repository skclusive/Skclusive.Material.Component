// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

export class HistoryBackHelper {
  static cache = {};

  static construct(node, name, delay) {
    const id = generateId();

    const callback = HistoryBackHelper.callback(id);

    HistoryBackHelper.cache[id] = {
      id,
      node,
      name,
      delay,
      callback,
    };

    HistoryBackHelper.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = HistoryBackHelper.cache[id];
    if (record) {
      const { node, name, callback } = record;
      node.addEventListener(name, callback);
    }
  }

  static callback(id) {
    return (e) => {
      e.preventDefault();
      e.stopPropagation();
      e.currentTarget.blur();
      const record = HistoryBackHelper.cache[id];
      if (record) {
        if (record.delay) {
          setTimeout(() => history.back(), record.delay);
        } else {
          history.back();
        }
      }
    };
  }

  static dispose(id) {
    const record = HistoryBackHelper.cache[id];
    if (record && record.callback) {
      const { node, name, callback } = record;
      node.removeEventListener(name, callback);
    }
    delete HistoryBackHelper.cache[id];
  }
}
