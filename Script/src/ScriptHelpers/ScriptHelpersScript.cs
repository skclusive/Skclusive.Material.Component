using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;

namespace Skclusive.Material.Script
{
    public class ScriptHelpersScript : StaticComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddContent(1,
            #region ScriptHelpers.js
            @"
            (function () {
            'use strict';

            // @ts-check

            function generateId() {
              return Math.random()
                .toString(36)
                .substr(2);
            }

            function repaint(element) {
              // This is for to force a repaint,
              // which is necessary in order to transition styles when adding a class name.
              element.scrollTop;
            }

            function debounce(func, wait = 166) {
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

            function ownerDocument(node) {
              return node && node.ownerDocument || document;
            }

            function goBack(depth) {
                setTimeout(() => history.go(depth), 2000);
            }

            // @ts-check

            const eventPool = {};

            function registerHistoryBack(node, name, delay) {
              const id = generateId();
              let callback = eventCallback(id);
              node.addEventListener(name, callback);

              const dispose = () => node.removeEventListener(name, callback);

              eventPool[id] = { id, delay, dispose };

              return id;
            }

            function eventCallback(id) {
              return e => {
                e.preventDefault();
                e.stopPropagation();
                e.currentTarget.blur();
                const record = eventPool[id];
                if (record) {
                  if (record.delay) {
                    setTimeout(() => history.back(), record.delay);
                  } else {
                    history.back();
                  }
                }
              };
            }

            function unRegisterHistoryBack(id) {
              const record = eventPool[id];
              if (record && record.dispose) {
                record.dispose();
              }
              delete eventPool[id];
            }

            // @ts-check

            // Translate the node so he can't be seen on the screen.
            // Later, we gonna translate back the node to his original location
            // with `none`.`
            function getTranslateValue(direction, node) {
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

            function setTranslateValue(direction, node) {
              if (!node) return;

              const transform = getTranslateValue(direction, node);

              if (transform) {
                node.style.webkitTransform = transform;
                node.style.transform = transform;
              }

              repaint(node);
            }

            // @ts-check

            const eventPool$1 = {};

            function registerEvent(node, name, target, delay) {
              const id = generateId();
              const source = node instanceof Element ? node : window;
              let callback = eventCallback$1(id);
              if (delay) {
                callback = debounce(callback, delay);
              }
              source.addEventListener(name, callback);

              const dispose = () => source.removeEventListener(name, callback);

              eventPool$1[id] = { id, source, target, dispose };

              return id;
            }

            function eventCallback$1(id) {
              return e => {
                const record = eventPool$1[id];
                if (record && record.target) {
                  record.target.invokeMethodAsync('OnEventAsync', JSON.stringify(e));
                }
              };
            }

            function unRegisterEvent(id) {
              const record = eventPool$1[id];
              if (record && record.dispose) {
                record.dispose();
              }
              delete eventPool$1[id];
            }

            // @ts-check

            const focusPool = {};

            function initTrapFocus(
              node,
              disableAutoFocus,
              disableRestoreFocus,
              disableEnforceFocus,
              isEnabled
            ) {
              const id = generateId();
              const lastActiveElement = document.activeElement;
              const doc = ownerDocument(node);
              let ignoreNextEnforceFocus = false;
              // We might render an empty child.
              if (!disableAutoFocus && node && !node.contains(doc.activeElement)) {
                if (!node.hasAttribute('tabIndex')) {
                  node.setAttribute('tabIndex', -1);
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

              const loopFocus = event => {
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

              doc.addEventListener('focus', contain, true);
              doc.addEventListener('keydown', loopFocus, true);

              // With Edge, Safari and Firefox, no focus related events are fired when the focused area stops being a focused area
              // e.g. https://bugzilla.mozilla.org/show_bug.cgi?id=559561.
              //
              // The whatwg spec defines how the browser should behave but does not explicitly mention any events:
              // https://html.spec.whatwg.org/multipage/interaction.html#focus-fixup-rule.
              const interval = setInterval(() => {
                contain();
              }, 50);

              const dispose = () => {
                clearInterval(interval);

                doc.removeEventListener('focus', contain, true);
                doc.removeEventListener('keydown', loopFocus, true);

                if (!disableRestoreFocus && lastActiveElement) {
                  // @ts-ignore
                  lastActiveElement.focus();
                }
              };

              focusPool[id] = { id, dispose };

              return id;
            }

            function disposeTrapFocus(id) {
              const record = focusPool[id];
              if (record && record.dispose) {
                record.dispose();
              }
              delete focusPool[id];
            }

            // @ts-check

            const eventPool$2 = {};

            function registerMediaQuery(query, target) {
              const id = generateId();

              query = query.replace(/^@media( ?)/m, '');

              const queryList = window.matchMedia(query);

              const callback = eventCallback$2(id);

              queryList.addListener(callback);

              const dispose = () => queryList.removeListener(callback);

              eventPool$2[id] = { id, queryList, target, dispose };

              setTimeout(callback);

              return id;
            }

            function eventCallback$2(id) {
              return e => {
                const record = eventPool$2[id];
                if (record && record.target) {
                  record.target.invokeMethodAsync(
                    'OnChangeAsync',
                    !!record.queryList.matches
                  );
                }
              };
            }

            function unRegisterMediaQuery(id) {
              const record = eventPool$2[id];
              if (record && record.dispose) {
                record.dispose();
              }
              delete eventPool$2[id];
            }

            // @ts-check

            // @ts-ignore
            window.Skclusive = {
              // @ts-ignore
              ...window.Skclusive,
              Material: {
                // @ts-ignore
                ...(window.Skclusive || {}).Material,
                Script: {
                  goBack,
                  getTranslateValue,
                  setTranslateValue,
                  registerEvent,
                  unRegisterEvent,
                  initTrapFocus,
                  disposeTrapFocus,
                  registerMediaQuery,
                  unRegisterMediaQuery,
                  registerHistoryBack,
                  unRegisterHistoryBack
                }
              }
            };

          }());
            "
            #endregion
            );
            builder.CloseElement();
        }
    }
}
