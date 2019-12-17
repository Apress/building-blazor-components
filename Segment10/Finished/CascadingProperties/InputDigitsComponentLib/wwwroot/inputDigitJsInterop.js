// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.jsInputDigit = {
  focus: function (inputElement) {
    inputElement.focus();
  },
  blur: function (inputElement) {
    inputElement.blur();
  }
};
