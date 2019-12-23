// @ts-check

export function generateId() {
  return Math.random()
    .toString(36)
    .substr(2);
}

export function repaint(element) {
  // This is for to force a repaint,
  // which is necessary in order to transition styles when adding a class name.
  element.scrollTop;
}

export function debounce(func, wait = 166) {
  let timeout;
  function debounced(...args) {
    // eslint-disable-next-line consistent-this
    const that = this;
    const later = () => {
      func.apply(that, args);
    };
    clearTimeout(timeout);
    timeout = setTimeout(later, wait);
  }

  debounced.clear = () => {
    clearTimeout(timeout);
  };

  return debounced;
}

export function ownerDocument(node) {
  return node && node.ownerDocument || document;
}

export function goBack(depth) {
    setTimeout(() => history.go(depth), 2000);
}