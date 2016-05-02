var app = angular.module('OnlineStoreAngularApp', ['ui.bootstrap']);

angular.module('OnlineStoreAngularApp').directive('toNumber', toNumber);

function toNumber() {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            ctrl.$parsers.push(function (value) {
                return parseFloat(value || '');
            });
        }
    };
}
