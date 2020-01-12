// @ts-check

function onScript(func, ...args) {
  // @ts-ignore
  const { DomHelpers } = window.Skclusive.Script;
  return DomHelpers[func].apply(null, args);
}

export function generateId(...args) {
  return onScript("generateId", ...args);
}

export function repaint(...args) {
  return onScript("repaint", ...args);
}

export function debounce(...args) {
  return onScript("debounce", ...args);
}

export function ownerDocument(...args) {
  return onScript("ownerDocument", ...args);
}

export function ownerWindow(...args) {
  return onScript("ownerWindow", ...args);
}

export function goBack(...args) {
  return onScript("goBack", ...args);
}

export function getScrollParent(...args) {
  return onScript("getScrollParent", ...args);
}

export function addClasses(...args) {
  return onScript("addClasses", ...args);
}

export function removeClasses(...args) {
  return onScript("removeClasses", ...args);
}