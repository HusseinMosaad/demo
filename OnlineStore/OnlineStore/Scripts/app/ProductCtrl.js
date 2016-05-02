angular.module('OnlineStoreAngularApp').controller('ProductCtrl', ProductCtrl);
ProductCtrl.$inject = ['$scope', '$http', '$modal'];


// this must be added to web config
var ApiUrl = "http://localhost:3216/api/";

function ProductCtrl($scope, $http, $modal) {

    $scope.products = [];
    $scope.product = null;

    $scope.getAllSeenFeedbacks = function () {
        $http.get(ApiUrl + "product/GetAllProducts").
            then(function (response) {
                $scope.products = response.data;
            }, function (response) {
                console.log(response);
            });
    }

    $scope.deleteProduct = function (product) {

        $.confirm({
            text: "Are you sure?",
            title: "Confirmation required",
            confirm: function (button) {
                $http.post(ApiUrl + "product/DeleteProduct", product).
           then(function (response) {
               var index = $scope.products.indexOf(product);
               if (index > -1) {
                   $scope.products.splice(index, 1);
               }
               showSuccessMessage('Product deleted successfully');
           }, function (response) {
               showErrorMessage("Error occured while deleting");
           });

            },
            cancel: function (button) {
                // nothing to do
            },
            confirmButton: "Yes",
            cancelButton: "No",
            post: true,
            confirmButtonClass: "btn-danger",
            cancelButtonClass: "btn-default",
            dialogClass: "modal-dialog modal-md"
        });
    }

    $scope.editProduct = function (product) {
        var modalInstance = $modal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'product.html',
            controller: "SaveProductModalCtrl",
            size: "lg",
            resolve: {
                params: function () {
                    return {
                        products: $scope.products,
                        product: product
                    };
                }
            }
        });
    }

    $scope.insertProduct = function () {
        $scope.product = {
            Id: 0,
            Name: '',
            Description: '',
            Price: 0,
            Count: 0
        };

        var modalInstance = $modal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'product.html',
            controller: "SaveProductModalCtrl",
            size: "lg",
            resolve: {
                params: function () {
                    return {
                        products: $scope.products,
                        product: $scope.product
                    };
                }
            }
        });
    }

    $scope.getAllSeenFeedbacks();
}


angular.module('OnlineStoreAngularApp').controller('SaveProductModalCtrl', SaveProductModalCtrl);
SaveProductModalCtrl.$inject = ['$scope', '$http', '$modalInstance', 'params'];

function SaveProductModalCtrl($scope, $http, $modalInstance, params) {
    $scope.products = params.products;
    $scope.product = params.product;


    $scope.cancel = function () {
        $modalInstance.close();
    }

    $scope.saveProduct = function () {
        $http.post(ApiUrl + "product/SaveProduct", $scope.product).
            then(function (response) {
                if ($scope.product.Id === 0) {
                    $scope.products.push(response.data);
                }
                showSuccessMessage('Product saved successfully');
                $scope.cancel();
            }, function (response) {
                showErrorMessage(response.data);
            });
    }
}
