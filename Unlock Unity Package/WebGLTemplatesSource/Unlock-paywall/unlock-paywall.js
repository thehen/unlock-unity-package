var UnlockUnity;(()=>{var e={25370:function(e,n){var t,o;void 0===(o="function"==typeof(t=function(){var e=function(){},n={},t={},o={};function r(e,n){if(e){var r=o[e];if(t[e]=n,r)for(;r.length;)r[0](e,n),r.splice(0,1)}}function i(n,t){n.call&&(n={success:n}),t.length?(n.error||e)(t):(n.success||e)(n)}function c(n,t,o,r){var i,s,a=document,l=o.async,u=(o.numRetries||0)+1,f=o.before||e,d=n.replace(/[\?|#].*$/,""),p=n.replace(/^(css|img)!/,"");r=r||0,/(^css!|\.css$)/.test(d)?((s=a.createElement("link")).rel="stylesheet",s.href=p,(i="hideFocus"in s)&&s.relList&&(i=0,s.rel="preload",s.as="style")):/(^img!|\.(png|gif|jpg|svg|webp)$)/.test(d)?(s=a.createElement("img")).src=p:((s=a.createElement("script")).src=n,s.async=void 0===l||l),s.onload=s.onerror=s.onbeforeload=function(e){var a=e.type[0];if(i)try{s.sheet.cssText.length||(a="e")}catch(e){18!=e.code&&(a="e")}if("e"==a){if((r+=1)<u)return c(n,t,o,r)}else if("preload"==s.rel&&"style"==s.as)return s.rel="stylesheet";t(n,a,e.defaultPrevented)},!1!==f(n,s)&&a.head.appendChild(s)}function s(e,t,o){var s,a;if(t&&t.trim&&(s=t),a=(s?o:t)||{},s){if(s in n)throw"LoadJS";n[s]=!0}function l(n,t){!function(e,n,t){var o,r,i=(e=e.push?e:[e]).length,s=i,a=[];for(o=function(e,t,o){if("e"==t&&a.push(e),"b"==t){if(!o)return;a.push(e)}--i||n(a)},r=0;r<s;r++)c(e[r],o,t)}(e,(function(e){i(a,e),n&&i({success:n,error:t},e),r(s,e)}),a)}if(a.returnPromise)return new Promise(l);l()}return s.ready=function(e,n){return function(e,n){e=e.push?e:[e];var r,i,c,s=[],a=e.length,l=a;for(r=function(e,t){t.length&&s.push(e),--l||n(s)};a--;)i=e[a],(c=t[i])?r(i,c):(o[i]=o[i]||[]).push(r)}(e,(function(e){i(n,e)})),s},s.done=function(e){r(e,[])},s.reset=function(){n={},t={},o={}},s.isDefined=function(e){return e in n},s})?t.apply(n,[]):t)||(e.exports=o)}},n={};function t(o){var r=n[o];if(void 0!==r)return r.exports;var i=n[o]={exports:{}};return e[o].call(i.exports,i,i.exports,t),i.exports}t.n=e=>{var n=e&&e.__esModule?()=>e.default:()=>e;return t.d(n,{a:n}),n},t.d=(e,n)=>{for(var o in n)t.o(n,o)&&!t.o(e,o)&&Object.defineProperty(e,o,{enumerable:!0,get:n[o]})},t.o=(e,n)=>Object.prototype.hasOwnProperty.call(e,n),t.r=e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})};var o={};(()=>{"use strict";t.r(o),t.d(o,{initialize:()=>i,initializePaywall:()=>r,loadCheckoutModal:()=>c});var e=t(25370),n=t.n(e);async function r(e){window.unlockProtocolConfig=JSON.parse(e),await n()(window.unlockProtocolConfig.checkoutUrlBase,"paywall",{returnPromise:!0}),window.unlockProtocol.resetConfig(window.unlockProtocolConfig),window.addEventListener("unlockProtocol.status",(function(e){window.gameInstance.SendMessage("UnlockPaywall","UpdateStatus",e.detail.state)}))}async function i(){console.error("Error: calling custom function on Paywall template. Ensure you have the custom WebGL template selected in your Unity build settings.")}async function c(e){const n=JSON.parse(e);window.unlockProtocol.loadCheckoutModal(n)}void 0!==window.ethereum&&(window.ethereum.autoRefreshOnNetworkChange=!1)})(),UnlockUnity=o})();