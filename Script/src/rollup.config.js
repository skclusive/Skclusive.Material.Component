import resolve from "rollup-plugin-node-resolve";
import { terser } from "rollup-plugin-terser";

process.env.INCLUDE_DEPS === "true";
module.exports = {
  input: "ScriptHelpers/ScriptHelpers.js",
  output: {
    file: "artifacts/ScriptHelpers.js",
    format: "iife"
  },
  plugins: [resolve(), terser()]
};
