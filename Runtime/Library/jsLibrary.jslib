mergeInto(LibraryManager.library, {

  initializePaywall: function (paywallConfig) {
    UnlockUnity.initializePaywall(UTF8ToString(paywallConfig));
  },

  loadCheckoutModal: function(config) {
    UnlockUnity.loadCheckoutModal(UTF8ToString(config));
  }
  
});
