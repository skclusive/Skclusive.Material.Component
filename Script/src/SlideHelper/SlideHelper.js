// @ts-check

import { repaint } from '../DomHelpers/DomHelpers';

// Translate the node so he can't be seen on the screen.
// Later, we gonna translate back the node to his original location
// with `none`.`
export function getSlideTranslateValue(direction, node) {
  if (!node) return;

  const rect = node.getBoundingClientRect();

  let transform;

  if (node.fakeTransform) {
    transform = node.fakeTransform;
  } else {
    const computedStyle = window.getComputedStyle(node);
    transform =
      computedStyle.getPropertyValue('-webkit-transform') ||
      computedStyle.getPropertyValue('transform');
  }

  let offsetX = 0;
  let offsetY = 0;

  if (transform && transform !== 'none' && typeof transform === 'string') {
    const transformValues = transform
      .split('(')[1]
      .split(')')[0]
      .split(',');
    offsetX = parseInt(transformValues[4], 10);
    offsetY = parseInt(transformValues[5], 10);
  }

  if (direction === 'left' || direction === 'start') {
    return `translateX(${window.innerWidth}px) translateX(-${rect.left -
      offsetX}px)`;
  }

  if (direction === 'right' || direction === 'end') {
    return `translateX(-${rect.left + rect.width - offsetX}px)`;
  }

  if (direction === 'up' || direction === 'top') {
    return `translateY(${window.innerHeight}px) translateY(-${rect.top -
      offsetY}px)`;
  }

  // direction === 'down'
  return `translateY(-${rect.top + rect.height - offsetY}px)`;
}

export function setSlideTranslateValue(direction, node) {
  if (!node) return;

  const transform = getSlideTranslateValue(direction, node);

  if (transform) {
    node.style.webkitTransform = transform;
    node.style.transform = transform;
  }

  repaint(node);
}
