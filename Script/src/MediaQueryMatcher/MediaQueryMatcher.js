// @ts-check

import { generateId } from "../DomHelpers/DomHelpers";

const eventPool = {};

export function registerMediaQuery(query, target) {
  const id = generateId();

  query = query.replace(/^@media( ?)/m, '');

  const queryList = window.matchMedia(query);

  const callback = eventCallback(id);

  queryList.addListener(callback);

  const dispose = () => queryList.removeListener(callback);

  eventPool[id] = { id, queryList, target, dispose };

  setTimeout(callback);

  return id;
}

function eventCallback(id) {
  return e => {
    const record = eventPool[id];
    if (record && record.target) {
      record.target.invokeMethodAsync(
        'OnChangeAsync',
        !!record.queryList.matches
      );
    }
  };
}

export function unRegisterMediaQuery(id) {
  const record = eventPool[id];
  if (record && record.dispose) {
    record.dispose();
  }
  delete eventPool[id];
}
