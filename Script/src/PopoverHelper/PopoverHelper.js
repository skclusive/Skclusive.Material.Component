// @ts-check

import {
  getScrollParent,
  ownerDocument,
  ownerWindow
} from "../DomHelpers/DomHelpers";

export function getContentAnchorOffset(contentAnchor, element) {
  let contentAnchorOffset = 0;
  if (contentAnchor && element.contains(contentAnchor)) {
    const scrollTop = getScrollParent(element, contentAnchor);
    contentAnchorOffset =
      contentAnchor.offsetTop + contentAnchor.clientHeight / 2 - scrollTop || 0;
  }
  return contentAnchorOffset;
}

export function getAnchorBoundry(anchorRef, paperRef) {
  const containerWindow = ownerWindow(anchorRef);

  // If an anchor element wasn't provided, just use the parent body element of this Popover
  const anchorElement =
    anchorRef instanceof containerWindow.Element
      ? anchorRef
      : ownerDocument(paperRef).body;
  const anchorRect = anchorElement.getBoundingClientRect();

  return anchorRect;
}
