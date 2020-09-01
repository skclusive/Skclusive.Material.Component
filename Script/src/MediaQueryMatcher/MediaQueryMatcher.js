// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

export class MediaQueryMatcher {
  static cache = {};

  static construct(query, target) {
    const id = generateId();

  query = query.replace(/^@media( ?)/m, '');

    const callback = MediaQueryMatcher.callback(id);

    MediaQueryMatcher.cache[id] = {
      id,
      query,
      target,
      callback,
    };

    MediaQueryMatcher.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = MediaQueryMatcher.cache[id];
    if (record) {
      const { query, callback } = record;
      const queryList = window.matchMedia(query);
      queryList.addListener(callback);

      Object.assign(record, { queryList });

      setTimeout(callback);
    }
  }

  static callback(id) {
    return (e) => {
      const record = MediaQueryMatcher.cache[id];
      if (record && record.target) {
        record.target.invokeMethodAsync(
          'OnChangeAsync',
          !!record.queryList.matches
        );
      }
    };
  }

  static dispose(id) {
    const record = MediaQueryMatcher.cache[id];
    if (record && record.callback) {
      const { query, callback } = record;
      const queryList = window.matchMedia(query);
      queryList.removeListener(callback);
    }
    delete MediaQueryMatcher.cache[id];
  }
}