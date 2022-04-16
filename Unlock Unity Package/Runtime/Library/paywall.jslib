mergeInto(LibraryManager.library, {

  InitializePaywallJs: function (paywallConfig) {
    UnlockUnity.initializePaywall(UTF8ToString(paywallConfig));
  },

  LoadCheckoutModalJs: function(config) {
    UnlockUnity.loadCheckoutModal(UTF8ToString(config));
  }
  
});
