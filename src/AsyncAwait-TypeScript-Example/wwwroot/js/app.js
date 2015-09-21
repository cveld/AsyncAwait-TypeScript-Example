"use strict";

var __awaiter = undefined && undefined.__awaiter || function (thisArg, _arguments, Promise, generator) {
    return new Promise(function (resolve, reject) {
        generator = generator.call(thisArg, _arguments);
        function cast(value) {
            return value instanceof Promise && value.constructor === Promise ? value : new Promise(function (resolve) {
                resolve(value);
            });
        }
        function onfulfill(value) {
            try {
                step("next", value);
            } catch (e) {
                reject(e);
            }
        }
        function onreject(value) {
            try {
                step("throw", value);
            } catch (e) {
                reject(e);
            }
        }
        function step(verb, value) {
            var result = generator[verb](value);
            result.done ? resolve(result.value) : cast(result.value).then(onfulfill, onreject);
        }
        step("next", void 0);
    });
};
function test() {
    console.log("async func2");
    awaiter();
}
function awaiter() {
    return __awaiter(this, void 0, Promise, regeneratorRuntime.mark(function callee$1$0() {
        var q;
        return regeneratorRuntime.wrap(function callee$1$0$(context$2$0) {
            while (1) switch (context$2$0.prev = context$2$0.next) {
                case 0:
                    context$2$0.next = 2;
                    return asyncfunc();

                case 2:
                    q = context$2$0.sent;

                    console.log(q);

                case 4:
                case "end":
                    return context$2$0.stop();
            }
        }, callee$1$0, this);
    }));
}
function asyncfunc() {
    var p = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve('a string');
            console.log("resolved");
        }, 2000);
    });
    return p;
}
//# sourceMappingURL=app.js.map