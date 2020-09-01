// @ts-check

export function focusRadioGroup(node) {
  let input = node.querySelector("input:not(:disabled):checked");

  if (!input) {
    input = node.querySelector("input:not(:disabled)");
  }

  if (input) {
    input.focus();
  }
}
