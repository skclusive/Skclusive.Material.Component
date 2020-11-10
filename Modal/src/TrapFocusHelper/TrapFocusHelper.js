// @ts-check

import { generateId, ownerDocument } from "./DomHelpers";

export class TrapFocusHelper {
  static cache = {};

  static construct(
    node,
    disableAutoFocus,
    disableRestoreFocus,
    disableEnforceFocus,
    isEnabled
  ) {
    const id = generateId();

    const lastActiveElement = document.activeElement;

    const doc = ownerDocument(node);

    TrapFocusHelper.cache[id] = {
      id,
      node,
      doc,
      disableAutoFocus,
      disableRestoreFocus,
      disableEnforceFocus,
      isEnabled,
      lastActiveElement,
    };

    TrapFocusHelper.initialize(id);

    return id;
  }

  static initialize(id) {
    const record = TrapFocusHelper.cache[id];
    if (record) {
      const {
        node,
        doc,
        disableAutoFocus,
        disableEnforceFocus,
        isEnabled,
      } = record;
      let ignoreNextEnforceFocus = false;
      // We might render an empty child.
      if (!disableAutoFocus && node && !node.contains(doc.activeElement)) {
        if (!node.hasAttribute("tabIndex")) {
          node.setAttribute("tabIndex", -1);
        }
        node.focus();
      }

      const contain = () => {
        if (disableEnforceFocus || !isEnabled || ignoreNextEnforceFocus) {
          ignoreNextEnforceFocus = false;
          return;
        }

        if (node && !node.contains(doc.activeElement)) {
          // @ts-ignore
          node.focus();
        }
      };

      const loopFocus = (event) => {
        // 9 = Tab
        if (disableEnforceFocus || !isEnabled || event.keyCode !== 9) {
          return;
        }

        // Make sure the next tab starts from the right place.
        // @ts-ignore
        if (doc.activeElement === rootRef.current) {
          // We need to ignore the next contain as
          // it will try to move the focus back to the rootRef element.
          // @ts-ignore
          ignoreNextEnforceFocus = true;
          if (event.shiftKey) {
            // @ts-ignore
            sentinelEnd.current.focus();
          } else {
            // @ts-ignore
            sentinelStart.current.focus();
          }
        }
      };

      doc.addEventListener("focus", contain, true);
      doc.addEventListener("keydown", loopFocus, true);

      // With Edge, Safari and Firefox, no focus related events are fired when the focused area stops being a focused area
      // e.g. https://bugzilla.mozilla.org/show_bug.cgi?id=559561.
      //
      // The whatwg spec defines how the browser should behave but does not explicitly mention any events:
      // https://html.spec.whatwg.org/multipage/interaction.html#focus-fixup-rule.
      const interval = setInterval(() => {
        contain();
      }, 50);

      Object.assign(record, { interval, contain, loopFocus });
    }
  }

  static dispose(id) {
    const record = TrapFocusHelper.cache[id];
    if (record) {
      const {
        doc,
        interval,
        contain,
        loopFocus,
        lastActiveElement,
        disableRestoreFocus,
      } = record;
      clearInterval(interval);
      doc.removeEventListener("focus", contain, true);
      doc.removeEventListener("keydown", loopFocus, true);

      if (!disableRestoreFocus && lastActiveElement) {
        // @ts-ignore
        lastActiveElement.focus();
      }
    }
    delete TrapFocusHelper.cache[id];
  }
}
