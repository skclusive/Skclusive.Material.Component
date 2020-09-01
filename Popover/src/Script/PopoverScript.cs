using Skclusive.Core.Component;

namespace Skclusive.Material.Popover
{
    public class PopoverScript : ScriptComponentBase
    {
        protected override string GetScript()
        {
            return @"!function(){""use strict"";function n(n,...t){const{DomHelpers:e}=window.Skclusive.Script;return e[n].apply(null,t)}window.Skclusive={...window.Skclusive,Material:{...(window.Skclusive||{}).Material,Popover:{getContentAnchorOffset:function(t,e){let o=0;if(t&&e.contains(t)){const i=function(...t){return n(""getScrollParent"",...t)}(e,t);o=t.offsetTop+t.clientHeight/2-i||0}return o},getAnchorBoundry:function(t,e){return(t instanceof function(...t){return n(""ownerWindow"",...t)}(t).Element?t:function(...t){return n(""ownerDocument"",...t)}(e).body).getBoundingClientRect()}}}}}();";
        }
    }
}
