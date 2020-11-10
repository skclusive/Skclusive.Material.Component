// @ts-check

function onScript(func, ...args) {
  // @ts-ignore
  const { DomHelpers } = window.Skclusive.Script;
  return DomHelpers[func].apply(null, args);
}

export function getScrollParent(...args) {
  return onScript("getScrollParent", ...args);
}

export function ownerDocument(...args) {
  return onScript("ownerDocument", ...args);
}

export function ownerWindow(...args) {
  return onScript("ownerWindow", ...args);
}
