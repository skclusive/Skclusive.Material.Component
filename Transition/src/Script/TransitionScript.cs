using Skclusive.Core.Component;

namespace Skclusive.Material.Transition
{
    public class TransitionScript : ScriptBase
    {
        public override string GetScript()
        {
            return @"!function(){""use strict"";function t(...t){return function(t,...e){const{DomHelpers:n}=window.Skclusive.Script;return n[t].apply(null,e)}(""repaint"",...t)}function e(t,e){if(!e)return;const n=e.getBoundingClientRect();let r;if(e.fakeTransform)r=e.fakeTransform;else{const t=window.getComputedStyle(e);r=t.getPropertyValue(""-webkit-transform"")||t.getPropertyValue(""transform"")}let i=0,a=0;if(r&&""none""!==r&&""string""==typeof r){const t=r.split(""("")[1].split("")"")[0].split("","");i=parseInt(t[4],10),a=parseInt(t[5],10)}return""left""===t||""start""===t?`translateX(${window.innerWidth}px) translateX(-${n.left-i}px)`:""right""===t||""end""===t?`translateX(-${n.left+n.width-i}px)`:""up""===t||""top""===t?`translateY(${window.innerHeight}px) translateY(-${n.top-a}px)`:`translateY(-${n.top+n.height-a}px)`}window.Skclusive={...window.Skclusive,Material:{...(window.Skclusive||{}).Material,Transition:{getSlideTranslateValue:e,setSlideTranslateValue:function(n,r){if(!r)return;const i=e(n,r);i&&(r.style.webkitTransform=i,r.style.transform=i),t(r)}}}}}();";
        }
    }
}
