// @ts-check

import {
  generateId,
  ownerDocument,
  addClasses,
  removeClasses,
} from "./DomHelpers";

export class MenuListHelper {
  static cache = {};

  static construct(list, disableListWrap) {
    const id = generateId();

    const callback = MenuListHelper.callback(id);

    const textCriteria = {
      keys: [],
      repeating: true,
      previousKeyMatched: true,
      lastTime: null,
    };

    MenuListHelper.cache[id] = {
      id,
      list,
      textCriteria,
      disableListWrap,
      callback,
    };

    MenuListHelper.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = MenuListHelper.cache[id];
    if (record) {
      document.addEventListener("keydown", record.callback);
    }
  }

  static callback(id) {
    return (event) => {
      const record = MenuListHelper.cache[id];
      const { list, disableListWrap, textCriteria } = record;
      const key = event.key;
      /**
       * @type {Element} - will always be defined since we are in a keydown handler
       * attached to an element. A keydown event is either dispatched to the activeElement
       * or document.body or document.documentElement. Only the first case will
       * trigger this specific handler.
       */
      const currentFocus = ownerDocument(list).activeElement;

      if (key === "ArrowDown") {
        event.preventDefault();
        moveFocus(id, list, currentFocus, disableListWrap, nextItem);
      } else if (key === "ArrowUp") {
        event.preventDefault();
        moveFocus(id, list, currentFocus, disableListWrap, previousItem);
      } else if (key === "Home") {
        event.preventDefault();
        moveFocus(id, list, null, disableListWrap, nextItem);
      } else if (key === "End") {
        event.preventDefault();
        moveFocus(id, list, null, disableListWrap, previousItem);
      } else if (key.length === 1) {
        const criteria = textCriteria;
        const lowerKey = key.toLowerCase();
        const currTime = performance.now();
        if (criteria.keys.length > 0) {
          // Reset
          if (currTime - criteria.lastTime > 500) {
            criteria.keys = [];
            criteria.repeating = true;
            criteria.previousKeyMatched = true;
          } else if (criteria.repeating && lowerKey !== criteria.keys[0]) {
            criteria.repeating = false;
          }
        }
        criteria.lastTime = currTime;
        criteria.keys.push(lowerKey);
        const keepFocusOnCurrent =
          currentFocus &&
          !criteria.repeating &&
          textCriteriaMatches(currentFocus, criteria);
        if (
          criteria.previousKeyMatched &&
          (keepFocusOnCurrent ||
            moveFocus(id, list, currentFocus, false, nextItem, criteria))
        ) {
          event.preventDefault();
        } else {
          criteria.previousKeyMatched = false;
        }
      }
    };
  }

  static dispose(id) {
    const record = MenuListHelper.cache[id];
    if (record && record.callback) {
      document.removeEventListener("keydown", record.callback);
    }
    delete MenuListHelper.cache[id];
  }
}

function nextItem(list, item, disableListWrap) {
  if (list === item) {
    return list.firstElementChild;
  }
  if (item && item.nextElementSibling) {
    return item.nextElementSibling;
  }
  return disableListWrap ? null : list.firstElementChild;
}

function previousItem(list, item, disableListWrap) {
  if (list === item) {
    return disableListWrap ? list.firstElementChild : list.lastElementChild;
  }
  if (item && item.previousElementSibling) {
    return item.previousElementSibling;
  }
  return disableListWrap ? null : list.lastElementChild;
}

function textCriteriaMatches(nextFocus, textCriteria) {
  if (textCriteria === undefined) {
    return true;
  }
  let text = nextFocus.innerText;
  if (text === undefined) {
    // jsdom doesn't support innerText
    text = nextFocus.textContent;
  }
  if (text === undefined) {
    return false;
  }
  text = text.trim().toLowerCase();
  if (text.length === 0) {
    return false;
  }
  if (textCriteria.repeating) {
    return text[0] === textCriteria.keys[0];
  }
  return text.indexOf(textCriteria.keys.join("")) === 0;
}

function doFocus(id, element) {
  const record = MenuListHelper.cache[id];
  const { list, lastFocused = list.querySelector(".ListItem-FocusVisible") } = record;
  element.focus();
  addClasses(element, ["ListItem-FocusVisible"]);
  if (lastFocused) {
    removeClasses(lastFocused, ["ListItem-FocusVisible"]);
  }
  record.lastFocused = element;
}

function moveFocus(
  id,
  list,
  currentFocus,
  disableListWrap,
  traversalFunction,
  textCriteria
) {
  let wrappedOnce = false;
  let nextFocus = traversalFunction(
    list,
    currentFocus,
    currentFocus ? disableListWrap : false
  );

  while (nextFocus) {
    // Prevent infinite loop.
    if (nextFocus === list.firstElementChild) {
      if (wrappedOnce) {
        return false;
      }
      wrappedOnce = true;
    }
    // Move to the next element.
    if (
      !nextFocus.hasAttribute("tabindex") ||
      nextFocus.disabled ||
      nextFocus.getAttribute("aria-disabled") === "true" ||
      !textCriteriaMatches(nextFocus, textCriteria)
    ) {
      nextFocus = traversalFunction(list, nextFocus, disableListWrap);
    } else {
      // nextFocus.focus();
      doFocus(id, nextFocus);
      return true;
    }
  }

  return false;
}