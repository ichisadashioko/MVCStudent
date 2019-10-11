/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./Scripts/Home/react/RuleManagement.tsx");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Scripts/Home/react/RuleManagement.tsx":
/*!***********************************************!*\
  !*** ./Scripts/Home/react/RuleManagement.tsx ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _typeof(obj) { if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }; } return _typeof(obj); }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === "object" || typeof call === "function")) { return call; } return _assertThisInitialized(self); }

function _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return self; }

function _getPrototypeOf(o) { _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) { return o.__proto__ || Object.getPrototypeOf(o); }; return _getPrototypeOf(o); }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function"); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, writable: true, configurable: true } }); if (superClass) _setPrototypeOf(subClass, superClass); }

function _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }

function ownKeys(object, enumerableOnly) { var keys = Object.keys(object); if (Object.getOwnPropertySymbols) { var symbols = Object.getOwnPropertySymbols(object); if (enumerableOnly) symbols = symbols.filter(function (sym) { return Object.getOwnPropertyDescriptor(object, sym).enumerable; }); keys.push.apply(keys, symbols); } return keys; }

function _objectSpread(target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i] != null ? arguments[i] : {}; if (i % 2) { ownKeys(source, true).forEach(function (key) { _defineProperty(target, key, source[key]); }); } else if (Object.getOwnPropertyDescriptors) { Object.defineProperties(target, Object.getOwnPropertyDescriptors(source)); } else { ownKeys(source).forEach(function (key) { Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key)); }); } } return target; }

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

function _slicedToArray(arr, i) { return _arrayWithHoles(arr) || _iterableToArrayLimit(arr, i) || _nonIterableRest(); }

function _nonIterableRest() { throw new TypeError("Invalid attempt to destructure non-iterable instance"); }

function _iterableToArrayLimit(arr, i) { if (!(Symbol.iterator in Object(arr) || Object.prototype.toString.call(arr) === "[object Arguments]")) { return; } var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"] != null) _i["return"](); } finally { if (_d) throw _e; } } return _arr; }

function _arrayWithHoles(arr) { if (Array.isArray(arr)) return arr; }

function RulesBox(props) {
  var _React$useState = React.useState({
    rules: props.initialRules,
    page: props.page,
    hasMore: true,
    loadingMore: false
  }),
      _React$useState2 = _slicedToArray(_React$useState, 2),
      state = _React$useState2[0],
      updateState = _React$useState2[1];

  function loadMoreClicked(evt) {
    var nextPage = state.page + 1;
    var rules = state.rules;
    updateState(function (prevState) {
      return _objectSpread({}, prevState, {
        page: nextPage,
        loadingMore: true
      });
    });
    var url = '/Home/Rules/' + (state.page + 1);
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.setRequestHeader('Content-Type', 'application/json');

    xhr.onload = function () {
      var data = JSON.parse(xhr.responseText);
      updateState(function (prevState) {
        return _objectSpread({}, prevState, {
          rules: rules.concat(data.rules),
          hasMore: data.hasMore,
          loadingMore: false
        });
      });
    };

    xhr.send();
    evt.preventDefault();
  }

  var ruleNodes = state.rules.map(function (rule) {
    return React.createElement(RuleRow, {
      rule: rule
    });
  });

  function renderMoreLink() {
    if (state.loadingMore) {
      return React.createElement("em", null, "Loading...");
    } else if (state.hasMore) {
      return React.createElement(Reactstrap.Button, {
        onClick: loadMoreClicked
      }, "Load More");
    } else {
      return React.createElement("em", null, "No more rules");
    }
  }

  return React.createElement("div", {
    className: "rules"
  }, React.createElement("h1", null, "Rules "), React.createElement("ol", {
    className: "ruleList"
  }, ruleNodes, ">"), renderMoreLink(), React.createElement("hr", null));
}

var RuleRow =
/*#__PURE__*/
function (_React$Component) {
  _inherits(RuleRow, _React$Component);

  function RuleRow() {
    _classCallCheck(this, RuleRow);

    return _possibleConstructorReturn(this, _getPrototypeOf(RuleRow).apply(this, arguments));
  }

  _createClass(RuleRow, [{
    key: "render",
    value: function render() {
      return React.createElement("tr", null, React.createElement("td", null, this.props.FullName), React.createElement("td", null, this.props.Description), React.createElement("td", null, this.props.Active));
    }
  }]);

  return RuleRow;
}(React.Component);

