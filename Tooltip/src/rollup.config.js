import resolve from "rollup-plugin-node-resolve";
import { terser } from "rollup-plugin-terser";

process.env.INCLUDE_DEPS === "true";
module.exports = {
  input: "Popper/popper-interop.js",
  output: {
    file: "artifacts/popper-interop.js",
    format: "iife"
  },
  plugins: [resolve(), terser()]
};
