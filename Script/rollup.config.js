import resolve from "rollup-plugin-node-resolve";

process.env.INCLUDE_DEPS === "true";
module.exports = {
  input: "js/ScriptHelpers.js",
  output: {
    file: "wwwroot/ScriptHelpers.js",
    format: "iife"
  },
  plugins: [resolve()]
};
