var UnlockUnity;
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	// The require scope
/******/ 	var __webpack_require__ = {};
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "initializePaywall": () => (/* binding */ initializePaywall),
/* harmony export */   "loadCheckoutModal": () => (/* binding */ loadCheckoutModal)
/* harmony export */ });
async function initializePaywall( paywallConfig ) {
  window.unlockProtocolConfig = JSON.parse(paywallConfig);
  window.unlockProtocol.resetConfig(window.unlockProtocolConfig);
  //console.log(paywallConfig);

  window.addEventListener("unlockProtocol.status", function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateStatus', event.detail.state);
  });
  
  window.addEventListener("unlockProtocol.authenticated", function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateAddress', event.detail.address);
  });
  
  window.addEventListener("unlockProtocol.transactionSent", function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateHash', event.detail.hash);
  });

}

async function loadCheckoutModal( lockConfig ) {
  //console.log(lockConfig);
  const config = JSON.parse(lockConfig);
  window.unlockProtocol.loadCheckoutModal(config)
}


UnlockUnity = __webpack_exports__;
/******/ })()
;