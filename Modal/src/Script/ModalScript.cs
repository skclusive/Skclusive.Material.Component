using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class ModalScript : ScriptBase
    {
        public override string GetScript()
        {
            return @"!function(){""use strict"";function e(e,...t){const{DomHelpers:n}=window.Skclusive.Script;return n[e].apply(null,t)}class t{static construct(n,c,o,i,s){const a=function(...t){return e(""generateId"",...t)}(),r=document.activeElement,l=function(...t){return e(""ownerDocument"",...t)}(n);return t.cache[a]={id:a,node:n,doc:l,disableAutoFocus:c,disableRestoreFocus:o,disableEnforceFocus:i,isEnabled:s,lastActiveElement:r},t.initialize(a),a}static initialize(e){const n=t.cache[e];if(n){const{node:e,doc:t,disableAutoFocus:c,disableEnforceFocus:o,isEnabled:i}=n;let s=!1;c||!e||e.contains(t.activeElement)||(e.hasAttribute(""tabIndex"")||e.setAttribute(""tabIndex"",-1),e.focus());const a=()=>{o||!i||s?s=!1:e&&!e.contains(t.activeElement)&&e.focus()},r=e=>{!o&&i&&9===e.keyCode&&t.activeElement===rootRef.current&&(s=!0,e.shiftKey?sentinelEnd.current.focus():sentinelStart.current.focus())};t.addEventListener(""focus"",a,!0),t.addEventListener(""keydown"",r,!0);const l=setInterval(()=>{a()},50);Object.assign(n,{interval:l,contain:a,loopFocus:r})}}static dispose(e){const n=t.cache[e];if(n){const{doc:e,interval:t,contain:c,loopFocus:o,lastActiveElement:i,disableRestoreFocus:s}=n;clearInterval(t),e.removeEventListener(""focus"",c,!0),e.removeEventListener(""keydown"",o,!0),!s&&i&&i.focus()}delete t.cache[e]}}var n,c,o;o={},(c=""cache"")in(n=t)?Object.defineProperty(n,c,{value:o,enumerable:!0,configurable:!0,writable:!0}):n[c]=o,window.Skclusive={...window.Skclusive,Material:{...(window.Skclusive||{}).Material,Modal:{TrapFocusHelper:t}}}}();";
        }
    }
}
