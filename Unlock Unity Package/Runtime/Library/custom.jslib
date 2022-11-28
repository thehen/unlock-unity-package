mergeInto(LibraryManager.library, {

  InitializeJs: function (config) {
    UnlockUnity.initialize(UTF8ToString(config));
  },

  ConnectMetaMaskJs: function(config) {
    UnlockUnity.connectMetaMask();
  },

  ConnectWalletConnectJs: function(config) {
    UnlockUnity.connectWalletConnect();
  },

  GetLockJs: function(config) {
    UnlockUnity.getLock(UTF8ToString(config));
  },

  PurchaseKeyJs: function(config) {
    UnlockUnity.purchaseKey(UTF8ToString(config));
  },

  GetHasValidKeyJs: function(config) {
    UnlockUnity.getHasValidKey(UTF8ToString(config));
  },

  GetBalanceJs: function(address) {
    UnlockUnity.getBalance(UTF8ToString(address));
  },

  GetNetworkIdJs: function() {
    UnlockUnity.getNetworkId();
  }
  
});