_defineProperty(RuleRow, "propTypes", {
  rule: PropTypes.object.isRequired
});

/***/ })

/******/ });
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLy4vU2NyaXB0cy9Ib21lL3JlYWN0L1J1bGVNYW5hZ2VtZW50LnRzeCJdLCJuYW1lcyI6WyJSdWxlc0JveCIsInByb3BzIiwiUmVhY3QiLCJ1c2VTdGF0ZSIsInJ1bGVzIiwiaW5pdGlhbFJ1bGVzIiwicGFnZSIsImhhc01vcmUiLCJsb2FkaW5nTW9yZSIsInN0YXRlIiwidXBkYXRlU3RhdGUiLCJsb2FkTW9yZUNsaWNrZWQiLCJldnQiLCJuZXh0UGFnZSIsInByZXZTdGF0ZSIsInVybCIsInhociIsIlhNTEh0dHBSZXF1ZXN0Iiwib3BlbiIsInNldFJlcXVlc3RIZWFkZXIiLCJvbmxvYWQiLCJkYXRhIiwiSlNPTiIsInBhcnNlIiwicmVzcG9uc2VUZXh0IiwiY29uY2F0Iiwic2VuZCIsInByZXZlbnREZWZhdWx0IiwicnVsZU5vZGVzIiwibWFwIiwicnVsZSIsInJlbmRlck1vcmVMaW5rIiwiUnVsZVJvdyIsIkZ1bGxOYW1lIiwiRGVzY3JpcHRpb24iLCJBY3RpdmUiLCJDb21wb25lbnQiLCJQcm9wVHlwZXMiLCJvYmplY3QiLCJpc1JlcXVpcmVkIl0sIm1hcHBpbmdzIjoiO1FBQUE7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7OztRQUdBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwwQ0FBMEMsZ0NBQWdDO1FBQzFFO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0Esd0RBQXdELGtCQUFrQjtRQUMxRTtRQUNBLGlEQUFpRCxjQUFjO1FBQy9EOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQSx5Q0FBeUMsaUNBQWlDO1FBQzFFLGdIQUFnSCxtQkFBbUIsRUFB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QUFLakMsS0FBTCxDQUFXa0MsTUFBaEIsQ0FISixDQURKO0FBT0g7Ozs7RUFiaUJqQyxLQUFLLENBQUNrQyxTOztnQkFBdEJKLE8sZUFDaUI7QUFDZkYsTUFBSSxFQUFFTyxTQUFTLENBQUNDLE1BQVYsQ0FBaUJDO0FBRFIsQyIsImZpbGUiOiJydWxlX2luZGV4LmpzIiwic291cmNlc0NvbnRlbnQiOlsiIFx0Ly8gVGhlIG1vZHVsZSBjYWNoZVxuIFx0dmFyIGluc3RhbGxlZE1vZHVsZXMgPSB7fTtcblxuIFx0Ly8gVGhlIHJlcXVpcmUgZnVuY3Rpb25cbiBcdGZ1bmN0aW9uIF9fd2VicGFja19yZXF1aXJlX18obW9kdWxlSWQpIHtcblxuIFx0XHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcbiBcdFx0aWYoaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0pIHtcbiBcdFx0XHRyZXR1cm4gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0uZXhwb3J0cztcbiBcdFx0fVxuIFx0XHQvLyBDcmVhdGUgYSBuZXcgbW9kdWxlIChhbmQgcHV0IGl0IGludG8gdGhlIGNhY2hlKVxuIFx0XHR2YXIgbW9kdWxlID0gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0gPSB7XG4gXHRcdFx0aTogbW9kdWxlSWQsXG4gXHRcdFx0bDogZmFsc2UsXG4gXHRcdFx0ZXhwb3J0czoge31cbiBcdFx0fTtcblxuIFx0XHQvLyBFeGVjdXRlIHRoZSBtb2R1bGUgZnVuY3Rpb25cbiBcdFx0bW9kdWxlc1ttb2R1bGVJZF0uY2FsbChtb2R1bGUuZXhwb3J0cywgbW9kdWxlLCBtb2R1bGUuZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXyk7XG5cbiBcdFx0Ly8gRmxhZyB0aGUgbW9kdWxlIGFzIGxvYWRlZFxuIFx0XHRtb2R1bGUubCA9IHRydWU7XG5cbiBcdFx0Ly8gUmV0dXJuIHRoZSBleHBvcnRzIG9mIHRoZSBtb2R1bGVcbiBcdFx0cmV0dXJuIG1vZHVsZS5leHBvcnRzO1xuIFx0fVxuXG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlcyBvYmplY3QgKF9fd2VicGFja19tb2R1bGVzX18pXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm0gPSBtb2R1bGVzO1xuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZSBjYWNoZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5jID0gaW5zdGFsbGVkTW9kdWxlcztcblxuIFx0Ly8gZGVmaW5lIGdldHRlciBmdW5jdGlvbiBmb3IgaGFybW9ueSBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQgPSBmdW5jdGlvbihleHBvcnRzLCBuYW1lLCBnZXR0ZXIpIHtcbiBcdFx0aWYoIV9fd2VicGFja19yZXF1aXJlX18ubyhleHBvcnRzLCBuYW1lKSkge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBuYW1lLCB7IGVudW1lcmFibGU6IHRydWUsIGdldDogZ2V0dGVyIH0pO1xuIFx0XHR9XG4gXHR9O1xuXG4gXHQvLyBkZWZpbmUgX19lc01vZHVsZSBvbiBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIgPSBmdW5jdGlvbihleHBvcnRzKSB7XG4gXHRcdGlmKHR5cGVvZiBTeW1ib2wgIT09ICd1bmRlZmluZWQnICYmIFN5bWJvbC50b1N0cmluZ1RhZykge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBTeW1ib2wudG9TdHJpbmdUYWcsIHsgdmFsdWU6ICdNb2R1bGUnIH0pO1xuIFx0XHR9XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCAnX19lc01vZHVsZScsIHsgdmFsdWU6IHRydWUgfSk7XG4gXHR9O1xuXG4gXHQvLyBjcmVhdGUgYSBmYWtlIG5hbWVzcGFjZSBvYmplY3RcbiBcdC8vIG1vZGUgJiAxOiB2YWx1ZSBpcyBhIG1vZHVsZSBpZCwgcmVxdWlyZSBpdFxuIFx0Ly8gbW9kZSAmIDI6IG1lcmdlIGFsbCBwcm9wZXJ0aWVzIG9mIHZhbHVlIGludG8gdGhlIG5zXG4gXHQvLyBtb2RlICYgNDogcmV0dXJuIHZhbHVlIHdoZW4gYWxyZWFkeSBucyBvYmplY3RcbiBcdC8vIG1vZGUgJiA4fDE6IGJlaGF2ZSBsaWtlIHJlcXVpcmVcbiBcdF9fd2VicGFja19yZXF1aXJlX18udCA9IGZ1bmN0aW9uKHZhbHVlLCBtb2RlKSB7XG4gXHRcdGlmKG1vZGUgJiAxKSB2YWx1ZSA9IF9fd2VicGFja19yZXF1aXJlX18odmFsdWUpO1xuIFx0XHRpZihtb2RlICYgOCkgcmV0dXJuIHZhbHVlO1xuIFx0XHRpZigobW9kZSAmIDQpICYmIHR5cGVvZiB2YWx1ZSA9PT0gJ29iamVjdCcgJiYgdmFsdWUgJiYgdmFsdWUuX19lc01vZHVsZSkgcmV0dXJuIHZhbHVlO1xuIFx0XHR2YXIgbnMgPSBPYmplY3QuY3JlYXRlKG51bGwpO1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIobnMpO1xuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkobnMsICdkZWZhdWx0JywgeyBlbnVtZXJhYmxlOiB0cnVlLCB2YWx1ZTogdmFsdWUgfSk7XG4gXHRcdGlmKG1vZGUgJiAyICYmIHR5cGVvZiB2YWx1ZSAhPSAnc3RyaW5nJykgZm9yKHZhciBrZXkgaW4gdmFsdWUpIF9fd2VicGFja19yZXF1aXJlX18uZChucywga2V5LCBmdW5jdGlvbihrZXkpIHsgcmV0dXJuIHZhbHVlW2tleV07IH0uYmluZChudWxsLCBrZXkpKTtcbiBcdFx0cmV0dXJuIG5zO1xuIFx0fTtcblxuIFx0Ly8gZ2V0RGVmYXVsdEV4cG9ydCBmdW5jdGlvbiBmb3IgY29tcGF0aWJpbGl0eSB3aXRoIG5vbi1oYXJtb255IG1vZHVsZXNcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubiA9IGZ1bmN0aW9uKG1vZHVsZSkge1xuIFx0XHR2YXIgZ2V0dGVyID0gbW9kdWxlICYmIG1vZHVsZS5fX2VzTW9kdWxlID9cbiBcdFx0XHRmdW5jdGlvbiBnZXREZWZhdWx0KCkgeyByZXR1cm4gbW9kdWxlWydkZWZhdWx0J107IH0gOlxuIFx0XHRcdGZ1bmN0aW9uIGdldE1vZHVsZUV4cG9ydHMoKSB7IHJldHVybiBtb2R1bGU7IH07XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18uZChnZXR0ZXIsICdhJywgZ2V0dGVyKTtcbiBcdFx0cmV0dXJuIGdldHRlcjtcbiBcdH07XG5cbiBcdC8vIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbFxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5vID0gZnVuY3Rpb24ob2JqZWN0LCBwcm9wZXJ0eSkgeyByZXR1cm4gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKG9iamVjdCwgcHJvcGVydHkpOyB9O1xuXG4gXHQvLyBfX3dlYnBhY2tfcHVibGljX3BhdGhfX1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5wID0gXCJcIjtcblxuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKF9fd2VicGFja19yZXF1aXJlX18ucyA9IFwiLi9TY3JpcHRzL0hvbWUvcmVhY3QvUnVsZU1hbmFnZW1lbnQudHN4XCIpO1xuIiwidHlwZSBSdWxlUHJvcHMgPSB7XHJcbiAgICBGdWxsTmFtZTogc3RyaW5nO1xyXG4gICAgRGVzY3JpcHRpb246IHN0cmluZztcclxuICAgIEFjdGl2ZTogYm9vbGVhbjtcclxufTtcclxuXHJcbnR5cGUgUnVsZXNCb3hQcm9wcyA9IHtcclxuICAgIGluaXRpYWxSdWxlczogUnVsZVByb3BzW107XHJcbiAgICBwYWdlOiBudW1iZXI7XHJcbn07XHJcblxyXG5mdW5jdGlvbiBSdWxlc0JveChwcm9wczogUnVsZXNCb3hQcm9wcykge1xyXG4gICAgbGV0IFtzdGF0ZSwgdXBkYXRlU3RhdGVdID0gUmVhY3QudXNlU3RhdGUoe1xyXG4gICAgICAgIHJ1bGVzOiBwcm9wcy5pbml0aWFsUnVsZXMsXHJcbiAgICAgICAgcGFnZTogcHJvcHMucGFnZSxcclxuICAgICAgICBoYXNNb3JlOiB0cnVlLFxyXG4gICAgICAgIGxvYWRpbmdNb3JlOiBmYWxzZSxcclxuICAgIH0pO1xyXG5cclxuICAgIGZ1bmN0aW9uIGxvYWRNb3JlQ2xpY2tlZChldnQ6IHsgcHJldmVudERlZmF1bHQ6ICgpID0+IHZvaWQgfSkge1xyXG4gICAgICAgIGxldCBuZXh0UGFnZSA9IHN0YXRlLnBhZ2UgKyAxO1xyXG4gICAgICAgIGxldCBydWxlcyA9IHN0YXRlLnJ1bGVzO1xyXG4gICAgICAgIHVwZGF0ZVN0YXRlKHByZXZTdGF0ZSA9PiAoe1xyXG4gICAgICAgICAgICAuLi5wcmV2U3RhdGUsXHJcbiAgICAgICAgICAgIHBhZ2U6IG5leHRQYWdlLFxyXG4gICAgICAgICAgICBsb2FkaW5nTW9yZTogdHJ1ZSxcclxuICAgICAgICB9KSk7XHJcblxyXG4gICAgICAgIGxldCB1cmwgPSAnL0hvbWUvUnVsZXMvJyArIChzdGF0ZS5wYWdlICsgMSk7XHJcbiAgICAgICAgbGV0IHhociA9IG5ldyBYTUxIdHRwUmVxdWVzdCgpO1xyXG4gICAgICAgIHhoci5vcGVuKCdHRVQnLCB1cmwsIHRydWUpO1xyXG4gICAgICAgIHhoci5zZXRSZXF1ZXN0SGVhZGVyKCdDb250ZW50LVR5cGUnLCAnYXBwbGljYXRpb24vanNvbicpO1xyXG5cclxuICAgICAgICB4aHIub25sb2FkID0gKCkgPT4ge1xyXG4gICAgICAgICAgICBsZXQgZGF0YSA9IEpTT04ucGFyc2UoeGhyLnJlc3BvbnNlVGV4dCk7XHJcbiAgICAgICAgICAgIHVwZGF0ZVN0YXRlKHByZXZTdGF0ZSA9PiAoe1xyXG4gICAgICAgICAgICAgICAgLi4ucHJldlN0YXRlLFxyXG4gICAgICAgICAgICAgICAgcnVsZXM6IHJ1bGVzLmNvbmNhdChkYXRhLnJ1bGVzKSxcclxuICAgICAgICAgICAgICAgIGhhc01vcmU6IGRhdGEuaGFzTW9yZSxcclxuICAgICAgICAgICAgICAgIGxvYWRpbmdNb3JlOiBmYWxzZSxcclxuICAgICAgICAgICAgfSkpO1xyXG4gICAgICAgIH07XHJcbiAgICAgICAgeGhyLnNlbmQoKTtcclxuICAgICAgICBldnQucHJldmVudERlZmF1bHQoKTtcclxuICAgIH1cclxuXHJcbiAgICBsZXQgcnVsZU5vZGVzID0gc3RhdGUucnVsZXMubWFwKChydWxlOiBSdWxlUHJvcHMpID0+IChcclxuICAgICAgICA8UnVsZVJvdyBydWxlPXtydWxlfT48L1J1bGVSb3c+XHJcbiAgICApKTtcclxuXHJcbiAgICBmdW5jdGlvbiByZW5kZXJNb3JlTGluaygpIHtcclxuICAgICAgICBpZiAoc3RhdGUubG9hZGluZ01vcmUpIHtcclxuICAgICAgICAgICAgcmV0dXJuIDxlbT5Mb2FkaW5nLi4uPC9lbT5cclxuICAgICAgICB9IGVsc2UgaWYgKHN0YXRlLmhhc01vcmUpIHtcclxuICAgICAgICAgICAgcmV0dXJuIChcclxuICAgICAgICAgICAgICAgIDxSZWFjdHN0cmFwLkJ1dHRvbiBvbkNsaWNrPXtsb2FkTW9yZUNsaWNrZWR9PlxyXG4gICAgICAgICAgICAgICAgICAgIExvYWQgTW9yZVxyXG4gICAgICAgICAgICAgICAgPC9SZWFjdHN0cmFwLkJ1dHRvbj5cclxuICAgICAgICAgICAgKTtcclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICByZXR1cm4gPGVtPk5vIG1vcmUgcnVsZXM8L2VtPjtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG4gICAgcmV0dXJuIChcclxuICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInJ1bGVzXCI+XHJcbiAgICAgICAgICAgIDxoMT5SdWxlcyA8L2gxPlxyXG4gICAgICAgICAgICA8b2wgY2xhc3NOYW1lPVwicnVsZUxpc3RcIj57cnVsZU5vZGVzfT48L29sPlxyXG4gICAgICAgICAgICB7cmVuZGVyTW9yZUxpbmsoKX1cclxuICAgICAgICAgICAgPGhyIC8+XHJcbiAgICAgICAgPC9kaXY+XHJcbiAgICApO1xyXG59XHJcblxyXG5jbGFzcyBSdWxlUm93IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50PHsgcnVsZTogUnVsZVByb3BzIH0+e1xyXG4gICAgc3RhdGljIHByb3BUeXBlcyA9IHtcclxuICAgICAgICBydWxlOiBQcm9wVHlwZXMub2JqZWN0LmlzUmVxdWlyZWQsXHJcbiAgICB9O1xyXG5cclxuICAgIHJlbmRlcigpIHtcclxuICAgICAgICByZXR1cm4gKFxyXG4gICAgICAgICAgICA8dHI+XHJcbiAgICAgICAgICAgICAgICA8dGQ+e3RoaXMucHJvcHMuRnVsbE5hbWV9PC90ZD5cclxuICAgICAgICAgICAgICAgIDx0ZD57dGhpcy5wcm9wcy5EZXNjcmlwdGlvbn08L3RkPlxyXG4gICAgICAgICAgICAgICAgPHRkPnt0aGlzLnByb3BzLkFjdGl2ZX08L3RkPlxyXG4gICAgICAgICAgICA8L3RyPlxyXG4gICAgICAgIClcclxuICAgIH1cclxufSJdLCJzb3VyY2VSb290IjoiIn0=